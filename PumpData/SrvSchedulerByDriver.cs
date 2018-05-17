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
    public partial class SrvSchedulerByDriver : Form
    {
        public SrvSchedulerByDriver()
        {
            InitializeComponent();

            cbDriver.Items.AddRange(DbUtilities.GetMachinesComboboxItemsList(machines).ToArray<ComboboxItem>());

            cbDates.Items.AddRange(new object[] { "2", "4", "6", "12" });

            foreach (Districts dist in districts)
            {
                dgvDistricts.Rows.Add(new object[] { dist.Id, dist.Name });
            }

            foreach (Brand company in companies)
            {
                dgvCompanies.Rows.Add(new object[] { company.Id, company.SelfOperating, company.Name });
            }

            coms_selected = get_Selected_Companies();
        }

        public List<Brand> companies = DbUtilities.GetSqlCompaniesList();

        public List<Machines> machines = DbUtilities.GetSqlMachinesList();
        public List<Districts> districts = DbUtilities.GetSqlDistrictsList();
        public List<Nomoi> nomoi = DbUtilities.GetSqlNomoiList();
        public List<Perioxes> perioxes = DbUtilities.GetSqlPerioxesList();
        public List<GasStationsPerPerioxh> gasStationsPerPerioxh = DbUtilities.GetSqlGasStationsPerPerioxhList();
        public List<GasStationVisits> gasStationVisits = DbUtilities.GetSqlLocalVisitsPerGasStationList();
        
        List<int> coms_selected = new List<int>();
                
        private void SrvSchedulerByDriver_Load(object sender, EventArgs e)
        {
            dgvDistricts.ClearSelection();
            dgvCompanies.ClearSelection();
        }

        private void dgvDistricts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (coms_selected.Count <= 0)
                {
                    MessageBox.Show("Δεν έχετε επιλέξει Εταιρίες!");
                    return;
                }

                if (cbDriver.SelectedItem is null)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε Οδηγό!");
                    return;
                }

                if (cbDates.SelectedItem is null)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε χρονικό διάστημα!");
                    return;
                }

                ShowStations();

                /*
                //new function -----> : ShowStations()
                //show perioxes
                dgvStations.Rows.Clear();

                //geogr. perioxi -> nomoi
                List<Nomoi> nomoiFiltered = nomoi.Where(i => i.DistrictId == Convert.ToInt32(dgvDistricts["DistrictId", e.RowIndex].Value)).ToList();
                //List<int> NomoiIdOnly = nomoiFiltered.Select(k => k.Id).ToList();
                                

                //nomoi -> perioxes
                //oles oi perioxes poy antistoixoyn stous nomoys tis geogr. perioxis...
                //List<Perioxes> perioxesFiltered = perioxes.Where(i => i.Geo_Nomos_Id == Convert.ToInt32(dgvNomoi["NomoiId", dgvNomoi.SelectedRows[0].Index].Value)).ToList();
                //List<Perioxes> perioxesFiltered = perioxes.Where(i => nomoiFiltered.Contains<Nomoi>(i.Geo_Nomos_Id));
                List<Perioxes> perioxesFiltered = perioxes.Where(i => nomoiFiltered.Select(k => k.Id).Contains(i.Geo_Nomos_Id)).ToList();


                //perioxes -> stations
                //-->function: ShowStations()
                int PeriodInMonths = Convert.ToInt32(cbDates.SelectedItem);
                DateTime DtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-PeriodInMonths);
                DateTime DtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                //List<GasStationVisits> gasStationVisitsFiltered = gasStationVisits.Where(i => i.VehicleNo == ((Vehicle)((ComboboxItem)cbVehicleNo.SelectedItem).Value).Id && i.Dt >= DtFrom && i.Dt <= DtTo).ToList();
                //List<GasStationVisits> gasStationVisitsFiltered = gasStationVisits.Where(i => i.Driver == ((Machines)((ComboboxItem)cbDriver.SelectedItem).Value).UserName && i.Dt >= DtFrom && i.Dt <= DtTo).ToList();

                List<GasStationVisits> gasStationVisitsFiltered;
                if (cbDriver.SelectedIndex == 0) //ΟΛΟΙ
                {
                    gasStationVisitsFiltered = gasStationVisits.Where(i => i.Dt >= DtFrom && i.Dt <= DtTo).ToList();
                }
                else
                {
                    gasStationVisitsFiltered = gasStationVisits.Where(i => i.Driver == ((Machines)((ComboboxItem)cbDriver.SelectedItem).Value).UserName && i.Dt >= DtFrom && i.Dt <= DtTo).ToList();
                }

                //List<GasStationsPerPerioxh> gasStationsFiltered = gasStationsPerPerioxh.Where(i => i.Geo_Perioxh_id == Convert.ToInt32(dgvPerioxes["PerioxhId", dgvPerioxes.SelectedRows[0].Index].Value) && i.ExistsInComs(coms_selected.ToArray())).ToList();
                List<GasStationsPerPerioxh> gasStationsFiltered = gasStationsPerPerioxh.Where(i => perioxesFiltered.Select(k=>k.Id).Contains(i.Geo_Perioxh_id) && i.ExistsInComs(coms_selected.ToArray())).ToList();
                int Visits = 0;
                int VisitsGasoline = 0;
                int visitsDiesel = 0;
                int Paravaseis = 0;
                int ParavaseisGasoline = 0;
                int ParavaseisDiesel = 0;
                //string strVisits = "";
                string LastVisit = "";
                string LastDiff = "";

                lblStationsCnt.Text = gasStationsFiltered.Count.ToString();

                foreach (GasStationsPerPerioxh gasStations in gasStationsFiltered)
                {
                    Visits = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId);
                    VisitsGasoline = 0;
                    visitsDiesel = 0;
                    if (Visits > 0)
                    {
                        //strVisits = Visits.ToString();
                        LastVisit = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).Max(i => i.Dt).ToString("dd.MM.yyyy HH:mm"); //gasStationVisits.Where(i => i.GeostationId == gasStations.GeostationId).Max(i => i.Dt).ToString("dd.MM.yyyy HH:mm");
                        LastDiff = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderByDescending(i => i.Dt).First().VolDiff.ToString();
                        Paravaseis = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VolDiff < -0.5);

                        VisitsGasoline = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Βενζίνη");
                        visitsDiesel = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Diesel");
                        ParavaseisGasoline = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Βενζίνη" && i.VolDiff < -0.5);
                        ParavaseisDiesel = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Diesel" && i.VolDiff < -0.5);
                    }
                    else
                    {
                        //strVisits = "";
                        LastVisit = "";
                        LastDiff = "";
                        Paravaseis = 0;
                        ParavaseisGasoline = 0;
                        ParavaseisDiesel = 0;
                    }

                    Perioxes perioxi = perioxesFiltered.Where(i => i.Id == gasStations.Geo_Perioxh_id).First();
                    Nomoi nomos = nomoiFiltered.Where(i => i.Id == perioxi.Geo_Nomos_Id).First();

                    dgvStations.Rows.Add(new object[]
                    {
                        gasStations.GeostationId,
                        nomos.Name,
                        perioxi.Name,
                        gasStations.Address,
                        gasStations.TK_NoSpace,
                        gasStations.Company_Id,
                        gasStations.Company,
                        gasStations.Comp_Name,
                        gasStations.Company_Operated,
                        gasStations.Station_Closed,
                        Visits,
                        VisitsGasoline,
                        visitsDiesel,
                        Paravaseis,
                        ParavaseisGasoline,
                        ParavaseisDiesel,
                        LastVisit,
                        LastDiff
                    });

                    if (Visits > 0 && gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderByDescending(i => i.Dt).First().VolDiff < -0.5)
                    {
                        dgvStations.Rows[dgvStations.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }


                //<--function: ShowStations()


                dgvStations.ClearSelection();

                //<----- new function
                */
            }
        }

        private void ShowStations()
        {
            dgvStations.Rows.Clear();

            //geogr. perioxi -> nomoi
            List<Nomoi> nomoiFiltered = nomoi.Where(i => i.DistrictId == Convert.ToInt32(dgvDistricts["DistrictId", dgvDistricts.SelectedRows[0].Index].Value)).ToList();

            //nomoi -> perioxes
            List<Perioxes> perioxesFiltered = perioxes.Where(i => nomoiFiltered.Select(k => k.Id).Contains(i.Geo_Nomos_Id)).ToList();
            
            //perioxes -> stations
            int PeriodInMonths = Convert.ToInt32(cbDates.SelectedItem);
            DateTime DtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-PeriodInMonths);
            DateTime DtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            List<GasStationVisits> gasStationVisitsFiltered;
            if (cbDriver.SelectedIndex == 0) //ΟΛΟΙ
            {
                gasStationVisitsFiltered = gasStationVisits.Where(i => i.Dt >= DtFrom && i.Dt <= DtTo).ToList();
            }
            else
            {
                gasStationVisitsFiltered = gasStationVisits.Where(i => i.Driver == ((Machines)((ComboboxItem)cbDriver.SelectedItem).Value).UserName && i.Dt >= DtFrom && i.Dt <= DtTo).ToList();
            }

            List<GasStationsPerPerioxh> gasStationsFiltered = gasStationsPerPerioxh.Where(i => perioxesFiltered.Select(k => k.Id).Contains(i.Geo_Perioxh_id) && i.ExistsInComs(coms_selected.ToArray())).ToList();
            int Visits = 0;
            int VisitsGasoline = 0;
            int visitsDiesel = 0;
            int Paravaseis = 0;
            int ParavaseisGasoline = 0;
            int ParavaseisDiesel = 0;
            string LastVisit = "";
            string LastDiff = "";

            lblStationsCnt.Text = gasStationsFiltered.Count.ToString();

            foreach (GasStationsPerPerioxh gasStations in gasStationsFiltered)
            {
                Visits = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId);
                VisitsGasoline = 0;
                visitsDiesel = 0;
                if (Visits > 0)
                {
                    LastVisit = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).Max(i => i.Dt).ToString("dd.MM.yyyy HH:mm"); //gasStationVisits.Where(i => i.GeostationId == gasStations.GeostationId).Max(i => i.Dt).ToString("dd.MM.yyyy HH:mm");
                    LastDiff = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderByDescending(i => i.Dt).First().VolDiff.ToString();
                    Paravaseis = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VolDiff < -0.5);

                    VisitsGasoline = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Βενζίνη");
                    visitsDiesel = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Diesel");
                    ParavaseisGasoline = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Βενζίνη" && i.VolDiff < -0.5);
                    ParavaseisDiesel = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VehicleType == "Diesel" && i.VolDiff < -0.5);
                }
                else
                {
                    LastVisit = "";
                    LastDiff = "";
                    Paravaseis = 0;
                    ParavaseisGasoline = 0;
                    ParavaseisDiesel = 0;
                }

                //stations -> perioxes
                Perioxes perioxi = perioxesFiltered.Where(i => i.Id == gasStations.Geo_Perioxh_id).First();
                //perioxes -> nomoi
                Nomoi nomos = nomoiFiltered.Where(i => i.Id == perioxi.Geo_Nomos_Id).First();
                //nomoi -> geogr.perioxi
                dgvStations.Rows.Add(new object[]
                {
                        gasStations.GeostationId,
                        nomos.Name,
                        perioxi.Name,
                        gasStations.Address,
                        gasStations.TK_NoSpace,
                        gasStations.Company_Id,
                        gasStations.Company,
                        gasStations.Comp_Name,
                        gasStations.Company_Operated,
                        gasStations.Station_Closed,
                        Visits,
                        VisitsGasoline,
                        visitsDiesel,
                        Paravaseis,
                        ParavaseisGasoline,
                        ParavaseisDiesel,
                        LastVisit,
                        LastDiff
                });

                if (Visits > 0 && gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderByDescending(i => i.Dt).First().VolDiff < -0.5)
                {
                    dgvStations.Rows[dgvStations.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            dgvStations.ClearSelection();

        }

        private List<int> get_Selected_Companies()
        {
            List<int> companies_selected = new List<int>();
            foreach (DataGridViewRow row in dgvCompanies.Rows)
            {
                bool isSelected = false;

                isSelected = Convert.ToBoolean(row.Cells["Com_Selected"].Value);

                if (isSelected)
                {
                    companies_selected.Add(Convert.ToInt32(row.Cells["Com_Index"].Value));
                }
            }

            return companies_selected;
        }

        private void dgvCompanies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                if (Convert.ToBoolean(dgvCompanies["Com_Selected", e.RowIndex].Value) == true)
                {
                    dgvCompanies["Com_Selected", e.RowIndex].Value = false;
                }
                else
                {
                    dgvCompanies["Com_Selected", e.RowIndex].Value = true;
                }

                coms_selected = get_Selected_Companies();

                if (dgvDistricts.SelectedRows.Count > 0)
                {
                    ShowStations();
                }
            }
        }

        private void cbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDistricts.SelectedRows.Count > 0 && cbDriver.SelectedItem != null)
            {
                ShowStations();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            dgvStations.RowHeadersVisible = false;

            if (dgvStations.Rows.Count > 0)
            {
                if (dgvStations.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε εγγραφές.");
                }
                else
                {
                    dgvStations.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

                    try
                    {
                        Clipboard.SetDataObject(dgvStations.GetClipboardContent());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            dgvStations.RowHeadersVisible = true;
        }

        private void cbAllComs_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllComs.Checked) //false -> true
            {
                //select all
                foreach (DataGridViewRow row in dgvCompanies.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Com_Selected"].Value) == false)
                    {
                        row.Cells["Com_Selected"].Value = true;
                    }
                }
            }
            else //true -> false
            {
                //diselect all
                foreach (DataGridViewRow row in dgvCompanies.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Com_Selected"].Value) == true)
                    {
                        row.Cells["Com_Selected"].Value = false;
                    }
                }
            }

            coms_selected = get_Selected_Companies();

            if (dgvDistricts.SelectedRows.Count > 0)
            {
                ShowStations();
            }
        }

        private void cbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDistricts.SelectedRows.Count > 0 && cbDates.SelectedItem != null)
            {
                ShowStations();
            }
        }
    }
}
