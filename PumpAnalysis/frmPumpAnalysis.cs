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

            string read_data = dbu.getAllDataFromJsonFile();

            if (read_data.Trim() == "")
            {
                return;
            }

            List<ImpData> DataToMigrate = dbu.JsonToObjectList(read_data);

            bool insSuccess = dbu.ObjectList_To_SQLServerReceiptDataLines(DataToMigrate, read_data);
            if (insSuccess == false)
            {
                MessageBox.Show("Η διαδικασία ολοκληρώθηκε με σφάλματα!");
            }
            else
            {
                MessageBox.Show("Η διαδικασία ολοκληρώθηκε επιτυχώς!");
            }

        }
    }
}
