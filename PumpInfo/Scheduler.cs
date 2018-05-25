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

            cbDates.Items.AddRange(new object[] { "2", "4", "6", "12", "24", "36" });

            foreach (Districts dist in districts)
            {
                dgvDistricts.Rows.Add(new object[] { dist.Id, dist.Name });
            }

            foreach (Brand company in companies)
            {
                //if (company.Id == 4 || company.Id == 7 || company.Id == 11)
                //{
                //    dgvCompanies.Rows.Add(new object[] { company.Id, true, company.Name });
                //}
                //else
                //{
                //    dgvCompanies.Rows.Add(new object[] { company.Id, false, company.Name });
                //} 

                dgvCompanies.Rows.Add(new object[] { company.Id, company.SelfOperating, company.Name });
            }

            coms_selected = get_Selected_Companies();

            //applyFilterEvents = true;
        }

        public List<Brand> companies = DbUtilities.GetCompaniesList();

        public List<Vehicle> vehicles = DbUtilities.GetSqliteVehiclesList();
        public List<Districts> districts = DbUtilities.GetSqliteDistrictsList();
        public List<Nomoi> nomoi = DbUtilities.GetSqliteNomoiList();
        public List<Perioxes> perioxes = DbUtilities.GetSqlitePerioxesList();
        public List<GasStationsPerPerioxh> gasStationsPerPerioxh = DbUtilities.GetSqliteGasStationsPerPerioxhList();
        public List<GasStationVisits> gasStationVisits = DbUtilities.GetSqliteVisitsPerGasStationList();

        List<int> coms_selected = new List<int>();

        //bool applyFilterEvents = false;

        private void cbVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ApplyFilters();

            if (dgvPerioxes.SelectedRows.Count > 0 && cbDates.SelectedItem != null)
            {
                ShowStations();
            }
        }

        //private void ApplyFilters()
        //{
        //    if (applyFilterEvents == false)
        //    {
        //        return;
        //    }

        //    //...

        //}

        private void Scheduler_Load(object sender, EventArgs e)
        {
            dgvDistricts.ClearSelection();
            dgvCompanies.ClearSelection();
        }

        private void dgvDistricts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dgvNomoi.Rows.Clear();
                dgvPerioxes.Rows.Clear();
                dgvStations.Rows.Clear();

                List<Nomoi> nomoiFiltered = nomoi.Where(i => i.DistrictId == Convert.ToInt32(dgvDistricts["DistrictId", e.RowIndex].Value)).ToList();

                foreach (Nomoi nomos in nomoiFiltered)
                {
                    dgvNomoi.Rows.Add(new object[] { nomos.Id, nomos.Name });
                }

                dgvNomoi.ClearSelection();
                dgvPerioxes.ClearSelection();
                dgvStations.ClearSelection();
            }
        }

        private void dgvNomoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //int comCounter = 0;
                //List<int> coms = new List<int>();

                //coms_selected.Clear();
                //foreach (DataGridViewRow row in dgvCompanies.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Com_Selected"].Value);
                //    if (isSelected)
                //    {
                //        //comCounter++;
                //        coms_selected.Add(Convert.ToInt32(row.Cells["Com_Index"].Value));
                //    }
                //}


                //if (comCounter <= 0)
                if (coms_selected.Count <= 0)
                {
                    MessageBox.Show("Δεν έχετε επιλέξει Εταιρίες!");
                    return;
                }

                ShowPerioxes();


                //dgvPerioxes.Rows.Clear();
                //dgvStations.Rows.Clear();

                //List<Perioxes> perioxesFiltered = perioxes.Where(i => i.Geo_Nomos_Id == Convert.ToInt32(dgvNomoi["NomoiId", e.RowIndex].Value)).ToList();

                //foreach (Perioxes perioxh in perioxesFiltered)
                //{
                //    dgvPerioxes.Rows.Add(new object[] { perioxh.Id, perioxh.Name });

                //    if (gasStationsPerPerioxh.Count(i => i.Geo_Perioxh_id == perioxh.Id && i.ExistsInComs(coms_selected.ToArray())) <= 0)
                //    {
                //        dgvPerioxes.Rows[dgvPerioxes.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.LightGray;
                //    }

                //    dgvPerioxes["Perioxh_StationsCnt", dgvPerioxes.Rows.Count - 1].Value = gasStationsPerPerioxh.Count(i => i.Geo_Perioxh_id == perioxh.Id && i.ExistsInComs(coms_selected.ToArray())).ToString();
                //}

                //dgvPerioxes.ClearSelection();
                //dgvStations.ClearSelection();
            }
        }

        private void dgvPerioxes_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex != -1)
            {
                if (cbVehicleNo.SelectedItem is null)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε τύπο οχήματος!");
                    return;
                }

                if (cbDates.SelectedItem is null)
                {
                    MessageBox.Show("Παρακαλώ επιλέξτε χρονικό διάστημα!");
                    return;
                }

                ShowStations();
            }
        }

        void ShowStations()
        {
            int PeriodInMonths = Convert.ToInt32(cbDates.SelectedItem);
            DateTime DtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-PeriodInMonths);
            DateTime DtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            dgvStations.Rows.Clear();

            if (dgvStations.SortedColumn != null)
            {
                dgvStations.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            //List<GasStationVisits> gasStationVisitsFiltered = gasStationVisits.Where(i => i.VehicleNo == ((Vehicle)((ComboboxItem)cbVehicleNo.SelectedItem).Value).Id).ToList();
            List<GasStationVisits> gasStationVisitsFiltered = gasStationVisits.Where(i => i.VehicleNo == ((Vehicle)((ComboboxItem)cbVehicleNo.SelectedItem).Value).Id && i.Dt>= DtFrom && i.Dt <= DtTo ).ToList();

            //List<GasStationsPerPerioxh> gasStationsFiltered = gasStationsPerPerioxh.Where(i => i.Geo_Perioxh_id == Convert.ToInt32(dgvPerioxes["PerioxhId", e.RowIndex].Value)).ToList();
            List<GasStationsPerPerioxh> gasStationsFiltered = gasStationsPerPerioxh.Where(i => i.Geo_Perioxh_id == Convert.ToInt32(dgvPerioxes["PerioxhId", dgvPerioxes.SelectedRows[0].Index].Value) && i.ExistsInComs(coms_selected.ToArray())).ToList();
            int Visits = 0;
            int Paravaseis = 0;
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
                    LastDiff = gasStationVisitsFiltered.Where(i => i.GeostationId == gasStations.GeostationId).OrderByDescending(i => i.Dt).First().VolDiff.ToString();
                    Paravaseis = gasStationVisitsFiltered.Count(i => i.GeostationId == gasStations.GeostationId && i.VolDiff < -0.5); 
                }
                else
                {
                    strVisits = "";
                    LastVisit = "";
                    LastDiff = "";
                    Paravaseis = 0;
                }

                dgvStations.Rows.Add(new object[]
                {
                        gasStations.GeostationId,
                        dgvNomoi.SelectedRows[0].Cells["NomoiDescr"].Value.ToString(),
                        dgvPerioxes.SelectedRows[0].Cells["Perioxh"].Value.ToString(),
                        gasStations.Address,
                        gasStations.Company_Id,
                        gasStations.Company,
                        gasStations.Comp_Name,
                        gasStations.Company_Operated,
                        gasStations.Station_Closed,
                        Visits,
                        Paravaseis,
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

        void ShowPerioxes()
        {
            dgvPerioxes.Rows.Clear();
            dgvStations.Rows.Clear();

            List<Perioxes> perioxesFiltered = perioxes.Where(i => i.Geo_Nomos_Id == Convert.ToInt32(dgvNomoi["NomoiId", dgvNomoi.SelectedRows[0].Index].Value)).ToList();

            foreach (Perioxes perioxh in perioxesFiltered)
            {
                dgvPerioxes.Rows.Add(new object[] { perioxh.Id, perioxh.Name });

                if (gasStationsPerPerioxh.Count(i => i.Geo_Perioxh_id == perioxh.Id && i.ExistsInComs(coms_selected.ToArray())) <= 0)
                {
                    dgvPerioxes.Rows[dgvPerioxes.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.LightGray;
                }

                dgvPerioxes["Perioxh_StationsCnt", dgvPerioxes.Rows.Count - 1].Value = gasStationsPerPerioxh.Count(i => i.Geo_Perioxh_id == perioxh.Id && i.ExistsInComs(coms_selected.ToArray())).ToString();
            }

            dgvPerioxes.ClearSelection();
            dgvStations.ClearSelection();
        }

        private List<int> get_Selected_Companies()
        {
            List<int> companies_selected = new List<int>();
            foreach (DataGridViewRow row in dgvCompanies.Rows)
            {
                bool isSelected = false;
                //try
                //{

                isSelected = Convert.ToBoolean(row.Cells["Com_Selected"].Value);
                
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(row.Cells["Com_Name"].Value.ToString() + " - " + ex.Message);
                //}
                
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
                //coms_selected = get_Selected_Companies();

                //dgvCompanies.EndEdit();
                //dgvCompanies.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //if (dgvCompanies["Com_Selected", e.RowIndex].Value.ToString() == "True")
                if (Convert.ToBoolean(dgvCompanies["Com_Selected", e.RowIndex].Value) == true)
                {
                    dgvCompanies["Com_Selected", e.RowIndex].Value = false;
                }
                else
                {
                    dgvCompanies["Com_Selected", e.RowIndex].Value = true;
                }


                coms_selected = get_Selected_Companies();


                //if (dgvCompanies.Rows[e.RowIndex].Cells["Com_Selected"].Value.ToString() == "")
                //{
                //    bool isSelected1 = false;
                //}
                //else
                //{
                //    bool isSelected2 = Convert.ToBoolean(dgvCompanies.Rows[e.RowIndex].Cells["Com_Selected"].Value);
                //}

                //DataGridViewCheckBoxCell chkchecking = dgvCompanies["Com_Selected", e.RowIndex] as DataGridViewCheckBoxCell;
                //if (Convert.ToBoolean(chkchecking.Value) == true)
                //{
                //    MessageBox.Show("true - " + chkchecking.Value.ToString());
                //}
                //else
                //{
                //    MessageBox.Show("false - " + chkchecking.Value.ToString());
                //}

                //if (Convert.ToBoolean(dgvCompanies["Com_Selected", e.RowIndex].Value) == true)
                //{
                //    MessageBox.Show("true");
                //}
                //else
                //{
                //    MessageBox.Show("false");
                //}

                //coms_selected.Add(Convert.ToInt32(dgvCompanies["Com_Index", e.RowIndex].Value));

                //coms_selected.RemoveAll(i => i == Convert.ToInt32(dgvCompanies["Com_Index", e.RowIndex].Value));

                int scrollPos = dgvPerioxes.FirstDisplayedScrollingRowIndex;

                int PerioxesIndex = -1;
                if (dgvPerioxes.SelectedRows.Count > 0)
                {
                    PerioxesIndex = dgvPerioxes.SelectedRows[0].Index;
                }

                if (dgvNomoi.SelectedRows.Count > 0)
                {
                    ShowPerioxes();
                }

                dgvStations.Rows.Clear();
                if (PerioxesIndex > -1)
                {
                    dgvPerioxes.Rows[PerioxesIndex].Selected = true;

                    dgvPerioxes.FirstDisplayedScrollingRowIndex = scrollPos;

                    ShowStations();
                }

                
            }

        }

        private void cbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvPerioxes.SelectedRows.Count > 0 && cbVehicleNo.SelectedItem != null)
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
                    dgvStations.Columns["Station_Nomos"].Visible = true;
                    dgvStations.Columns["Station_Perioxi"].Visible = true;

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

            dgvStations.Columns["Station_Nomos"].Visible = false;
            dgvStations.Columns["Station_Perioxi"].Visible = false;
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
                        //dgvCompanies_CellContentClick(this, new DataGridViewCellEventArgs(1, row.Index));
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
                        //dgvCompanies_CellContentClick(this, new DataGridViewCellEventArgs(1, row.Index));
                    }
                }
            }

            coms_selected = get_Selected_Companies();

            int scrollPos = dgvPerioxes.FirstDisplayedScrollingRowIndex;

            int PerioxesIndex = -1;
            if (dgvPerioxes.SelectedRows.Count > 0)
            {
                PerioxesIndex = dgvPerioxes.SelectedRows[0].Index;
            }

            if (dgvNomoi.SelectedRows.Count > 0)
            {
                ShowPerioxes(); //refresh gas station counter
            }

            dgvStations.Rows.Clear();
            if (PerioxesIndex > -1)
            {
                dgvPerioxes.Rows[PerioxesIndex].Selected = true;

                dgvPerioxes.FirstDisplayedScrollingRowIndex = scrollPos;

                ShowStations(); //refresh gas stations
            }
            

        }

        private void dgvStations_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "Station_LastVisit")
            {
                string val1 = e.CellValue1.ToString();
                string val2 = e.CellValue2.ToString();

                if (val1 == "")
                {
                    val1 = "01.01.1900 00:00:00";
                }
                if (val2 == "")
                {
                    val2 = "01.01.1900 00:00:00";
                }

                e.SortResult = System.String.Compare(Convert.ToDateTime(val1).ToString("yyyyMMddHHmmss"),
                                                     Convert.ToDateTime(val2).ToString("yyyyMMddHHmmss"));
                e.Handled = true;
            }
        }
    }
}
