using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;

namespace PumpInfo
{
    public partial class frmPumpInfo : Form
    {
        public frmPumpInfo()
        {
            InitializeComponent();
        }

        public List<ImpData> objList = new List<ImpData>();

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            string receiptFile_Path = ofd.FileName;
            if (receiptFile_Path.Trim() == "" || result != DialogResult.OK)
            {
                return;
            }

            DbUtilities DBU = new DbUtilities(receiptFile_Path);

            List<ImpData> receiptObjList = DBU.FillListFromReceipt();

            objList = DBU.GetDataNotExistsInSQLiteTable(receiptObjList);

            if (objList.Count > 0)
            {
                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);

                GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

                //bool successfulInsertion = DBU.InsertReceiptAllDataIntoSQLiteTable(objList);
            }
            else
            {
                MessageBox.Show("Δε βρέθηκαν εγγραφές προς επεξεργασία! \r\n" + 
                                "Αρχείο: " + receiptFile_Path);
            }
        }

        private void dgvReceiptData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //MessageBox.Show("Row: " + e.RowIndex.ToString() + ", Column: " + e.ColumnIndex.ToString());
                
                int itemIndex = GridViewUtils.getItemIndex(dgvReceiptData, e.RowIndex);
                //bool accepted = (bool)dgvReceiptData.Rows[e.RowIndex].Cells["Accepted"].Value;
                ImpData selectedItem = objList.Find(i => i.dataGridViewRowIndex == itemIndex);
                                
                AcceptanceForm frmAcceptance = new AcceptanceForm(selectedItem);
                frmAcceptance.ShowDialog();


                //1. refresh objList => is reference, so it's updated!
                //objList.Find(i => i.dataGridViewRowIndex == itemIndex).copyExtraData(frmAcceptance.obj);//selectedItem

                //2. changes to database => other button
                //if (frmAcceptance.recordAction == RecordAction.Insert || frmAcceptance.recordAction == RecordAction.Update)
                //{
                //}
                //else if (frmAcceptance.recordAction == RecordAction.Delete)
                //{
                //}

                //3 & 4 => update only checkbox of clicked row
                //3. create new List<object[]> 
                //List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);
                //4. refresh dataGridView
                //GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
                dgvReceiptData["Accepted", e.RowIndex].Value = selectedItem.accepted;



            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //objList To SQLite DB
            DbUtilities dbu = new DbUtilities();

            if (objList.Count > 0)
            {
                bool insSuccess = dbu.InsertReceiptAllDataIntoSQLiteTable(objList);

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int acceptedCnt = objList.Count(i => i.accepted == true);

            if (acceptedCnt > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να κλείσετε την εφαρμογή;\r\n" + 
                                                            "Τα δεδομένα που έχετε αποθηκεύσει σε " + acceptedCnt.ToString() + " εγγραφές θα χαθούν!", 
                                                            "Έξοδος", MessageBoxButtons.YesNo);

                e.Cancel = (dialogResult == DialogResult.No);
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();
            int exportedGroupId = dbu.GetMaxReceiptData_ExportedGroupId();

            int nextExportedGroupId = -1;

            if (exportedGroupId >= 0) //nulls || maxId
            {
                if (exportedGroupId == 0)
                {
                    nextExportedGroupId = dbu.GetMaxExportedGroupId() + 1;
                }
                else
                {
                    nextExportedGroupId = exportedGroupId;
                }

                List<ImpData> DataToMigrate = dbu.ReceiptDataLines_To_ObjectList(exportedGroupId, nextExportedGroupId);

                string jsonData = dbu.ObjectListToJson(DataToMigrate);

                string jsonFile = dbu.createJsonFile(jsonData);

                if (exportedGroupId == 0) //nulls
                {
                    dbu.InsertExportedGroupLineIntoSQLiteTable(jsonFile);
                    dbu.UpdateReceiptData_ExportedGroupId(nextExportedGroupId);
                }

            }
            else //no data found
            {
                MessageBox.Show("Προσοχή! Δε βρέθηκαν εγγραφές για εξαγωγή!");
            }


        }
    }
}
