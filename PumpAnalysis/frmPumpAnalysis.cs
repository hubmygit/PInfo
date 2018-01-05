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
                                "Αρχείο: " + json_path);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            //********************************************ToDo: insert and get id! 2 steps insert*******************************************
            //import the whole file into sql DB table - imported group
            bool success = dbu.InsertImportedFileIntoTable(json_filename, fileBytes, counters, true);
            if (!success)
            {
                MessageBox.Show("Προσοχή! Σφάλμα κατά την καταχώρηση του αρχείου " + json_filename);
                return;
            }
            
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
                    System.IO.File.Move(json_path, Application.StartupPath + "//Export//" + json_filename);
                }
                catch (Exception ex)
                {
                    Output.WriteToFile(ex.Message, true);
                    insSuccess = false;
                }

                if (insSuccess)
                {
                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε επιτυχώς!");

                    //update....flag SUCCESS = 1
                }
                else
                {
                    MessageBox.Show("Η καταχώρηση ολοκληρώθηκε με σφάλματα!");
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

        private void button1_Click(object sender, EventArgs e)
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

                int help = 0;
            }
            
        }
    }

    
}

