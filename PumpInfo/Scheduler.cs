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
    public partial class Scheduler : Form
    {
        public Scheduler()
        {
            InitializeComponent();

            cbVehicleNo.Items.AddRange(DbUtilities.GetVehiclesComboboxItemsList(vehicles).ToArray<ComboboxItem>());

            foreach (Districts dist in districts)
            {
                dgvDistricts.Rows.Add(new object[] { dist.Id, dist.Name });
            }


            applyFilterEvents = true;
        }

        public List<Vehicle> vehicles = DbUtilities.GetSqliteVehiclesList();
        public List<Districts> districts = DbUtilities.GetSqliteDistrictsList();
        public List<Nomoi> nomoi = DbUtilities.GetSqliteNomoiList();
        public List<Perioxes> perioxes = DbUtilities.GetSqlitePerioxesList();

        bool applyFilterEvents = false;

        private void cbVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (applyFilterEvents == false)
            {
                return;
            }

            //...

        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
            dgvDistricts.ClearSelection();
        }

        private void dgvDistricts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dgvNomoi.Rows.Clear();
                dgvPerioxes.Rows.Clear();

                List<Nomoi> nomoiFiltered = nomoi.Where(i => i.DistrictId == Convert.ToInt32(dgvDistricts["DistrictId", e.RowIndex].Value)).ToList();

                foreach (Nomoi nomos in nomoiFiltered)
                {
                    dgvNomoi.Rows.Add(new object[] { nomos.Id, nomos.Name });
                }

                dgvNomoi.ClearSelection();
                dgvPerioxes.ClearSelection();
            }
        }

        private void dgvNomoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dgvPerioxes.Rows.Clear();

                List<Perioxes> perioxesFiltered = perioxes.Where(i => i.Geo_Nomos_Id == Convert.ToInt32(dgvNomoi["NomoiId", e.RowIndex].Value)).ToList();

                foreach (Perioxes perioxh in perioxesFiltered)
                {
                    dgvPerioxes.Rows.Add(new object[] { perioxh.Id, perioxh.Name });
                }

                dgvPerioxes.ClearSelection();
            }
        }
    }
}
