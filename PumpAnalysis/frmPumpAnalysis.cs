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

                json_filename = json_Path.Substring(json_Path.LastIndexOf("/"));
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς επεξεργασία! \r\n" +
                                "Αρχείο: " + json_Path);
            }



            //check: 2nd time import of the same file ??

            //import the whole file into sql DB table - imported group

            



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();

            if (objList.Count > 0)
            {
                bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(objList, json_filename);

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
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς καταχώρηση!");
            }
        }
    }
}
