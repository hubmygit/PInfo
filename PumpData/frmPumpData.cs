﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PumpData
{
    public partial class frmPumpData : Form
    {
        public frmPumpData()
        {
            InitializeComponent();
        }

        private void btnShowDbData_Click(object sender, EventArgs e)
        {
            frmShowDbData frmDbData = new frmShowDbData();
            frmDbData.ShowDialog();
        }

        private void btnShowConsumption_Click(object sender, EventArgs e)
        {
            frmVehicleTrace frmVehicleTrace = new frmVehicleTrace();
            frmVehicleTrace.ShowDialog();
        }

        private void btnStationScheduler_Click(object sender, EventArgs e)
        {
            StationScheduler frmScheduler = new StationScheduler();
            frmScheduler.ShowDialog();
        }

        private void btnExportToSqlite_Click(object sender, EventArgs e)
        {

        }
    }
}
