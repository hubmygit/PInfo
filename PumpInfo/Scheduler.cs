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
        public List<GasStationsPerPerioxh> gasStationsPerPerioxh = DbUtilities.GetSqliteGasStationsPerPerioxhList();
        public List<GasStationVisits> gasStationVisits = DbUtilities.GetSqliteVisitsPerGasStationList();

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
                                        
                    if (gasStationsPerPerioxh.Count(i => i.Geo_Perioxh_id == perioxh.Id) <= 0)
                    {
                        dgvPerioxes.Rows[dgvPerioxes.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.LightGray;
                    }
                    
                    dgvPerioxes["Perioxh_StationsCnt", dgvPerioxes.Rows.Count - 1].Value = gasStationsPerPerioxh.Count(i => i.Geo_Perioxh_id == perioxh.Id).ToString();

                }

                dgvPerioxes.ClearSelection();
            }
        }

        private void dgvPerioxes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dgvStations.Rows.Clear();

                List<GasStationVisits> gasStationVisitsFiltered = gasStationVisits.Where(i=>i.VehicleNo == ((Vehicle)((ComboboxItem)cbVehicleNo.SelectedItem).Value).Id).ToList();

                List<GasStationsPerPerioxh> gasStationsFiltered = gasStationsPerPerioxh.Where(i => i.Geo_Perioxh_id == Convert.ToInt32(dgvPerioxes["PerioxhId", e.RowIndex].Value)).ToList();
                int Visits = 0;
                string strVisits = "";
                string LastVisit = "";
                string LastDiff = "";

                foreach (GasStationsPerPerioxh gasStations in gasStationsFiltered)
                {
                    Visits = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId); //gasStationVisits.Count(i => i.GeostationId == gasStations.GeostationId);
                    if (Visits > 0)
                    {
                        strVisits = Visits.ToString();
                        LastVisit = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).Max(i => i.Dt).ToString("dd.MM.yyyy HH:mm"); //gasStationVisits.Where(i => i.GeostationId == gasStations.GeostationId).Max(i => i.Dt).ToString("dd.MM.yyyy HH:mm");
                        LastDiff = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderBy(i => i.Dt).First().VolDiff.ToString();
                    }
                    else
                    {
                        strVisits = "";
                        LastVisit = "";
                        LastDiff = "";
                    }
                    
                    dgvStations.Rows.Add(new object[]
                    {
                        gasStations.GeostationId,
                        gasStations.Address,
                        gasStations.Company_Id,
                        gasStations.Company,
                        gasStations.Comp_Name,
                        Visits,
                        LastVisit,
                        LastDiff
                    });

                    if (Visits > 0 && gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderBy(i => i.Dt).First().VolDiff < -0.5)
                    {
                        dgvStations.Rows[dgvStations.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }

                }

                dgvStations.ClearSelection();
            }
        }

    }
}
