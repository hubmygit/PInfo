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
        public List<DateTime> VehicleTraceDt = new List<DateTime>();
        List<Consumption> results = new List<Consumption>();

        private void cbVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvVehicleTraceList.Rows.Clear();
            btnCalc.Enabled = false;

            cbMonth.Items.Clear();
            cbMonth.Enabled = false;

            Vehicle selVehicle = DbUtilities.getComboboxItem_Vehicle(cbVehicleNo);
            int VehicleNo = selVehicle.Id;

            VehicleTraceDt = DbUtilities.GetSqlVehicleTraceDtList(VehicleNo);

            txtKm.Text = "";
            txtDay.Text = "";
            txtTotCons.Text = "";
            txtPumpVol.Text = "";
            txtVehVol.Text = "";
            txtTotRecPrice.Text = "";
            cbYear.Items.Clear();
            cbYear.Items.AddRange(DbUtilities.GetVehicleTraceYearsComboboxItemsList(VehicleTraceDt.Select(i => i.Date.Year).Distinct().OrderBy(i => i).ToList()).ToArray<ComboboxItem>());
                        
            txtConsumption.Text = selVehicle.Consumption.ToString();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {            
            dgvVehicleTraceList.Rows.Clear();
            btnCalc.Enabled = false;

            txtKm.Text = "";
            txtTotCons.Text = "";
            txtPumpVol.Text = "";
            txtVehVol.Text = "";
            txtTotRecPrice.Text = "";

            //int VehicleNo = DbUtilities.getComboboxItem_Vehicle(cbVehicleNo).Id;
            int year = DbUtilities.getComboboxItem_VehicleTraceYear(cbYear);

            cbMonth.Enabled = true;
            cbMonth.Items.Clear();
            cbMonth.Items.AddRange(DbUtilities.GetVehicleTraceMonthsComboboxItemsList(VehicleTraceDt.Where(i=>i.Date.Year == year).Select(i => i.Date.Month).Distinct().OrderBy(i => i).ToList()).ToArray<ComboboxItem>());

            txtDay.Text = "";

            /*
            DbUtilities dbu = new DbUtilities();
                        
            for (int month = 1; month <= 12; month++)
            {
                results = dbu.getVehicleTraceData(VehicleNo, year, month);

                if (results.Count > 1)
                {
                    //dgvVehicleTraceList.Rows.Add(new object[] { results[0][1], results[0][2], results[0][0], results[0][3],
                    //                                            results[1][1], results[1][2], results[1][0], results[1][3],
                    //                                            (Convert.ToInt32(results[1][3]) - Convert.ToInt32(results[0][3])).ToString()});

                    dgvVehicleTraceList.Rows.Add(new object[] { results[1].Year, results[1].Month,
                                results[0].MaxDt.ToString("dd.MM.yyyy"), results[1].MinDt.ToString("dd.MM.yyyy"), results[1].MaxDt.ToString("dd.MM.yyyy"),
                                results[0].Km, results[1].Km, (results[1].Km - results[0].Km).ToString(), results[1].PumpVolume, results[1].ControllerVolume });

                    btnCalc.Enabled = true;
                }

                //ret.Add(new string[] { reader["Dt"].ToString(), reader["DtYear"].ToString(), reader["DtMonth"].ToString(),
                //reader["Km"].ToString(), reader["Vol"].ToString(), reader["RealVol"].ToString() });
            }
            
            dgvVehicleTraceList.ClearSelection();
            */
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvVehicleTraceList.Rows.Clear();
            btnCalc.Enabled = false;

            txtDay.Text = "";

            txtKm.Text = "";
            txtTotCons.Text = "";
            txtPumpVol.Text = "";
            txtVehVol.Text = "";
            txtTotRecPrice.Text = "";

            int VehicleNo = DbUtilities.getComboboxItem_Vehicle(cbVehicleNo).Id;
            int year = DbUtilities.getComboboxItem_VehicleTraceYear(cbYear);
            int month = DbUtilities.getComboboxItem_VehicleTraceMonth(cbMonth);

            DbUtilities dbu = new DbUtilities();
            results = dbu.getVehicleTraceData(VehicleNo, year, month);

            if (results.Count > 1)
            {
                foreach (Consumption thisCons in results)
                {
                    dgvVehicleTraceList.Rows.Add(new object[] 
                    {
                        thisCons.Dt.ToString("dd.MM.yyyy"), thisCons.KmFrom, thisCons.KmTo, (thisCons.KmTo - thisCons.KmFrom).ToString(),
                        thisCons.PumpVolume, thisCons.ControllerVolume, thisCons.ReceiptPrice, thisCons.Driver
                    });

                }
                btnCalc.Enabled = true;
            }

            dgvVehicleTraceList.ClearSelection();
        }

        private void dgvVehicleTraceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && txtConsumption.Text.Trim() != "")
            {
                if (Convert.ToInt32(dgvVehicleTraceList["KmFrom", e.RowIndex].Value.ToString()) <= 0 || Convert.ToInt32(dgvVehicleTraceList["KmTo", e.RowIndex].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Προσοχή! \r\nΔεν είναι ακόμα συμπληρωμένες οι ενδείξεις χιλιομέτρων για τον υπολογισμό κατανάλωσης της επιλεγμένης εγγραφής.");
                    return;
                }

                //MessageBox.Show(e.RowIndex.ToString() + "," + e.ColumnIndex.ToString());
                txtKm.Text = dgvVehicleTraceList["KmDiff", e.RowIndex].Value.ToString();
                //lblMonth.Text = "Month: " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName( Convert.ToInt32(dgvVehicleTraceList["Month", e.RowIndex].Value.ToString()) );
                //lblMonth.Text = "Month: " + Convert.ToInt32(dgvVehicleTraceList["Month", e.RowIndex].Value.ToString());

                //txtMonth.Text = dgvVehicleTraceList["Month", e.RowIndex].Value.ToString();
                txtDay.Text = Convert.ToDateTime(dgvVehicleTraceList["EntryDate", e.RowIndex].Value).Day.ToString();

                double TotConsumption = Convert.ToDouble(txtKm.Text) / 100.0 * Convert.ToDouble(txtConsumption.Text);

                txtTotCons.Text = TotConsumption.ToString();
                txtPumpVol.Text = dgvVehicleTraceList["PumpVol", e.RowIndex].Value.ToString();
                txtVehVol.Text = dgvVehicleTraceList["VehicleVol", e.RowIndex].Value.ToString();
                txtTotRecPrice.Text = dgvVehicleTraceList["TotReceiptPrice", e.RowIndex].Value.ToString();
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
                txtTotCons.Text = TotConsumption.ToString();
            }
            
        }

        
    }
}
