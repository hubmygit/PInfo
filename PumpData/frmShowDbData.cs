using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;
//using MapForm;
using Maps;

namespace PumpData
{
    public partial class frmShowDbData : Form
    {
        public frmShowDbData()
        {
            InitializeComponent();

            DateTime dtToday = DateTime.Now.Date;
            dtFrom.Value = new DateTime(dtToday.Year, dtToday.Month, 1).AddMonths(-1);

            DbUtilities dbu = new DbUtilities();
            objList = dbu.ReceiptDBLines_To_ObjectList();

            //List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(objList);

            //List<ImpData> filteredLines = objList.Where(i => i.datetime >= dtFrom.Value.Date && i.datetime < dtTo.Value.Date.AddDays(1)).ToList();
            //List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            //GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
            
            cbGeoFilter.Items.AddRange(new object[] { "Όλα", "Χωρίς Γεωγρ. Σημείο", "Νέα Σημεία Πρατηρίων" });
            cbGeoFilter.SelectedIndex = 0;

            reorderGridViewColumns(dgvReceiptData);

            applyFilterEvents = true;
            ApplyFilters();
        }

        List<ImpData> objList = new List<ImpData>();
        bool applyFilterEvents = false;

        private void reorderGridViewColumns(DataGridView dgv)
        {
            dgv.Columns["Date"].DisplayIndex = 1;
            dgv.Columns["Time"].DisplayIndex = 2;
            dgv.Columns["ProductGroup"].DisplayIndex = 3;
            dgv.Columns["Weight"].DisplayIndex = 4;
            dgv.Columns["Temp"].DisplayIndex = 5;
            dgv.Columns["Density"].DisplayIndex = 6;
            dgv.Columns["Volume"].DisplayIndex = 7;
            dgv.Columns["PumpVol"].DisplayIndex = 8;
            dgv.Columns["VolDiffPerc"].DisplayIndex = 9;
            dgv.Columns["Brand"].DisplayIndex = 10;
            dgv.Columns["Product"].DisplayIndex = 11;
            dgv.Columns["Dealer"].DisplayIndex = 12;
            dgv.Columns["Address"].DisplayIndex = 13;
            dgv.Columns["GeostationId"].DisplayIndex = 14;
            dgv.Columns["SampleNo"].DisplayIndex = 15;
            dgv.Columns["Remarks"].DisplayIndex = 16;

            dgv.Columns["ReceiptNo"].DisplayIndex = 17;
            dgv.Columns["ReceiptPrice"].DisplayIndex = 18;

            //dgv.Columns["Driver"].DisplayIndex = 19;
        }

        private void ApplyFilters()
        {
            if (applyFilterEvents == false)
            {
                return;
            }

            dgvReceiptData.Rows.Clear();
            List <ImpData> filteredLines = new List<ImpData>();

            //cbGeoFilter
            if (cbGeoFilter.SelectedIndex == 0) //"Όλα"
            {
                filteredLines = objList;
            }
            else if (cbGeoFilter.SelectedIndex == 1) //"Χωρίς Γεωγρ. Σημείο"
            {
                filteredLines = objList.Where(i => i.geostationId == 0).ToList();
            }
            else if (cbGeoFilter.SelectedIndex == 2) //"Νέα Σημεία Πρατηρίων"
            {
                filteredLines = objList.Where(i => i.geostationId == 10).ToList();
            }

            //dtFrom & dtTo
            filteredLines = filteredLines.Where(i => i.datetime >= dtFrom.Value.Date && i.datetime < dtTo.Value.Date.AddDays(1)).ToList();

            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

            RowsForeColorFromVolDiff(dgvReceiptData);
            dgvReceiptData.ClearSelection();
            //lblGridCounter.Text = "Εγγραφές: " + filteredLines.Count.ToString();
            toolStripCounter.Text = "Εγγραφές: " + filteredLines.Count.ToString();
            //dgvReceiptData.ClearSelection(); //
        }

        private void RowsForeColorFromVolDiff(DataGridView dgv)
        {
            if (!cbColorMode.Checked)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        dgv.Rows[i].DefaultCellStyle.ForeColor = new System.Drawing.Color(); //default: ControlText;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                double diffPercVal = 0.0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    try
                    {
                        diffPercVal = Convert.ToDouble(dgv["VolDiffPerc", i].Value);

                        if (diffPercVal < -0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else if (diffPercVal > 0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                        }
                        else if (diffPercVal >= 0 && diffPercVal <= 0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        else if (diffPercVal < 0 && diffPercVal >= -0.5)
                        {
                            dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Orange;
                        }

                        //dgv.DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }
        
        private void dgvReceiptData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex != -1)
            {
                int itemIndex = GridViewUtils.getItemIndex(dgvReceiptData, e.RowIndex);

                //MessageBox.Show(e.RowIndex.ToString() + "-" + itemIndex.ToString() + "???");

                OpenFileDialog ofd = new OpenFileDialog();
                //sfd.Filter = "PDF files (*.pdf)|*.pdf";
                
                DialogResult result = ofd.ShowDialog();
                
                if (ofd.FileName.Trim() == "" || result != DialogResult.OK)
                {
                    return;
                }
                
            }
            */

            if (e.RowIndex != -1)
            {
                if (dgvReceiptData.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    try
                    {
                        Clipboard.SetDataObject(dgvReceiptData.GetClipboardContent());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        private void btnGeostation_Click(object sender, EventArgs e)
        {
            //Αν είναι 0, με τις συντεταγμένες ψάξε πρατήρια όπως στο PumpInfo
            //Αν έχει Id, δείξε το χάρτη και βάλε το marker στο πρατήριο που έχει επιλέξει
            //      Αν το αλλάξει κράτα το νέο, αλλιώς μην κάνεις τίποτα
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                int extraDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value);

                int geostId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["GeostationId"].Value.ToString().Trim());
                                
                /*
                if (geostId == 10) //New Station
                {
                    //...Φόρμα νέου σημείου / πρατηρίου
                    //btnNewGeoPoint_Click(this, EventArgs.Empty);
                    //if (((Control)sender).GetType().Name.ToUpper() == "TEXTBOX")

                    string Latitude = dgvReceiptData.SelectedRows[0].Cells["RealLat"].Value.ToString().Trim();
                    string Longitude = dgvReceiptData.SelectedRows[0].Cells["RealLong"].Value.ToString().Trim();
                    String DecSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    if (DecSep == ",")
                    {
                        Latitude = Latitude.Replace('.', ',');
                        Longitude = Longitude.Replace('.', ',');
                    }
                    else
                    {
                        Latitude = Latitude.Replace(',', '.');
                        Longitude = Longitude.Replace(',', '.');
                    }
                    CreateNewGeoPoint(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));

                    //GeoData
                    //Id = from "select max id + 1 "
                    //Address, Address2, Address3, Postal-Code, Country = from "geocoding"
                    //Latitude = dgvReceiptData.SelectedRows[0].Cells["RealLat"].Value.ToString().Trim() //+ replace
                    //Longitude = dgvReceiptData.SelectedRows[0].Cells["RealLong"].Value.ToString().Trim() //+ replace
                    //Active = 1

                    //TimeDependData
                    //Id = from "select max id + 1 "
                    //upddate = getdate()
                    //current_rec = 1
                    //comp_name = dgvReceiptData.SelectedRows[0].Cells["Dealer"].Value.ToString()
                    //company_id = ?????? - id from station_Companies
                }
                */
                //else //xxxx=Defined & 0=Not Defined
                //{
                string Lat = "", Long = "";

                if (geostId > 0 && geostId != 10)
                {
                    //geostation lat long
                    Coordinates GeoLatLong = DbUtilities.GetGeostationLatLong(geostId);
                    Lat = GeoLatLong.latitude;
                    Long = GeoLatLong.longitude;
                }
                else //0 & 10
                {
                    //string Lat = dgvReceiptData.SelectedRows[0].Cells["Latitude"].Value.ToString().Trim().Replace('.', ',');
                    //string Long = dgvReceiptData.SelectedRows[0].Cells["Longitude"].Value.ToString().Trim().Replace('.', ',');
                    Lat = dgvReceiptData.SelectedRows[0].Cells["RealLat"].Value.ToString().Trim(); //.Replace('.', ',');
                    Long = dgvReceiptData.SelectedRows[0].Cells["RealLong"].Value.ToString().Trim(); //.Replace('.', ',');
                }

                String DecSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (DecSep == ",")
                {
                    Lat = Lat.Replace('.', ',');
                    Long = Long.Replace('.', ',');
                }
                else
                {
                    Lat = Lat.Replace(',', '.');
                    Long = Long.Replace(',', '.');
                }

                MapFormParams MapObj = new MapFormParams()
                {
                    latitude = Convert.ToDouble(Lat), //dgvCurrentObj["latitude", 0].Value.ToString().Replace('.', ',')),   //38.2682,
                    longitude = Convert.ToDouble(Long), //dgvCurrentObj["longitude", 0].Value.ToString().Replace('.', ',')), //21.755,
                    radius = 350, //meters
                    apiKey = MapsApi.key, //"AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo"
                    connectionString = SqlDBInfo.connectionString, //Stationsdb.db
                    existsInternetConnection = NetworkConnections.CheckInternetConnection()
                };

                //map form
                //SearchPlace frmMap = new SearchPlace(MapObj, true); 
                Form2 frmMap = new Form2(MapObj, true);
                frmMap.ShowDialog();

                if (frmMap.GleoPass.id > 0) //point selected
                {
                    DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να καταχωρηθεί το πρατήριο στη συγκεκριμένη εγγραφή;", "Καταχώρηση Πρατηρίου", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DbUtilities dbu = new DbUtilities();
                        if (dbu.update_extraData_geostationId(extraDataId, frmMap.GleoPass.id))
                        {
                            MessageBox.Show("Το σημείο καταχωρήθηκε επιτυχώς!");
                            dgvReceiptData.SelectedRows[0].Cells["GeostationId"].Value = frmMap.GleoPass.id;
                        }
                    }
                }
                else if (geostId == 10) //new point (gas station)
                {
                    CreateNewGeoPoint();
                }

                frmMap.Dispose_gMap();
                //}
            }
        }

        private void btnGridFields_Click(object sender, EventArgs e)
        {
            //DataGridViewColumnCollection columns = dgvReceiptData.Columns;

            //foreach (DataGridViewColumn thisCol in columns)
            //{
            //    MessageBox.Show(thisCol.Index.ToString() + " - " + thisCol.HeaderText + " - (" + thisCol.Name +  ") - " + thisCol.Visible.ToString());
            //}

            GridFieldsSelector frmGridFieldsSelector = new GridFieldsSelector(dgvReceiptData.Columns);
            frmGridFieldsSelector.ShowDialog();
        }

        private void btnSampleFile_Click(object sender, EventArgs e)
        {
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                int receiptDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ReceiptDataId"].Value);
                int extraDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value);

                SampleFiles attachedFiles = new SampleFiles(extraDataId);
                attachedFiles.ShowDialog();



                //check -> "void addFilesIntoListView(ListView myListView, string[] fileNames)" from "protocol" project
                ////Open File Dialog...
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Title = "Add Files";
                //ofd.Multiselect = true; //array of files
                //DialogResult result = ofd.ShowDialog();  //ofd.ShowDialog();

                //if (ofd.FileName.Trim() == "" || result != DialogResult.OK)
                //{
                //    return;
                //}

            

            }
        }

        private void cbGeoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvReceiptData.Rows.Clear();
            //List<ImpData> filteredLines = new List<ImpData>();

            //if (cbGeoFilter.SelectedIndex == 0) //"Όλα"
            //{
            //    filteredLines = objList;
            //}
            //else if (cbGeoFilter.SelectedIndex == 1) //"Χωρίς Γεωγρ. Σημείο"
            //{
            //    filteredLines = objList.Where(i => i.geostationId == 0).ToList();
            //}
            //else if (cbGeoFilter.SelectedIndex == 2) //"Νέα Σημεία Πρατηρίων"
            //{
            //    filteredLines = objList.Where(i => i.geostationId == 10).ToList();
            //}

            //List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            //GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

            ApplyFilters();
        }

        private void frmShowDbData_Load(object sender, EventArgs e)
        {
            //dont trigger event
            //this.cbGeoFilter.SelectedIndexChanged -= new System.EventHandler(this.cbGeoFilter_SelectedIndexChanged);
            //cbGeoFilter.SelectedIndex = 0;  //default: "Όλα"
            //this.cbGeoFilter.SelectedIndexChanged += new System.EventHandler(this.cbGeoFilter_SelectedIndexChanged);
        }

        private void CreateNewGeoPoint() //create new point from gridRow and connect it with this Row
        {
            string Lat = dgvReceiptData.SelectedRows[0].Cells["RealLat"].Value.ToString().Trim(); //.Replace('.', ',');
            string Long = dgvReceiptData.SelectedRows[0].Cells["RealLong"].Value.ToString().Trim(); //.Replace('.', ',');

            String DecSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (DecSep == ",")
            {
                Lat = Lat.Replace('.', ',');
                Long = Long.Replace('.', ',');
            }
            else
            {
                Lat = Lat.Replace(',', '.');
                Long = Long.Replace(',', '.');
            }

            string Address = dgvReceiptData.SelectedRows[0].Cells["Address"].Value.ToString().Trim();
            string Dealer = dgvReceiptData.SelectedRows[0].Cells["Dealer"].Value.ToString().Trim();
            string Brand = dgvReceiptData.SelectedRows[0].Cells["Brand"].Value.ToString().Trim();

            NewGasStation frmGasStation = new NewGasStation();
            frmGasStation.txtLat.Text = Lat;
            frmGasStation.txtLong.Text = Long;
            frmGasStation.txtAddress.Text = Address;
            frmGasStation.txtDealer.Text = Dealer;

            List<Brand> brands = DbUtilities.GetSqlBrandsList();
            frmGasStation.cbBrand.Items.AddRange(DbUtilities.GetBrandsComboboxItemsList(brands).ToArray<ComboboxItem>());
            frmGasStation.cbBrand.SelectedIndex = frmGasStation.cbBrand.FindStringExact(Brand);

            //frmGasStation.txtExtraDataId.Text = dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value.ToString();
            frmGasStation.ExtraDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value);

            List<PostalCode> postalCodes = DbUtilities.GetSqlPostalCodesList();
            frmGasStation.cbPostalCode.Items.AddRange(DbUtilities.GetPostalCodesComboboxItemsList(postalCodes).ToArray<ComboboxItem>());
            
            DialogResult dlgRes = frmGasStation.ShowDialog();

            if (dlgRes == DialogResult.Yes)
            {
                //(refresh grid or) update geostationId 
                dgvReceiptData.SelectedRows[0].Cells["GeostationId"].Value = frmGasStation.NewGeostationId;
            }
        }

        private void btnNewGeoPoint_Click(object sender, EventArgs e)
        {
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                CreateNewGeoPoint();
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            //if (((Control)sender).Visible) //dont run on init //Focused
            //{
            //    dgvReceiptData.Rows.Clear();
            //    List<ImpData> filteredLines = new List<ImpData>();
            //    filteredLines = objList.Where(i => i.datetime >= dtFrom.Value.Date && i.datetime < dtTo.Value.Date.AddDays(1)).ToList();
            //    List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            //    GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
            //}

            ApplyFilters();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            //if (((Control)sender).Visible) //dont run on init //Focused
            //{
            //    dgvReceiptData.Rows.Clear();
            //    List<ImpData> filteredLines = new List<ImpData>();
            //    filteredLines = objList.Where(i => i.datetime >= dtFrom.Value.Date && i.datetime < dtTo.Value.Date.AddDays(1)).ToList();
            //    List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            //    GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
            //}

            ApplyFilters();
        }

        private void dgvReceiptData_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "Date")
            {
                e.SortResult = System.String.Compare(Convert.ToDateTime(e.CellValue1.ToString()).ToString("yyyyMMdd"),
                                                     Convert.ToDateTime(e.CellValue2.ToString()).ToString("yyyyMMdd"));

                if (e.SortResult == 0 && e.Column.Name != "Time")
                {
                    e.SortResult = System.String.Compare(dgvReceiptData.Rows[e.RowIndex1].Cells["Time"].Value.ToString(),
                                                         dgvReceiptData.Rows[e.RowIndex2].Cells["Time"].Value.ToString());
                }

                e.Handled = true;
            }
        }

        private void cbColorMode_CheckedChanged(object sender, EventArgs e)
        {
            RowsForeColorFromVolDiff(dgvReceiptData);
        }
    }
}
