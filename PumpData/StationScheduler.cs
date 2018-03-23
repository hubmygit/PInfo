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
    public partial class StationScheduler : Form
    {
        public StationScheduler()
        {
            InitializeComponent();

            cbVehicleNo.Items.AddRange(DbUtilities.GetVehiclesComboboxItemsList(vehicles).ToArray<ComboboxItem>());

            applyFilterEvents = true;
        }

        public List<Vehicle> vehicles = DbUtilities.GetSqlVehiclesList();
        bool applyFilterEvents = false;

        private void cbVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
