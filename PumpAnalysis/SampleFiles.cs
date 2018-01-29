using PumpLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PumpAnalysis
{
    public partial class SampleFiles : Form
    {
        public SampleFiles()
        {
            InitializeComponent();
        }

        public SampleFiles(int ExtraDataId)
        {
            InitializeComponent();

            extraDataId = ExtraDataId;
            
            //fill listview
            string[] fileNames = getSavedAttachments(ExtraDataId);
            foreach (string thisFileName in fileNames)
            {
                lvAttachedFiles.Items.Add(new ListViewItem(thisFileName));
            }
        }

        int extraDataId = 0;

        public string[] getSavedAttachments(int Id)
        {
            List<string> ret = new List<string>();

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT filename FROM [dbo].[SampleFiles] WHERE ExtraDataId = " + Id.ToString();
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ret.Add(reader["filename"].ToString().Trim());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret.ToArray();
        }

        private void lvAttachedFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvAttachedFiles_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) //file from Explorer
                {
                    addFilesIntoListView((ListView)sender, (string[])e.Data.GetData(DataFormats.FileDrop));
                }
                else if (e.Data.GetDataPresent("FileGroupDescriptor")) //file from Outlook
                {
                    Stream theStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                    byte[] fileGroupDescriptor = new byte[theStream.Length]; //512
                    theStream.Read(fileGroupDescriptor, 0, Convert.ToInt32(theStream.Length)); //512
                    string FileNamesStr = Encoding.Default.GetString(fileGroupDescriptor);

                    List<string> filesList = FileNamesStr.Split('\0').ToList<string>();
                    
                    if (filesList.Count > 1)
                    {
                        MessageBox.Show("Παρακαλώ μεταφέρετε μόνο ένα αρχείο κάθε φορά!");
                        //return;
                    }
                    else
                    {
                        string fileName = GetOutlookAttachmentAndSaveIt((Stream)e.Data.GetData("FileGroupDescriptor"), (MemoryStream)e.Data.GetData("FileContents", true));
                        addFilesIntoListView((ListView)sender, new string[] { fileName });
                    }
                }
                else
                {
                    addFilesIntoListView((ListView)sender, (string[])e.Data.GetData(DataFormats.FileDrop)); //????
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        string GetOutlookAttachmentAndSaveIt(Stream fileStr, MemoryStream rawFileMemStr)
        {
            string ret = "";
            try
            {
                Stream theStream = fileStr;
                byte[] fileGroupDescriptor = new byte[theStream.Length]; //512
                theStream.Read(fileGroupDescriptor, 0, Convert.ToInt32(theStream.Length)); //512
                StringBuilder fileName = new StringBuilder("");

                for (int i = 76; fileGroupDescriptor[i] != 0; i++)
                {
                    fileName.Append(Encoding.Default.GetString(fileGroupDescriptor, i, 1));
                }
                theStream.Close();
                string path = Path.GetTempPath();
                string theFile = path + fileName.ToString();

                MemoryStream ms = rawFileMemStr;
                byte[] fileBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(fileBytes, 0, (int)ms.Length);
                FileStream fs = new FileStream(theFile, FileMode.Create);
                fs.Write(fileBytes, 0, (int)fileBytes.Length);
                fs.Close();  
                FileInfo tempFile = new FileInfo(theFile);
                if (tempFile.Exists == true)
                {
                    //tempFile.Delete();
                    ret = theFile;
                }
                else
                {
                    MessageBox.Show("File was not created!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        void addFilesIntoListView(ListView myListView, string[] fileNames)
        {
            bool exists = false;

            if (fileNames is null)
            {
                MessageBox.Show("Δε βρέθηκε η τοποθεσία του αρχείου. \r\nΠαρακαλώ επιλέξτε αρχεία που είναι αποθηκευμένα τοπικά στο δίσκο σας!");
                return;
            }

            foreach (string thisFile in fileNames)
            {
                exists = false;
                System.IO.FileInfo newFile = new System.IO.FileInfo(thisFile);
                
                foreach (ListViewItem lvi in myListView.Items)
                {
                    if (lvi.SubItems[0].Text.ToUpper() == newFile.Name.ToUpper())
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    MessageBox.Show("Υπάρχει ήδη αρχείο στη λίστα με όνομα '" + newFile.Name + "'");//File already exists!");
                    continue;
                }

                ListViewItem lvItem = new ListViewItem(new string[] { newFile.Name, newFile.FullName });
                myListView.Items.Add(lvItem);
            }
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add Files";
            ofd.Multiselect = true; //array of files
            ofd.ShowDialog();

            //Add Files into listView...
            addFilesIntoListView(lvAttachedFiles, ofd.FileNames);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.SelectedItems.Count > 0)
            {
                string lvPath = "";

                if (lvAttachedFiles.SelectedItems[0].SubItems.Count == 1) //only filename from database into lv
                //if (CountSampleFiles(extraDataId) > 0) //select 
                {
                    string ext = "";
                    string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
                    string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(lvAttachedFiles.SelectedItems[0].SubItems[0].Text) + "~" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
                    try
                    {
                        if (!Directory.Exists(tempPath))
                        {
                            MessageBox.Show("Σφάλμα. Παρακαλώ ελέγξτε τα δικαιώματά σας στο " + tempPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }

                    SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                    string SelectSt = "SELECT [FileCont] FROM [dbo].[SampleFiles] WHERE ExtraDataId = @ExtraDataId and Filename = @Filename";
                    SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
                    try
                    {
                        sqlConn.Open();

                        cmd.Parameters.AddWithValue("@ExtraDataId", extraDataId);
                        cmd.Parameters.AddWithValue("@Filename", lvAttachedFiles.SelectedItems[0].SubItems[0].Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string fname = lvAttachedFiles.SelectedItems[0].SubItems[0].Text;
                            ext = fname.Substring(fname.LastIndexOf("."));
                            lvPath = tempFile + ext;
                            File.WriteAllBytes(tempFile + ext, (byte[])reader["FileCont"]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                        return;
                    }
                }
                else //path and filename from local dir into lv
                //insert || update -> update ??? mixed files, check... 
                {               
                    lvPath = lvAttachedFiles.SelectedItems[0].SubItems[1].Text;
                }

                System.Diagnostics.Process.Start(lvPath);
            }
            
        }

        public int CountSampleFiles(int extraDataId)
        {
            int ret = 0;

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT count(*) as cnt FROM [dbo].[SampleFiles] where ExtraDataId = @ExtraDataId ", sqlConn);

            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@ExtraDataId", extraDataId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ret = Convert.ToInt32(reader["cnt"].ToString());
                }

                reader.Close();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }

            return ret;
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.SelectedItems.Count > 0)
            {
                lvAttachedFiles.SelectedItems[0].Remove();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lvAttachedFiles.Items.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lvAttachedFiles.Items.Count > 0)
            {
                List<ListViewItem> newLvItems = new List<ListViewItem>();
                
                foreach (ListViewItem lvi in lvAttachedFiles.Items)
                {
                    if (lvi.SubItems.Count == 1) //only filename into lv -> from db
                    {
                        LvFileInfo lvfi = saveAttachmentLocally(extraDataId, lvi.SubItems[0].Text);

                        newLvItems.Add(new ListViewItem(new string[] { lvfi.FileName, lvfi.FilePath }));
                    }
                    else //path and filename into lv -> from local dir : ok
                    {
                        newLvItems.Add(lvi);
                    }
                }

                Delete_SampleFiles(extraDataId); //delete from db

                //lvAttachedFiles.Items.Clear();
                //lvAttachedFiles.Items.AddRange(newLvItems.ToArray());

                //insert attachments into db
                foreach (ListViewItem lvi in newLvItems)
                {
                    byte[] attFileBytes = File.ReadAllBytes(lvi.SubItems[1].Text);

                    if (!InertIntoTable_SampleFiles(extraDataId, lvi.SubItems[0].Text, attFileBytes))
                    {
                        MessageBox.Show("Αποτυχία αποθήκευσης του αρχείου: " + lvi.SubItems[0].Text);
                    }
                }
                
                Close();
            }
            else
            {
                MessageBox.Show("Δεν υπάρχουν αρχεία προς αποθήκευση!");
            }
        }

        private bool Delete_SampleFiles(int Id) 
        {
            bool ret = false;

            if (Id > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "DELETE FROM [dbo].[SampleFiles] WHERE ExtraDataId = @ExtraDataId ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@ExtraDataId", Id);
                    cmd.CommandType = CommandType.Text;
                    //int rowsAffected = cmd.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();

                    //if (rowsAffected > 0)
                    //{
                    ret = true;
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }

        LvFileInfo saveAttachmentLocally(int Id, string Filename)
        {
            LvFileInfo ret = new LvFileInfo();
            string tempPath = Path.GetTempPath(); //C:\Users\hkylidis\AppData\Local\Temp\
            try
            {
                if (!Directory.Exists(tempPath))
                {
                    MessageBox.Show("Σφάλμα. Παρακαλώ ελέγξτε τα δικαιώματά σας στο " + tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
            string SelectSt = "SELECT [Filename], [FileCont] FROM [dbo].[SampleFiles] WHERE ExtraDataId = @ExtraDataId and Filename = @Filename ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            try
            {
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@ExtraDataId", Id);
                cmd.Parameters.AddWithValue("@Filename", Filename);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string realFileName = reader["Filename"].ToString().Trim();
                    //string tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + realFileName);
                    //temp file -> attachment name with temp name and tilda 'tmp123~ΦΕΚ123.pdf'
                    string tempFile = Path.Combine(tempPath, realFileName);
                    try
                    {
                        File.WriteAllBytes(tempFile, (byte[])reader["FileCont"]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την προσωρινή αποθήκευση του συδεδεμένου Αρχείου: '" + realFileName +
                            "'\r\n\r\n\r\nΛεπτομέρειες:\r\n" + ex.Message);
                        try
                        {
                            tempFile = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + "~" + realFileName);
                            File.WriteAllBytes(tempFile, (byte[])reader["FileCont"]);

                            MessageBox.Show("Προσοχή! Το αρχείο θα αποθηκευτεί με όνομα: " + tempFile);
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show("Προσοχή! Το αρχείο " + realFileName + " δε θα αποθηκευτεί!");
                        }

                    }

                    ret = new LvFileInfo { FileName = realFileName, FilePath = tempFile };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
                return ret;
            }

            return ret;
        }
        
        private bool InertIntoTable_SampleFiles(int Id, string fileName, byte[] fileBytes) //INSERT [dbo].[SampleFiles]
        {
            bool ret = false;

            if (Id > 0 && fileName.Trim().Length > 0)
            {
                SqlConnection sqlConn = new SqlConnection(SqlDBInfo.connectionString);
                string InsSt = "INSERT INTO [dbo].[SampleFiles] (ExtraDataId, Filename, FileCont) VALUES (@ExtraDataId, @Filename, @FileCont) ";
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(InsSt, sqlConn);
                    cmd.Parameters.AddWithValue("@ExtraDataId", Id);
                    cmd.Parameters.AddWithValue("@Filename", fileName); 
                    cmd.Parameters.Add("@FileCont", SqlDbType.VarBinary).Value = fileBytes;
                    cmd.CommandType = CommandType.Text;
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }

            return ret;
        }



    }

    public class LvFileInfo
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

}
