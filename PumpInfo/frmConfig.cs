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
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();

            List<ConfigParams> ConfigParamList = DbUtilities.GetConfigParamList();

            txtMaxVolDiff.Text = ConfigParamList.Where(i => i.Name == "Max_Volume_Diff_Perc").First().RealValue.ToString();
            txtMinLitrePrice.Text = ConfigParamList.Where(i => i.Name == "Min_Litre_Price").First().RealValue.ToString();
            txtMaxLitrePrice.Text = ConfigParamList.Where(i => i.Name == "Max_Litre_Price").First().RealValue.ToString();
        }

        private void txtDoubleControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if ((((TextBox)sender).Text.IndexOf(",") >= 0 || ((TextBox)sender).Text.Trim() == "" || ((TextBox)sender).SelectionStart == 0) &&
                e.KeyChar == 44) //only one decimal point & not first character
            {
                e.Handled = true;
            }

            //48 - 57 will be numbers
            //44 or 46 - decimal point (44: "," & 46: ".")
            //8 - backspace
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool succeed = true;
            DbUtilities dbu = new DbUtilities();

            if (dbu.Update_Config_RealValues("Max_Volume_Diff_Perc", Convert.ToDouble(txtMaxVolDiff.Text)) == false)
            {
                succeed = false;
            }

            if (dbu.Update_Config_RealValues("Min_Litre_Price", Convert.ToDouble(txtMinLitrePrice.Text)) == false)
            {
                succeed = false;
            }

            if (dbu.Update_Config_RealValues("Max_Litre_Price", Convert.ToDouble(txtMaxLitrePrice.Text)) == false)
            {
                succeed = false;
            }

            if (succeed)
            {
                MessageBox.Show("Επιτυχής καταχώρηση!");
            }
            else
            {
                MessageBox.Show("Προσοχή! Σφάλμα κατά την καταχώρηση!");
            }
            Close();

        }
    }
}
