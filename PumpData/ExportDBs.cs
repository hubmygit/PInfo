﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;

namespace PumpData
{
    public partial class ExportDBs : Form
    {
        public ExportDBs()
        {
            InitializeComponent();
        }

        private void btnExportGeoData_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();
            dbu.ExportDB_Geostation(); 
        }

        private void btnExportPumpInfo_Click(object sender, EventArgs e)
        {
            DbUtilities dbu = new DbUtilities();
            dbu.ExportDB_Archived();
        }

        
    }
}
