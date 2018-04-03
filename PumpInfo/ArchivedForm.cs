using System;
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

            cbVehicle.SelectedIndex = 0;
            DateTime dtToday = DateTime.Now.Date;
            dtFrom.Value = new DateTime(dtToday.Year, dtToday.Month, 1).AddMonths(-1);

            applyFilterEvents = true;
            ApplyFilters();

            //List<object[]> objList = GridViewUtils.ArchivedDataToObjectList(archivedDataList);
            //GridViewUtils.ShowDataToDataGridView(dgvReceiptData, objList);
            //dgvReceiptData.ClearSelection();
        }

        //List<ImpData> archivedDataList = new List<ImpData>(); //old
        List<ArchivedData> archivedDataList = new List<ArchivedData>();
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

            if (cbVehicleIndex > 0) //all
            {
                NewList = NewList.Where(i => i.VehicleNo == cbVehicleIndex).ToList(); //1.Βενζίνη 2.Diesel
            }
            
            DateTime dtFromDate = dtFrom.Value.Date;
            DateTime dtToDate = dtTo.Value.Date;

            NewList = NewList.Where(i => i.Dt >= dtFromDate && i.Dt <= (dtToDate.AddDays(1))).ToList();

            //---------------------

            List<object[]> objList = GridViewUtils.ArchivedDataToObjectList(NewList);
            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, objList);
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
    }
}
