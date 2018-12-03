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

            frmContextMenuStrip.Items.Add("Configuration (System Parameters)");
            frmContextMenuStrip.Click += new EventHandler(frmContextMenuStrip_Click);
            this.ContextMenuStrip = frmContextMenuStrip;
            
            ExpCounterToLblText(lblCountExported); 
        }

        private ContextMenuStrip frmContextMenuStrip = new ContextMenuStrip();

        public List<ImpData> objList = new List<ImpData>();


        void frmContextMenuStrip_Click(object sender, EventArgs e)
        {
            frmConfig frmConf = new frmConfig();
            frmConf.ShowDialog();
        }

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
            //receiptObjList = DBU.ReceiptDBLines_To_ObjectList(); //Only for Testing get data from receipt 

            objList = DBU.GetDataNotExistsInSQLiteTable(receiptObjList);

            if (objList.Count > 0)
            {
                List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);

                GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
                dgvReceiptData.ClearSelection();

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
                frmAcceptance.ShowDialog(this);


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
                double receiptSum = objList.Sum(i => i.receiptPrice);

                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να αποθηκεύσετε όλες τις εγγραφές; \r\n" +
                "Προσοχή! Μετά την αποθήκευση δεν θα μπορείτε πλέον να εμφανίσετε και να επεξεργαστείτε τις εγγραφές!\r\n" + 
                "(Συνολικό ποσό αποδείξεων: " + receiptSum.ToString() + " €)", "Αποθήκευση", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool insSuccess = dbu.InsertReceiptAllDataIntoSQLiteTable(objList);
                    
                    dbu.Update_TimeDependData_ClosedStations(objList);
                    
                    
                    // ***** Km - VehicleTrace *****
                    // VehicleTrace -->
                    string haveData_YearMonthDay = "";
                    int machNo = dbu.getInstId();
                    foreach (ImpData thisLine in objList.OrderBy(i=>i.datetime).ToList())
                    {
                        thisLine.machineNo = machNo;
                        //if (thisLine.datetime.ToString("yyyyMM") != haveData_YearMonth) 
                        //if (thisLine.datetime.ToString("yyyyMMdd") != haveData_YearMonthDay) // && thisLine.accepted == true) ????
                        if (thisLine.datetime.ToString("yyyyMMdd") != haveData_YearMonthDay && thisLine.accepted == true) 
                        {
                            //Give final Km  -> new Form
                            frmSetKm setKmForm = new frmSetKm(thisLine);
                            setKmForm.ShowDialog();

                            int KmFrom = Convert.ToInt32(setKmForm.txtKmFrom.Text);
                            int KmTo = Convert.ToInt32(setKmForm.txtKmTo.Text);

                            if (!dbu.InsertInto_VehicleTrace(thisLine, KmFrom, KmTo))
                            {
                                insSuccess = false;
                            }

                            haveData_YearMonthDay = thisLine.datetime.ToString("yyyyMMdd");
                        }
                    }
                    // VehicleTrace <--

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

                    ExpCounterToLblText(lblCountExported);
                }
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

                // VehicleTrace -->
                List<int> DistinctProcessGroupIds = DataToMigrate.Select(i => i.processedGroupId).Distinct().ToList();
                List<VehicleTrace> VehicleTraceToMigrate = dbu.Get_VehicleTrace_Data(DistinctProcessGroupIds);

                //DateTime fromDate = DataToMigrate.Min(i => i.datetime);
                DateTime fromDate = new DateTime();

                if (DataToMigrate.Exists(i => i.accepted == true))
                {
                    fromDate = DataToMigrate.Where(i => i.accepted == true).Min(i => i.datetime);
                }
                else
                {
                    fromDate = DataToMigrate.Min(i => i.datetime);
                }
                DateTime toDate = DateTime.Now; //DataToMigrate.Max(i => i.datetime);

                List<Station> StationsToMigrate = dbu.Get_Station_Data(fromDate, toDate);


                ImpData_And_VehicleTrace newDataToMigrate = new ImpData_And_VehicleTrace();
                newDataToMigrate.impData = DataToMigrate;
                newDataToMigrate.vehicleTrace = VehicleTraceToMigrate;
                newDataToMigrate.stationData = StationsToMigrate;
                string newJsonData = dbu.ObjectListToJson(newDataToMigrate);
                // VehicleTrace <--



                //string jsonData = dbu.ObjectListToJson(DataToMigrate);

                //string jsonFile = dbu.createJsonFile(jsonData);
                //string jsonFile = dbu.createDefaultJsonFile(jsonData);
                string jsonFile = dbu.createDefaultJsonFile(newJsonData);

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

        private void dgvReceiptData_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "Date")
            {
                e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd"),
                                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd"));

                if (e.SortResult == 0 && e.Column.Name != "Time")
                {
                    e.SortResult = System.String.Compare(dgvReceiptData.Rows[e.RowIndex1].Cells["Time"].Value.ToString(),
                                                         dgvReceiptData.Rows[e.RowIndex2].Cells["Time"].Value.ToString());
                }

                e.Handled = true;
            }

        }

        private void btnArchived_Click(object sender, EventArgs e)
        {
            ArchivedForm ArchFrm = new ArchivedForm();
            ArchFrm.ShowDialog();
        }

        private void btnSynchDbs_Click(object sender, EventArgs e)
        {
            SyncDbs SuncFrm = new SyncDbs();
            SuncFrm.ShowDialog();
        }

        private void btnScheduler_Click(object sender, EventArgs e)
        {
            Scheduler frmSch = new Scheduler();
            frmSch.ShowDialog();
        }

        private void btnClosedGasStation_Click(object sender, EventArgs e)
        {
            /*
            if (objList.Count > 0)
            {
                ClosedGasStation frmClosedGS = new ClosedGasStation();
                DialogResult dlgRes = frmClosedGS.ShowDialog();

                if (dlgRes == DialogResult.OK || dlgRes == DialogResult.Yes)
                {
                    //String DecSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    //if (DecSep == ",")
                    //{
                    //    frmClosedGS.coo.latitude = frmClosedGS.coo.latitude.Replace('.', ',');
                    //    frmClosedGS.coo.longitude = frmClosedGS.coo.longitude.Replace('.', ',');
                    //}
                    //else
                    //{
                    //    frmClosedGS.coo.latitude = frmClosedGS.coo.latitude.Replace(',', '.');
                    //    frmClosedGS.coo.longitude = frmClosedGS.coo.longitude.Replace(',', '.');
                    //}

                    //same as file...don't check 'CultureInfo'
                    frmClosedGS.coo.latitude = frmClosedGS.coo.latitude.Replace(',', '.');
                    frmClosedGS.coo.longitude = frmClosedGS.coo.longitude.Replace(',', '.');

                    ImpData newObj = new ImpData()
                    {
                        accepted = true,
                        address = frmClosedGS.txtAddress.Text,
                        brand = DbUtilities.getComboboxItem_Brand(frmClosedGS.cbBrand), //user input
                        coordinates = frmClosedGS.coo, //user input
                        dataGridViewRowIndex = objList.Count,
                        date = frmClosedGS.dt_date, //user input
                        datetime = frmClosedGS.dt, //user input
                        dealer = frmClosedGS.txtDealer.Text, //user input
                        density = 0,
                        geostationId = Convert.ToInt32(frmClosedGS.lblGeostationId.Text), //user input
                        //machineNo = objList[0].machineNo,
                        position = frmClosedGS.coo.latitude + " " + frmClosedGS.coo.longitude,
                        product = DbUtilities.GetProductsList(objList[0].vehicleNo)[0], //get first record's product
                        pump = "0/0/0",
                        pumpVolume = 0,
                        realCoordinates = frmClosedGS.coo, //user input
                        //receiptNo = "",
                        //receiptPrice = 0
                        remarks = frmClosedGS.txtRemarks.Text,
                        //sampleNo = 0,
                        temp = 0,
                        time = frmClosedGS.dt_time, //user input
                        vehicleNo = objList[0].vehicleNo, //get first record's vehicle
                        volume = 0,
                        weight = 0,

                        station_Closed_Manually = true

                    };



                    objList.Add(newObj);
                   
                    dgvReceiptData.Rows.Add(GridViewUtils.ImpDataToGridViewRow(newObj));
                    //dgvReceiptData.ClearSelection();

                }
                
            }
            */          
        }

        private void btnSchedulerByDriver_Click(object sender, EventArgs e)
        {
            SchedulerByDriver frmSchDr = new SchedulerByDriver();
            frmSchDr.ShowDialog();
        }

    }
}
