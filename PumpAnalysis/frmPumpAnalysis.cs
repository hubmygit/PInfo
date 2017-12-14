using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        byte[] fileBytes;
        private void btnImport_Click(object sender, EventArgs e)
        {
            
            DbUtilities dbu = new DbUtilities();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON files (*.json)|*.json";
            DialogResult result = ofd.ShowDialog();

            string json_Path = ofd.FileName;
            if (json_Path.Trim() == "" || result != DialogResult.OK)
            {
                return;
            }


            string read_data = dbu.getAllDataFromJsonFile(json_Path);

            if (read_data.Trim() == "")
            {
                return;
            }

            //get byte[] ready to import into table

            List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);
            objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

            if (objList.Count > 0)
            {
                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);

                GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

                json_filename = json_Path.Substring(json_Path.LastIndexOf("\\") + 1);

                //get file contents as byte[]
                fileBytes = System.IO.File.ReadAllBytes(json_Path); 
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς επεξεργασία! \r\n" +
                                "Αρχείο: " + json_Path);
            }



            

            



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            if (objList.Count > 0)
            {
                //import the whole file into sql DB table - imported group
                bool success = dbu.InertImportedFileIntoTable(json_filename, fileBytes);
                if (!success)
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατά την καταχώρηση του αρχείου " + json_filename);
                    return;
                }

                //get max id 
                int ImportedGroupId = dbu.getMaxImportedGroupId(json_filename);

                if (ImportedGroupId < 0) //error: -1
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατά την εύρεση του καταχωρημένου αρχείου.");
                    return;
                }

                bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(objList, ImportedGroupId);

                if (insSuccess)
                {
                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε επιτυχώς!");
                }
                else
                {
                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε με σφάλματα!");
                }

                //refresh? / close form?
                dgvReceiptData.Rows.Clear();
                objList.Clear();
                Array.Clear(fileBytes, 0, fileBytes.Length);
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς καταχώρηση!");
            }
        }
    }
}
