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

            ExpCounterToLblText(lblCountExported);
        }

        public List<ImpData> objList = new List<ImpData>();

        private void ExpCounterToLblText(Label lbl)
        {
            lbl.Text = "Εγγραφές : " + new DbUtilities().CountReceiptData_ExportedGroupId().ToString();
        }

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


                // ***** Km - VehicleTrace *****
                //-----------------------------------------------------------------------------------------------------
                //List<ImpData> SortedData = objList.OrderBy(i => i.strDt).ToList();
                //foreach (ImpData thisImpdata in SortedData)
                //{
                    //SELECT distinct strftime('%Y%m', r.dt), strftime('%Y', r.dt), strftime('%m', r.dt), 
                    //       (select min(r2.dt) from receiptData r2 where strftime('%Y%m', r2.dt) = strftime('%Y%m', r.dt)),
                    //       (select max(r2.dt) from receiptData r2 where strftime('%Y%m', r2.dt) = strftime('%Y%m', r.dt)) 
                    //FROM [receiptData] r

                    //int Exp_VehicleNo = thisImpdata.vehicleNo;
                    //DateTime Exp_Dt = Convert.ToDateTime(thisImpdata.strDt);
                    //int year = Exp_Dt.Year;
                    //int month = Exp_Dt.Month;
                //}
                //int ExportedDataVehicle = DataToMigrate[0].vehicleNo;
                //List<int> distinctMonths = DataToMigrate.Select(i => i.datetime.Month).Distinct().ToList();

                // SELECT VehicleNo, LastDt FROM [VehicleTrace] ORDER BY LastDt desc
                // get last VehicleNo from VehicleTrace order by lastDt
                //-----------------------------------------------------------------------------------------------------



                //refresh? / close form?
                dgvReceiptData.Rows.Clear();
                objList.Clear();

                ExpCounterToLblText(lblCountExported);
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

                    if (dgvReceiptData.RowCount > 0)
                    {
                        MessageBox.Show("Δεν έχουν αποθηκευτεί εγγραφές που επεξεργάζεστε. Η εξαγωγή θα πραγματοποιηθεί με τις αποθηκευμένες εγγραφές.");
                    }
                    
                }
                else
                {
                    nextExportedGroupId = exportedGroupId;

                    if (dgvReceiptData.RowCount > 0)
                    {
                        MessageBox.Show("Δεν έχουν αποθηκευτεί εγγραφές που επεξεργάζεστε. Η εξαγωγή θα πραγματοποιηθεί με τις πιό πρόσφατες εγγραφές που έχουν αποθηκευτεί.");
                    }
                    else
                    {
                        MessageBox.Show("Δεν υπάρχουν νέες εγγραφές. Η εξαγωγή θα πραγματοποιηθεί με τις πιό πρόσφατες εγγραφές που έχουν αποθηκευτεί.");
                    }
                    

                    
                }

                List<ImpData> DataToMigrate = dbu.ReceiptDataLines_To_ObjectList(exportedGroupId, nextExportedGroupId);

                string jsonData = dbu.ObjectListToJson(DataToMigrate);
                                
                //string jsonFile = dbu.createJsonFile(jsonData);
                string jsonFile = dbu.createDefaultJsonFile(jsonData);

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

            ExpCounterToLblText(lblCountExported);
        }
    }
}
