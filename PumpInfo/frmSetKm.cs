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
    public partial class frmSetKm : Form
    {
        public frmSetKm()
        {
            InitializeComponent();
        }

        public frmSetKm(ImpData obj)
        {
            InitializeComponent();

            txtVehicleNo.Text = obj.vehicleNo.ToString();
            txtDtYear.Text = obj.datetime.Year.ToString();
            txtDtMonth.Text = obj.datetime.Month.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKm.Text.Trim() == "")
            {
                DialogResult dialogResult = MessageBox.Show("Προσοχή! Δεν έχετε καταχωρήσει τελικά Km. \r\n" + 
                    "Είστε σίγουροι ότι θέλετε το πεδίο κενό;", "Κενό Πεδίο", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void frmSetKm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtKm.Text.Trim() == "")
            {
                txtKm.Text = "0";
            }
        }

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only integers
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            //48 - 57 will be numbers
            //8 - backspace
        }
    }
}
