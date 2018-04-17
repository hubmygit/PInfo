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
    public partial class ShowMyKms : Form
    {
        public ShowMyKms()
        {
            InitializeComponent();
        }

        public ShowMyKms(int VehicleIndex, DateTime FromDt, DateTime ToDt)
        {
            InitializeComponent();

            dtFrom.Value = FromDt;
            dtTo.Value = ToDt;
            cbVehicle.SelectedIndex = VehicleIndex;

            applyFilterEvents = true;
            ApplyFilters();
        }

        List<Kilometers> KmsList = new DbUtilities().getKilometers();
        bool applyFilterEvents = false;

        private void ApplyFilters()
        {
            if (applyFilterEvents == false)
            {
                return;
            }

            List<Kilometers> filteredKmsList = KmsList;

            DateTime dtFromDate = dtFrom.Value.Date;
            DateTime dtToDate = dtTo.Value.Date;

            int VehicleIndex = cbVehicle.SelectedIndex;

            if (VehicleIndex > 0) //all
            {
                filteredKmsList = filteredKmsList.Where(i => i.VehicleNo == VehicleIndex).ToList(); //1.Βενζίνη 2.Diesel
            }


            //filteredKmsList = filteredKmsList.Where(i => i.Dt >= dtFromDate && i.Dt <= dtToDate.AddDays(1)).ToList();
            filteredKmsList = filteredKmsList.Where(i => i.Dt >= dtFromDate && i.Dt <= dtToDate).ToList();


            dgvKms.Rows.Clear();

            foreach (Kilometers thisRec in filteredKmsList)
            {
                dgvKms.Rows.Add(new object[] { thisRec.VehicleNo, thisRec.ProductGroup, thisRec.Dt.ToString("dd.MM.yyyy"), thisRec.KmFrom, thisRec.KmTo });
            }

            dgvKms.ClearSelection();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
