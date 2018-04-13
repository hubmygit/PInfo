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
            //txtDtYear.Text = obj.datetime.Year.ToString();
            //txtDtMonth.Text = obj.datetime.Month.ToString();
            txtDt.Text = obj.datetime.ToString("dd.MM.yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKmFrom.Text.Trim() == "" || txtKmTo.Text.Trim() == "")
            {
                DialogResult dialogResult = MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει όλα τα πεδία χιλιομέτρων (Km). \r\n" + 
                    "Είστε σίγουροι ότι θέλετε να αφήσετε το(α) πεδίο(α) κενό(ά);", "Κενό Πεδίο", MessageBoxButtons.YesNo);
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
            if (txtKmFrom.Text.Trim() == "")
            {
                txtKmFrom.Text = "0";
            }
            if (txtKmTo.Text.Trim() == "")
            {
                txtKmTo.Text = "0";
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
