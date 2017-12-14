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

            List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);
            List<ImpData> objList = dbu.GetDataNotExistsInSQLSrvTable(DataToMigrate);

            if (objList.Count > 0)
            {
                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);

                GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς επεξεργασία! \r\n" +
                                "Αρχείο: " + json_Path);
            }


            //if (objList.Count > 0)
            //{
            //    //List<object[]> aaa = GridViewUtils.ImpJsonDataListToGridViewRowList(objList);
            //}
            //else
            //{
            //    MessageBox.Show("Προσοχή! Δε βρέθηκαν εγγραφές στο αρχείο.");
            //}

            //?? show to grid

            //?? 2nd import of the same file ??

            //import txt file as blob into sqlite
            //import the whole file into sql DB table - imported group

            /*
            bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(DataToMigrate, read_data);
            if (insSuccess == false)
            {
                MessageBox.Show("Η διαδικασία ολοκληρώθηκε με σφάλματα!");
            }
            else
            {
                MessageBox.Show("Η διαδικασία ολοκληρώθηκε επιτυχώς!");
            }
            */


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
