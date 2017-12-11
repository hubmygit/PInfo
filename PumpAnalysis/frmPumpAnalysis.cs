using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            string read_data = dbu.getAllDataFromJsonFile();
        }
    }
}
