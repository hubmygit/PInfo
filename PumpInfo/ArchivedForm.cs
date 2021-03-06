﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;
using Maps;

namespace PumpInfo
{
    public partial class ArchivedForm : Form
    {
        public ArchivedForm()
        {
            InitializeComponent();

            //archivedDataList = DbUtilities.ArchivedData(); //old
            archivedDataList = DbUtilities.ArchivedSyncData();

            //add: saved locally but not yet archived records 
            List<ArchivedData> savedLocallyDataList = DbUtilities.SavedLocallySyncData();
            archivedDataList.AddRange(savedLocallyDataList);

            //archivedDataList = archivedDataList.Distinct().ToList();
            archivedDataList = archivedDataList.GroupBy(i => new { i.Address, i.Brand, i.Dealer, i.Density, i.Driver, i.Dt, i.GeostationId,
                                                                   i.Product, i.Pump, i.PumpVolume,i.Remarks, i.SampleNo, i.Temp, i.VehicleNo,
                                                                   i.VolDiff, i.Volume, i.Weight, i.AmbientTemp }).Select(group => group.First()).ToList();

            cbVehicle.SelectedIndex = 0;
            cbDrivers.SelectedIndex = 0;
            cbDealer.SelectedIndex = 0;
            DateTime dtToday = DateTime.Now.Date;
            dtFrom.Value = new DateTime(dtToday.Year, dtToday.Month, 1).AddMonths(-1);

            List<string> dealerList = new List<string>();
            foreach (ArchivedData archData in archivedDataList)
            {
                dealerList.Add(archData.Dealer);
                //cbDealer.Items.Add(archData.Dealer);
            }
            //dealerList.Distinct().OrderBy(i => i);
            cbDealer.Items.AddRange(dealerList.Distinct().OrderBy(i => i).ToArray());

            //cbDrivers.Items.AddRange(machinesList.Select(i=>i.UserName).ToArray());
            cbDrivers.Items.AddRange(archivedDataList.Select(i => i.Driver).Distinct().OrderBy(i => i).ToArray());

            applyFilterEvents = true;
            ApplyFilters();

            //List<object[]> objList = GridViewUtils.ArchivedDataToObjectList(archivedDataList);
            //GridViewUtils.ShowDataToDataGridView(dgvReceiptData, objList);
            //dgvReceiptData.ClearSelection();
        }

        //List<ImpData> archivedDataList = new List<ImpData>(); //old
        List<ArchivedData> archivedDataList = new List<ArchivedData>();
        //List<Machines> machinesList = DbUtilities.GetSqliteMachinesList();
        bool applyFilterEvents = false;

        private void ApplyFilters()
        {
            if (applyFilterEvents == false)
            {
                return;
            }

            //List<ImpData> NewList = archivedDataList; //old
            List<ArchivedData> NewList = archivedDataList;

            int cbVehicleIndex = cbVehicle.SelectedIndex;
            int cbDriversIndex = cbDrivers.SelectedIndex;
            int cbDealerIndex = cbDealer.SelectedIndex;

            if (cbVehicleIndex > 0) //all
            {
                NewList = NewList.Where(i => i.VehicleNo == cbVehicleIndex).ToList(); //1.Βενζίνη 2.Diesel
            }

            if (cbDriversIndex > 0) //all
            {
                NewList = NewList.Where(i => i.Driver == cbDrivers.SelectedItem.ToString()).ToList(); //1.Βασίλης 2.Ιωσήφ
            }

            if (cbDealerIndex > 0) //all
            {
                NewList = NewList.Where(i => i.Dealer == cbDealer.SelectedItem.ToString()).ToList(); //dealers...
            }

            DateTime dtFromDate = dtFrom.Value.Date;
            DateTime dtToDate = dtTo.Value.Date;

            NewList = NewList.Where(i => i.Dt >= dtFromDate && i.Dt <= (dtToDate.AddDays(1))).ToList();

            //---------------------

            List<object[]> objList = GridViewUtils.ArchivedDataToObjectList(NewList);
            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, objList);

            RowsForeColorFromVolDiff(dgvReceiptData);

            dgvReceiptData.ClearSelection();
        }


        private void cbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnGeostation_Click(object sender, EventArgs e)
        {
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                int geostId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["GeostationId"].Value.ToString().Trim());

                ////--in case we need coordinates -->
                //Coordinates Coo = DbUtilities.GetGeostationLatLong(geostId);
                //String DecSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                //if (DecSep == ",")
                //{
                //    Coo.latitude = Coo.latitude.Replace('.', ',');
                //    Coo.longitude = Coo.longitude.Replace('.', ',');
                //}
                //else
                //{
                //    Coo.latitude = Coo.latitude.Replace(',', '.');
                //    Coo.longitude = Coo.longitude.Replace(',', '.');
                //}
                ////--in case we need coordinates <--

                MapFormParams MapObj = new MapFormParams()
                {
                    latitude = 0, 
                    longitude = 0, 
                    radius = 350, //meters
                    apiKey = MapsApi.key, //"AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo"
                    connectionString = SQLiteDBMap.connectionString, //Stationsdb.db
                    existsInternetConnection = NetworkConnections.CheckInternetConnection()
                };

                Form2 frmMap = new Form2(MapObj, geostId);
                frmMap.ShowDialog();

                frmMap.Dispose_gMap();
            }
        }

        private void RowsForeColorFromVolDiff(DataGridView dgv)
        {
            if (!cbColorMode.Checked)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        dgv.Rows[i].DefaultCellStyle.ForeColor = new System.Drawing.Color(); //default: ControlText;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                double diffPercVal = 0.0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        diffPercVal = Convert.ToDouble(dgv["VolDiff", i].Value);

                        if (diffPercVal < -0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else if (diffPercVal > 0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                        }
                        else if (diffPercVal >= 0 && diffPercVal <= 0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        else if (diffPercVal < 0 && diffPercVal >= -0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Orange;
                        }

                        //dgv.DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }

        private void cbColorMode_CheckedChanged(object sender, EventArgs e)
        {
            RowsForeColorFromVolDiff(dgvReceiptData);
        }

        private void cbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            DateTime dtFromDate = dtFrom.Value.Date;
            DateTime dtToDate = dtTo.Value.Date;

            ShowMyReceipts myRecFrm = new ShowMyReceipts(dtFromDate, dtToDate);
            myRecFrm.ShowDialog();
        }

        private void btnKms_Click(object sender, EventArgs e)
        {
            DateTime dtFromDate = dtFrom.Value.Date;
            DateTime dtToDate = dtTo.Value.Date;

            ShowMyKms myKmsFrm = new ShowMyKms(cbVehicle.SelectedIndex, dtFromDate, dtToDate);
            myKmsFrm.ShowDialog();
        }
    }
}
