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

            DbUtilities dbu = new DbUtilities();
            objList = dbu.ReceiptDBLines_To_ObjectList();

            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(objList);

            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

            cbGeoFilter.Items.AddRange(new object[] { "Όλα", "Χωρίς Γεωγρ. Σημείο", "Νέα Σημεία Πρατηρίων" });
        }

        List<ImpData> objList = new List<ImpData>();

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
            dgvReceiptData.Rows.Clear();
            List<ImpData> filteredLines = new List<ImpData>();

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

            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
        }

        private void frmShowDbData_Load(object sender, EventArgs e)
        {
            cbGeoFilter.SelectedIndex = 0;  //default: "Όλα"
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

            frmGasStation.txtExtraDataId.Text = dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value.ToString();

            DialogResult dlgRes = frmGasStation.ShowDialog();

            if (dlgRes == DialogResult.Yes)
            {
                //(refresh grid or) update geostationId 
                dgvReceiptData.SelectedRows[0].Cells["GeostationId"].Value = frmGasStation.txtNewGeostationId.Text;
            }
        }

        private void btnNewGeoPoint_Click(object sender, EventArgs e)
        {
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                CreateNewGeoPoint();
            }
        }
    }
}
