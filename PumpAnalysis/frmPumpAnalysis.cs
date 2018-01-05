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

            MessageBox.Show("***** Log [filename: " + json_Path + "] *****");

            string read_data = dbu.getAllDataFromJsonFile(json_Path);

            if (read_data.Trim() == "")
            {
                MessageBox.Show("***** Log [Empty file] *****");
                return;
            }

            //get byte[] ready to import into table

            List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);

            MessageBox.Show("***** Log [Rows in file: " + DataToMigrate.Count.ToString() + "] *****");
            MessageBox.Show("***** Log [Accepted=true Rows: " + DataToMigrate.Count(i=>i.accepted == true).ToString() + ", Accepted=false Rows: " + DataToMigrate.Count(i => i.accepted == false).ToString() + "] *****");

            objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

            MessageBox.Show("***** Log [Rows to save: " + objList.Count.ToString() + "] *****");

            if (objList.Count > 0)
            {
                MessageBox.Show("***** Log [Accepted=true Rows: " + objList.Count(i => i.accepted == true).ToString() + ", Accepted=false Rows: " + objList.Count(i => i.accepted == false).ToString() + "] *****");

                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList, true);

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
                bool success = dbu.InsertImportedFileIntoTable(json_filename, fileBytes);
                if (!success)
                {
                    MessageBox.Show("Προσοχή! Σφάλμα κατά την καταχώρηση του αρχείου " + json_filename);
                    return;
                }

                //get max id 
                int ImportedGroupId = dbu.getMaxImportedGroupId(json_filename);

                if (ImportedGroupId <= 0) //error: -1 (& 0 -> id starts from 1...)
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

