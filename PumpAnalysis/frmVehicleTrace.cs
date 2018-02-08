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

            int VehicleNo = DbUtilities.getComboboxItem_Vehicle(cbVehicleNo).Id;

            VehicleTraceYear = DbUtilities.GetSqlVehicleTraceYearList(VehicleNo);

            cbYear.Items.Clear();
            cbYear.Items.AddRange(DbUtilities.GetVehicleTraceYearsComboboxItemsList(VehicleTraceYear).ToArray<ComboboxItem>()); 
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvVehicleTraceList.Rows.Clear();

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
                }

                //ret.Add(new string[] { reader["Dt"].ToString(), reader["DtYear"].ToString(), reader["DtMonth"].ToString(),
                //reader["Km"].ToString(), reader["Vol"].ToString(), reader["RealVol"].ToString() });
            }
        }

        
    }
}
