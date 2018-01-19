using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using PumpLib;

namespace PumpAnalysis
{
    public partial class frmPumpAnalysis : Form
    {
        public frmPumpAnalysis()
        {
            InitializeComponent();          
        }

        public List<ImpData> objList = new List<ImpData>();
        public string json_filename;
        public string json_path;
        byte[] fileBytes;
        RowsCounter counters = new RowsCounter();
        private void btnImport_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON files (*.json)|*.json";
            DialogResult result = ofd.ShowDialog();

            json_path = ofd.FileName;
            if (json_path.Trim() == "" || result != DialogResult.OK)
            {
                return;
            }

            //init
            lblImpFile.Text = "Αρχείο: -";
            objList.Clear();
            dgvReceiptData.Rows.Clear();
            json_filename = "";
            //json_path = "";
            if (fileBytes != null)
            {
                Array.Clear(fileBytes, 0, fileBytes.Length);
            }
            counters.Clear();

            Output.WriteToFile("***** STARTING... *****");
            Output.WriteToFile("-- Import Function --");

            Output.WriteToFile("Filename: " + json_path);

            string read_data = dbu.getAllDataFromJsonFile(json_path);

            if (read_data.Trim() == "")
            {
                Output.WriteToFile("Empty file!");
                return;
            }

            //get byte[] ready to import into table

            List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);

            counters.fileRows = DataToMigrate.Count;
            counters.fileAccRows = DataToMigrate.Count(i => i.accepted == true);
            counters.fileNAccRows = DataToMigrate.Count(i => i.accepted == false);
            
            Output.WriteToFile("Rows in file: " + counters.fileRows.ToString());
            Output.WriteToFile("File - Accepted=true Rows: " + counters.fileAccRows.ToString() + ", Accepted=false Rows: " + counters.fileNAccRows.ToString());
            
            objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

            counters.toSaveRows = objList.Count;
            Output.WriteToFile("Rows to save: " + objList.Count.ToString());

            json_filename = json_path.Substring(json_path.LastIndexOf("\\") + 1);

            //get file contents as byte[]
            fileBytes = System.IO.File.ReadAllBytes(json_path);

            if (objList.Count > 0)
            {
                counters.toSaveAccRows = objList.Count(i => i.accepted == true);
                counters.toSaveNAccRows = objList.Count(i => i.accepted == false);

                Output.WriteToFile("To save - Accepted=true Rows: " + counters.toSaveAccRows.ToString() + ", Accepted=false Rows: " + counters.toSaveNAccRows.ToString());

                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList, true);

                GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
                
                lblImpFile.Text = "Αρχείο: " + json_filename;                
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς επεξεργασία! \r\n" +
                                "Παρακαλώ μετακινήστε στο φάκελο αρχειοθέτησης το αρχείο " + json_path + ".");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            Output.WriteToFile("-- Save Function --");

            if (json_filename == null || fileBytes == null)
            {
                Output.WriteToFile("No File to save.", true);
                MessageBox.Show("Δεν έχετε επιλέξει αρχείο προς αποθήκευση!");
                return;
            }


            //import the whole file into sql DB table - imported group
            bool success = dbu.InsertImportedFileIntoTable(json_filename, fileBytes, counters, true);
            if (!success)
            {
                MessageBox.Show("Προσοχή! Σφάλμα κατά την καταχώρηση του αρχείου " + json_filename);
                return;
            }
            Output.WriteToFile("Saved file: " + json_filename);
            
            if (objList.Count > 0)
            {
                //get max id 
                int ImportedGroupId = dbu.getMaxImportedGroupId(json_filename);
                if (ImportedGroupId <= 0) //error: -1 (& 0 -> id starts from 1...)
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατά την εύρεση του καταχωρημένου αρχείου.");
                    return;
                }
                Output.WriteToFile("ImportedGroupId: " + ImportedGroupId.ToString());

                bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(objList, ImportedGroupId);

                try
                {
                    System.IO.File.Move(json_path, Application.StartupPath + "\\Archive\\" + json_filename);
                    Output.WriteToFile("File moved to 'Archive' folder");
                }
                catch (Exception ex)
                {
                    Output.WriteToFile(ex.Message, true);
                    insSuccess = false;
                }

                if (insSuccess)
                {
                    dbu.update_ImportedGroup_Table(ImportedGroupId);

                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε επιτυχώς!");
                    Output.WriteToFile("***** FINISHED... *****");
                }
                else
                {
                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε με σφάλματα!");
                    Output.WriteToFile("***** FINISHED WITH ERRORS... *****");
                }

                //refresh? / close form?
                dgvReceiptData.Rows.Clear();
                objList.Clear();
                Array.Clear(fileBytes, 0, fileBytes.Length);
                lblImpFile.Text = "Αρχείο: -";
                json_filename = "";
                counters.Clear();

            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς καταχώρηση!");
            }
        }

        private void AutomaticProcedure()
        {
            Output.WriteToFile("***** STARTING... *****");

            //get all json files from folder
            string targetDirectory = Application.StartupPath + "\\Import";
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.json");

            Output.WriteToFile(fileEntries.Length + " file(s) found.");

            int cnt = 0;

            foreach (string fileName in fileEntries)
            {
                cnt++;
                Output.WriteToFile("Starting - File " + cnt.ToString() + "/" + fileEntries.Length);

                //init
                lblImpFile.Text = "Αρχείο: -";
                objList.Clear();
                json_filename = "";
                if (fileBytes != null)
                {
                    Array.Clear(fileBytes, 0, fileBytes.Length);
                }
                counters.Clear();

                DbUtilities dbu = new DbUtilities();
                json_path = fileName;
                Output.WriteToFile("Filename: " + json_path);

                string read_data = dbu.getAllDataFromJsonFile(json_path);
                //get file contents as byte[]
                fileBytes = System.IO.File.ReadAllBytes(json_path);

                json_filename = json_path.Substring(json_path.LastIndexOf("\\") + 1);

                //import the whole file into sql DB table - imported group
                bool success = dbu.InsertImportedFileIntoTable(json_filename, fileBytes, counters, false);
                Output.WriteToFile("Saved file: " + json_filename);

                try
                {
                    System.IO.File.Move(json_path, Application.StartupPath + "\\Archive\\" + json_filename);
                    Output.WriteToFile("File moved to 'Archive' folder");
                }
                catch (Exception ex)
                {
                    Output.WriteToFile(ex.Message, true);
                }

                if (!success)
                {
                    continue;
                }
                
                if (read_data.Trim() == "")
                {
                    Output.WriteToFile("Empty file!");
                    continue;
                }

                //get max id 
                int ImportedGroupId = dbu.getMaxImportedGroupId(json_filename);
                if (ImportedGroupId <= 0) //error: -1 (& 0 -> id starts from 1...)
                {
                    continue;
                }
                Output.WriteToFile("ImportedGroupId: " + ImportedGroupId.ToString());

                List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);

                counters.fileRows = DataToMigrate.Count;
                counters.fileAccRows = DataToMigrate.Count(i => i.accepted == true);
                counters.fileNAccRows = DataToMigrate.Count(i => i.accepted == false);
                Output.WriteToFile("Rows in file: " + counters.fileRows.ToString());
                Output.WriteToFile("File - Accepted=true Rows: " + counters.fileAccRows.ToString() + ", Accepted=false Rows: " + counters.fileNAccRows.ToString());

                objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

                counters.toSaveRows = objList.Count;
                Output.WriteToFile("Rows to save: " + objList.Count.ToString());

                if (objList.Count > 0)
                {
                    counters.toSaveAccRows = objList.Count(i => i.accepted == true);
                    counters.toSaveNAccRows = objList.Count(i => i.accepted == false);
                }
                Output.WriteToFile("To save - Accepted=true Rows: " + counters.toSaveAccRows.ToString() + ", Accepted=false Rows: " + counters.toSaveNAccRows.ToString());

                bool result = dbu.update_ImportedGroup_Counters(ImportedGroupId, counters);
                Output.WriteToFile("Counters updated.");

                if (objList.Count <= 0)
                {
                    continue;
                }
                
                lblImpFile.Text = "Αρχείο: " + json_filename;
                
                bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(objList, ImportedGroupId);

                if (insSuccess)
                {
                    dbu.update_ImportedGroup_Table(ImportedGroupId);
                }

                Output.WriteToFile("Fineshed - File " + cnt.ToString() + "/" + fileEntries.Length);

                objList.Clear();
                Array.Clear(fileBytes, 0, fileBytes.Length);
                lblImpFile.Text = "Αρχείο: -";
                json_filename = "";
                counters.Clear();                
            }

            Output.WriteToFile("***** FINISHED... *****");

        }

        private void geocodingTest()
        {
            DbUtilities d = new DbUtilities();
            string geo_json_data = d.getAllDataFromJsonFile(@"C:\Users\hkylidis\Desktop\rev_geocoding_el.json");

            GeoCoding a = d.stringToGenericObject<GeoCoding>(geo_json_data);
            if (a.status.ToUpper() == "OK")
            {
                string areaLevel1 = a.results.Where(i => i.types.Contains("administrative_area_level_1")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_1")).FirstOrDefault().long_name;
                string areaLevel2 = a.results.Where(i => i.types.Contains("administrative_area_level_2")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_2")).FirstOrDefault().long_name;
                string areaLevel3 = a.results.Where(i => i.types.Contains("administrative_area_level_3")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_3")).FirstOrDefault().long_name;
                string areaLevel4 = a.results.Where(i => i.types.Contains("administrative_area_level_4")).FirstOrDefault().address_components.Where(i => i.types.Contains("administrative_area_level_4")).FirstOrDefault().long_name;
            }
            
        }

        private void frmPumpAnalysis_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Count(i => i.ToUpper().Trim(new char[] { ' ', '-', '/' }) == "AUTO") > 0)
            {
                AutomaticProcedure();

                Application.Exit();
            }
                        
            
        }

        private void btnShowDbData_Click(object sender, EventArgs e)
        {
            frmShowDbData frmDbData = new frmShowDbData();
            frmDbData.ShowDialog();
        }
    }

    
}

