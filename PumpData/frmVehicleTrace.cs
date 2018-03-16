using System;
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
    public partial class frmVehicleTrace : Form
    {
        public frmVehicleTrace()
        {
            InitializeComponent();

            cbVehicleNo.Items.AddRange(DbUtilities.GetVehiclesComboboxItemsList(vehicles).ToArray<ComboboxItem>());
        }

        public List<Vehicle> vehicles = DbUtilities.GetSqlVehiclesList();
        public List<int> VehicleTraceYear = new List<int>();


        private void cbVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvVehicleTraceList.Rows.Clear();
            btnCalc.Enabled = false;

            Vehicle selVehicle = DbUtilities.getComboboxItem_Vehicle(cbVehicleNo);
            int VehicleNo = selVehicle.Id;

            VehicleTraceYear = DbUtilities.GetSqlVehicleTraceYearList(VehicleNo);

            txtKm.Text = "";
            lblMonth.Text = "Month: -";
            lblTotConsumption.Text = "Total Lt: -";

            cbYear.Items.Clear();
            cbYear.Items.AddRange(DbUtilities.GetVehicleTraceYearsComboboxItemsList(VehicleTraceYear).ToArray<ComboboxItem>());
            
            txtConsumption.Text = selVehicle.Consumption.ToString();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvVehicleTraceList.Rows.Clear();
            btnCalc.Enabled = false;

            int VehicleNo = DbUtilities.getComboboxItem_Vehicle(cbVehicleNo).Id;
            int year = DbUtilities.getComboboxItem_VehicleTraceYear(cbYear);

            DbUtilities dbu = new DbUtilities();
            List<string[]> results = new List<string[]>();
            for (int month = 1; month <= 12; month++)
            {
                results = dbu.getVehicleTraceData(VehicleNo, year, month);

                if (results.Count > 1)
                {
                    dgvVehicleTraceList.Rows.Add(new object[] { results[0][1], results[0][2], results[0][0], results[0][3],
                                                                results[1][1], results[1][2], results[1][0], results[1][3],
                                                                (Convert.ToInt32(results[1][3]) - Convert.ToInt32(results[0][3])).ToString()});

                    btnCalc.Enabled = true;
                }

                //ret.Add(new string[] { reader["Dt"].ToString(), reader["DtYear"].ToString(), reader["DtMonth"].ToString(),
                //reader["Km"].ToString(), reader["Vol"].ToString(), reader["RealVol"].ToString() });
            }

            dgvVehicleTraceList.ClearSelection();
        }

        private void dgvVehicleTraceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && txtConsumption.Text.Trim() != "")
            {
                if (Convert.ToInt32(dgvVehicleTraceList["Km", e.RowIndex].Value.ToString()) <= 0 || Convert.ToInt32(dgvVehicleTraceList["PrevKm", e.RowIndex].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Προσοχή! \r\nΔεν είναι ακόμα συμπληρωμένες οι ενδείξεις χιλιομέτρων για τον υπολογισμό κατανάλωσης της επιλεγμένης εγγραφής.");
                    return;
                }

                //MessageBox.Show(e.RowIndex.ToString() + "," + e.ColumnIndex.ToString());
                txtKm.Text = dgvVehicleTraceList["KmDiff", e.RowIndex].Value.ToString();
                //lblMonth.Text = "Month: " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName( Convert.ToInt32(dgvVehicleTraceList["Month", e.RowIndex].Value.ToString()) );
                lblMonth.Text = "Month: " + Convert.ToInt32(dgvVehicleTraceList["Month", e.RowIndex].Value.ToString());

                double TotConsumption = Convert.ToDouble(txtKm.Text) / 100.0 * Convert.ToDouble(txtConsumption.Text);

                lblTotConsumption.Text = "Total Lt: " + TotConsumption.ToString();
            }
        }

        private void txtConsumption_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCalc_Click(object sender, EventArgs e)
        {

            if (txtKm.Text.Trim() != "" && txtConsumption.Text.Trim() != "")
            {
                double TotConsumption = Convert.ToDouble(txtKm.Text) / 100.0 * Convert.ToDouble(txtConsumption.Text);
                lblTotConsumption.Text = "Total Lt: " + TotConsumption.ToString();
            }
            
        }
    }
}
