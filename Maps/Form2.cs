using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SQLite;
using System.Globalization;
using MsgBox;
using System.Data.SqlClient;

namespace Maps
{
    public partial class Form2 : Form
    {
        DataView GlobalDV;
        public MapFormGeoData GleoPass;
        StationInterop Gleo;
        MapFormParams GlobIn;
        double GlobLon;
        double GlobLat;
        List<Bitmap> BitList;
        String DecSep;
        List<string> NonDispFields;

        DataView GlobalDVCompany;
        List<string> NonDispFieldsCompany;

        public bool SqlServerConnection = false;

        public Form2()
        {

            NonDispFields = new List<string>();

            NonDispFieldsCompany = new List<string>();

            BitList = new List<Bitmap>();

            for (int x = 1; x < 20; x++)
            {
                Bitmap bb;
                string name = "ico\\" + x.ToString().Trim() + "-min_.png";
                try
                {
                    bb = new Bitmap(name);
                }
                catch
                {
                    bb = new Bitmap("ico\\1-min_.png");
                }
                BitList.Add(bb);
            };


            NonDispFields.Add("Id".ToUpper());
            NonDispFields.Add("Longitude".ToUpper());
            NonDispFields.Add("Latitude".ToUpper());
            NonDispFields.Add("Rating".ToUpper());
            NonDispFields.Add("Place_id".ToUpper());
            NonDispFields.Add("Locality".ToUpper());
            NonDispFields.Add("Admin_Area_level_5".ToUpper());
            NonDispFields.Add("Admin_Area_level_4".ToUpper());
            NonDispFields.Add("Admin_Area_level_3".ToUpper());
            NonDispFields.Add("Admin_Area_level_2".ToUpper());
            NonDispFields.Add("Admin_Area_level_1".ToUpper());
            NonDispFields.Add("Country".ToUpper());
            NonDispFields.Add("Address3".ToUpper());
            NonDispFields.Add("Active".ToUpper());
            NonDispFields.Add("UpdDate".ToUpper());
            NonDispFields.Add("Current_Rec".ToUpper());
            NonDispFields.Add("Company_id".ToUpper());
            NonDispFields.Add("Other_Id".ToUpper());
            NonDispFields.Add("Company_Operated".ToUpper());


            DecSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            InitializeComponent();
            //ShowDataToGrid(dataGridView1, NonDispFields);
            DispMap();
            //FilterLonLat((float)32.000, (float)27.000);

            GleoPass = new MapFormGeoData();
            GleoPass.id = -1;

        }

        public Form2(double Lon, double Lat, int radiusmeter = 50) : this()
        {
            FilterLonLat(Lat, Lon, radiusmeter);
        }

        public Form2(MapFormParams leo , int StationId, bool sqlsrv = false) : this()
        {

            GlobIn = leo;
            GlobLat = GlobIn.latitude;
            GlobLon = GlobIn.longitude;
            numericUpDown1.Value = GlobIn.radius;
            numericUpDown2.Value = (int)gMap.Zoom;
            numericUpDown2.Minimum = gMap.MinZoom;
            numericUpDown2.Maximum = gMap.MaxZoom;

            if (sqlsrv)
            {
                SqlServerConnection = true;

                ShowDataToGridSQLSrv(dataGridView1, NonDispFields);

                FilterStaId(StationId);
                SetMarkers2All();
                //GlobalDVCompany = PopulateDataView(NonDispFieldsCompany);
                GlobalDVCompany = PopulateSQLDataView(NonDispFieldsCompany);
            }
            else
            {
                ShowDataToGrid(dataGridView1, NonDispFields);

                FilterStaId(StationId);
                SetMarkers2All();
                GlobalDVCompany = PopulateDataView(NonDispFieldsCompany);
            }

        }

        public Form2(double Lon, double Lat, int radiusmeter, StationInterop leo) : this()
        {
            Gleo = leo;
            GlobLat = Lat;
            GlobLon = Lon;
            numericUpDown1.Value = radiusmeter;
            numericUpDown2.Value = (int)gMap.Zoom;
            numericUpDown2.Minimum = gMap.MinZoom;
            numericUpDown2.Maximum = gMap.MaxZoom;
            FilterLonLat(Lon, Lat, radiusmeter);
            SetMarkers2All();
        }
        public Form2(MapFormParams leo, bool sqlsrv = false) : this()
        {
            GlobIn = leo;
            GlobLat = GlobIn.latitude;
            GlobLon = GlobIn.longitude;
            numericUpDown1.Value = GlobIn.radius;
            numericUpDown2.Value = (int)gMap.Zoom;
            numericUpDown2.Minimum = gMap.MinZoom;
            numericUpDown2.Maximum = gMap.MaxZoom;

            if (sqlsrv)
            {
                SqlServerConnection = true;

                ShowDataToGridSQLSrv(dataGridView1, NonDispFields);

                FilterLonLat(GlobIn.latitude, GlobIn.longitude, GlobIn.radius);
                SetMarkers2All();
                //GlobalDVCompany = PopulateDataView(NonDispFieldsCompany);
                GlobalDVCompany = PopulateSQLDataView(NonDispFieldsCompany);
            }
            else
            {
                ShowDataToGrid(dataGridView1, NonDispFields);

                FilterLonLat(GlobIn.latitude, GlobIn.longitude, GlobIn.radius);
                SetMarkers2All();
                GlobalDVCompany = PopulateDataView(NonDispFieldsCompany);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*ShowDataToGrid(dataGridView1);
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.SetPositionByKeywords("Paris, France");
            gMap.ShowCenter = false;*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1_ClickOri(sender, e);
        }

        
        private void button1_ClickOri(object sender, EventArgs e)
        {
            /*            gMap.SetPositionByKeywords("Athens, Greece"); //("Athens, Greece");
                        gMap.Zoom = 13;
                        gMap.ZoomAndCenterMarkers("Athens, Greece"); //("Athens, Greece");

                        GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
                        GMap.NET.WindowsForms.GMapMarker marker =
                            new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                                new GMap.NET.PointLatLng(48.8617774, 2.349272),
                                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
                        markers.Markers.Add(marker);
                        gMap.Overlays.Add(markers);
            */
        }
        private void gMap_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            string words = item.Tag.ToString();
            if (words == "0")
            { return; }
            else
            {
              gMap_StationDetail(item.Tag.ToString());
            }
        }

        public void Dispose_gMap()
        {
            if (gMap != null)
            {
                gMap.Dispose();
            }
        }

        private void gMap_StationDetail(string words)
        {
            int PopupId = -1;
            string SAddr = "-";
            string CName = "-";
            bool COper = false;
            string CBrandId = "";
            int CBrandIdint = 0;
            Maps.TimeDepStation SForm = new Maps.TimeDepStation();

            foreach (DataRow DVR in GlobalDVCompany.Table.Rows)
            {
                SForm.cbCompany.Items.Add(DVR[1].ToString());
            }

            //Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
            //MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result;
            //string[] words;

            string[] stringSep;
            stringSep = new string[] { "+-+" }; ;
            //words = item.Tag.ToString().Split(stringSep, StringSplitOptions.RemoveEmptyEntries);
            //words = item.Tag.ToString();
            //if (words=="0")
            //{ return; }

            //string message = item.Tag.ToString();
            //string message = words[0];
            //string caption = "Επιλογή Πρατηρίου";
            //MessageBox.Show(item.Tag.ToString());

            int rowIndex = -1;
            int comid = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["id"].Value != null) // Need to check for null if new row is exposed
                {
                    if (row.Cells["id"].Value.ToString().Equals(words))
                    {
                        rowIndex = row.Index;
                        Int32.TryParse(row.Cells["id"].Value.ToString(), out PopupId);

                        SAddr = row.Cells["Address"].Value.ToString();
                        SForm.txtAddress.Text = SAddr;

                        CName = row.Cells["Comp_Name"].Value.ToString();
                        SForm.txtCompName.Text = CName;

                        COper = Convert.ToBoolean( Convert.ToInt32(row.Cells["Company_Operated"].Value));
                        SForm.cbCompanyOperated.Checked = COper;

                        CBrandId = row.Cells["Company_id"].Value.ToString();

                        string CoName = row.Cells["Company"].Value.ToString().Trim();
                        int leo = SForm.cbCompany.FindStringExact(CoName);
                        SForm.cbCompany.SelectedIndex = leo;
                        Int32.TryParse(row.Cells["Company_id"].Value.ToString(), out comid);
                        if (comid > 19)
                        { comid = 1; }
                        else { comid--; }
                        SForm.pictureBox1.Image = BitList[comid];
                        break;
                    }
                }
            }

            SForm.btnOK.Enabled = true;
            SForm.btnCancel.Enabled = true;
            SForm.btnEdit.Enabled = true;
            SForm.btnUpdCancel.Enabled = false;
            SForm.btnUpdPost.Enabled = false;
            SForm.txtCompName.ReadOnly = true;
            SForm.cbCompanyOperated.Enabled = false;
            SForm.cbCompany.Visible = false;

            result = SForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                GleoPass.id = PopupId;
                GleoPass.name = CName;
                GleoPass.company_operated = COper;
                GleoPass.address = SAddr;
                int.TryParse(CBrandId, out CBrandIdint);

                if (SqlServerConnection)
                {
                    GleoPass.brand_id = GetSQLOtherCompanyId(CBrandIdint);
                }
                else
                {
                    GleoPass.brand_id = GetOtherCompanyId(CBrandIdint);
                }

                this.Close();
            }
            if (result == DialogResult.Yes)
            {
                //Update db
                int NewCompId;
                CName = SForm.txtCompName.Text.ToString().Trim();
                COper = SForm.cbCompanyOperated.Checked;
                NewCompId = SForm.cbCompany.SelectedIndex + 1;
                GleoPass.id = PopupId;
                GleoPass.name = CName;
                GleoPass.company_operated = COper;
                GleoPass.address = SAddr;
                //GleoPass.brand_id = CBrandIdint;
                
                if (SqlServerConnection)
                {
                    GleoPass.brand_id = GetSQLOtherCompanyId(SForm.cbCompany.SelectedIndex + 1);
                    UpdateSQLTimeDepend(PopupId, CName, NewCompId, COper);
                }
                else
                {
                    GleoPass.brand_id = GetOtherCompanyId(SForm.cbCompany.SelectedIndex + 1);
                    UpdateTimeDepend(PopupId, CName, NewCompId, COper);
                }
                
                this.Close();
            }
        }

        public void ShowDataToGrid(DataGridView Grid, List<string> NonDispFields)
        {
            //string dbFilePath = @"Stationsdb.db";
            //string dbFilePath = "PratFuelPrices.db";
            //SQLiteConnectionStringBuilder aaa = new SQLiteConnectionStringBuilder();
            //aaa.DataSource = dbFilePath;
            //SQLiteConnection sqlConn = new SQLiteConnection(aaa.ConnectionString);
            SQLiteConnection sqlConn = new SQLiteConnection(GlobIn.connectionString);
            //string SelectSt = "SELECT * FROM " + "GeoStations";
            //string SelectSt = "SELECT * FROM " + "[Com_View2]";
            string SelectSt = "SELECT * FROM " + "Station_View";
            //                          "ORDER BY C.Name, P.Year, PR.Name, P.Sn ";

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);

            SQLiteDataReader reader;
            DataTable Schemadt;
            sqlConn.Open();
            reader = cmd.ExecuteReader();
            Schemadt = reader.GetSchemaTable();


            //Dictionary<string, TableFieldItem> tfd = stTableFields.TableFieldsDic;

            try
            {

                DataTable dt = new DataTable();

                foreach (DataRow myField in Schemadt.Rows)
                {
                    //dt.Columns.Add(myField["ColumnName"].ToString());
                    //string aa = FormTableName.ToUpper() + "." + myField["ColumnName"].ToString().Trim().ToUpper();

                    //String a1 = myField["ColumnName"].ToString().Trim();
                    //int len = myField["ColumnName"].ToString().Trim().Length;
                    //String a2 = myField["ColumnName"].ToString().Trim().ToUpper().Substring(len - 2, 2);   //Left(len-2);

                    //TableFieldItem tfi = tfd[aa];
                    //if (tfi is null)
                    //MessageBox.Show(myField["BaseColumnName"].ToString());
                    try
                    {
                        dt.Columns.Add(myField["ColumnName"].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //else
                    //{
                    //DataColumn dc = new DataColumn(myField["ColumnName"].ToString());
                    //dc.Caption = tfi.Description.ToString();
                    //dt.Columns.Add(dc);
                    //}
                    //String a1 = myField["ColumnName"].ToString().Trim();
                    //int len = myField["ColumnName"].ToString().Trim().Length;
                    //String a2 = myField["ColumnName"].ToString().Trim().ToUpper().Substring(len - 2, 2);   //Left(len-2);

                    /*if ((a2.ToUpper() == "ID") && (len > 2))
                    {
                        try
                        {
                            DataGridViewComboBoxColumn DGVC = new DataGridViewComboBoxColumn();
                            int Len = myField["ColumnName"].ToString().Length;
                            String TableNamme = myField["ColumnName"].ToString().Left(Len - 2);

                            if (TableNamme == "Procedure")
                                TableNamme = "Proced";
                            if (TableNamme == "Folder")
                                TableNamme = "VFolders";

                            SQLiteConnection sqlConn0 = new SQLiteConnection("pratfuelprices.db");
                            string SelectSt0 = "SELECT id, name FROM  " + TableNamme;
                            SQLiteCommand cmd0 = new SQLiteCommand(SelectSt0, sqlConn0);
                            sqlConn0.Open();
                            SQLiteDataReader reader0 = cmd0.ExecuteReader();

                            DataTable dt0 = new DataTable();
                            dt0.Columns.Add("Id");
                            dt0.Columns.Add("Name");

                            while (reader0.Read())
                            {
                                DataRow dr1 = dt0.NewRow();
                                int num;
                                int.TryParse(reader0[0].ToString(), out num);
                                dr1[0] = num;
                                dr1[1] = reader0[1].ToString();
                                dt0.Rows.Add(dr1);
                            }
                            //DataGridViewComboBoxColumn DGVC = new DataGridViewComboBoxColumn();
                            DGVC.DataSource = dt0;
                            DGVC.DataPropertyName = myField["ColumnName"].ToString();
                            DGVC.DisplayMember = "Name";
                            DGVC.ValueMember = "Id";
                            Grid.Columns.Add(DGVC);
                            reader0.Close();
                        }
                        finally
                        {
                            //MessageBox.Show("AAAA");
                        }
                    }*/
                }

                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;

                while (reader.Read())
                {
                    DataRow dr1 = dt.NewRow();
                    for (int c = 0; c <= (reader.FieldCount - 1); c++)
                        dr1[c] = reader[c].ToString();
                    dt.Rows.Add(dr1);

                }
                DataView BS = new DataView(dt);
                BS.ApplyDefaultSort = true;
                GlobalDV = new DataView(dt);
                Grid.DataSource = BS;
                foreach (DataGridViewColumn t in Grid.Columns)
                {
                    if (NonDispFields.Contains(t.Name.ToUpper()))
                    {
                        t.Visible = false;
                    }
                    t.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }


                //Grid.Columns.Add(DGVC);

                //Grid.Columns["Id"].SortMode = DataGridViewColumnSortMode.Automatic;

                //foreach (DataGridViewColumn dgvc in Grid.Columns)
                //{
                //                    string aa = FormTableName.ToUpper() + "." + dgvc.Name.ToString().Trim().ToUpper();
                //                  if (tfd.ContainsKey(aa))
                //                {
                //                  TableFieldItem tfi = tfd[aa];
                //                if (!(tfi is null))
                //                  dgvc.HeaderText = tfi.Description.ToString();
                //        }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();

            //reader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
            //Schemadt = reader.GetSchemaTable();

            //PopulateForm(reader, Schemadt, panel4);


        }

        public void ShowDataToGridSQLSrv(DataGridView Grid, List<string> NonDispFields)
        {
            SqlConnection sqlConn = new SqlConnection(GlobIn.connectionString);
            string SelectSt = "SELECT * FROM [dbo].[Station_View]"; //Geostation ";
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            SqlDataReader reader;

            DataTable Schemadt;
            sqlConn.Open();
            reader = cmd.ExecuteReader();
            Schemadt = reader.GetSchemaTable();
            
            try
            {
                DataTable dt = new DataTable();

                foreach (DataRow myField in Schemadt.Rows)
                {
                    try
                    {
                        dt.Columns.Add(myField["ColumnName"].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                    }
                }

                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;

                while (reader.Read())
                {
                    DataRow dr1 = dt.NewRow();
                    for (int c = 0; c <= (reader.FieldCount - 1); c++)
                        dr1[c] = reader[c].ToString();
                    dt.Rows.Add(dr1);

                }

                DataView BS = new DataView(dt);
                BS.ApplyDefaultSort = true;
                GlobalDV = new DataView(dt);
                Grid.DataSource = BS;
                foreach (DataGridViewColumn t in Grid.Columns)
                {
                    if (NonDispFields.Contains(t.Name.ToUpper()))
                    {
                        t.Visible = false;
                    }
                    t.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click_1old(sender, e);
        }

        private void button1_Click_1old(object sender, EventArgs e)
        {
            gMap.SetPositionByKeywords("Athens, Greece"); //("Athens, Greece");
            gMap.Zoom = 13;
            gMap.ZoomAndCenterMarkers("Athens, Greece"); //("Athens, Greece");

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            GMap.NET.WindowsForms.GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(48.8617774, 2.349272),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2_ClickOld(sender, e);
        }

        private void button2_ClickOld(object sender, EventArgs e)
        {
            Double lo = 0;
            Double la = 0;
            String loc = "";
            GMap.NET.WindowsForms.GMapOverlay markers1 = new GMap.NET.WindowsForms.GMapOverlay("markers1");
            foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
            {

                Double.TryParse(drrow.Cells["Longitude"].Value.ToString(), out lo);
                Double.TryParse(drrow.Cells["Latitude"].Value.ToString(), out la);
                loc = drrow.Cells["Longitude"].Value.ToString() + " , " + drrow.Cells["Latitude"].Value.ToString();
                GMap.NET.WindowsForms.GMapMarker marker1 = (
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(la, lo), new Bitmap("ico\\3-min.png")));
                //GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin));
                marker1.Tag = drrow.Cells["Address"].Value.ToString();
                markers1.Markers.Add(marker1);
            }
            ///            markers.Markers.Add(marker);
            gMap.Overlays.Add(markers1);
            gMap.SetPositionByKeywords(loc);
            gMap.ZoomAndCenterMarkers(loc);
            gMap.Position = new GMap.NET.PointLatLng(la, lo);
        }
        private void SetMarkers2All()
        {
            Double lo = 0;
            Double la = 0;
            Int32 comid = 0;
            String loc = "";
            GMap.NET.WindowsForms.GMapOverlay markers1 = new GMap.NET.WindowsForms.GMapOverlay("markers1");
            foreach (DataGridViewRow drrow in dataGridView1.Rows)
            {
                Double.TryParse(drrow.Cells["Longitude"].Value.ToString(), out lo);
                Double.TryParse(drrow.Cells["Latitude"].Value.ToString(), out la);
                Int32.TryParse(drrow.Cells["Company_id"].Value.ToString(), out comid);
                if (comid > 19)
                { comid = 1; }
                else { comid--; }
                if (comid < 0)
                { comid = 0; };

                loc = drrow.Cells["Latitude"].Value.ToString() + " , "  + drrow.Cells["Longitude"].Value.ToString();
                GMap.NET.WindowsForms.GMapMarker marker1 = (
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(la, lo), BitList[comid]));
                //new Bitmap("ico\\3-min.png")));
                //GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin));
                marker1.Tag = drrow.Cells["Address"].Value.ToString() + "+-+" + drrow.Cells["id"].Value.ToString();
                marker1.Tag = drrow.Cells["id"].Value.ToString();
                markers1.Markers.Add(marker1);
            }
            ///            markers.Markers.Add(marker);
            //GMap.NET.WindowsForms.GMapMarker Cent = MarkerInInitialPos();
            markers1.Markers.Add(MarkerInInitialPos());
            gMap.Overlays.Add(markers1);
            if (loc.Trim() == "")
            { loc = GlobLat.ToString() + " , " + GlobLon.ToString();
                gMap.SetPositionByKeywords(loc);
                gMap.ZoomAndCenterMarkers(loc);
                gMap.Position = new GMap.NET.PointLatLng(GlobLat, GlobLon);

            }
            else
            {
                gMap.SetPositionByKeywords(loc);
                gMap.ZoomAndCenterMarkers(loc);
                gMap.Position = new GMap.NET.PointLatLng(la, lo);
            }
        }


        private GMap.NET.WindowsForms.GMapMarker MarkerInInitialPos()
        {
            GMap.NET.WindowsForms.GMapMarker marker1 = (
            new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new GMap.NET.PointLatLng(GlobLat, GlobLon), 
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple_small));
            marker1.Tag = 0;
            return marker1;
        }

    



    private void button3_Click(object sender, EventArgs e)
        {
            button3_ClickOld(sender, e);
        }
        private void button3_ClickOld(object sender, EventArgs e)
        {
            gMap.Overlays.Clear();
            gMap.Refresh();
        }

        private void gMap_OnMarkerEnter(GMap.NET.WindowsForms.GMapMarker item)
        {
            this.label1.Text = item.Tag.ToString();
        }

        private void gMap_OnMarkerLeave(GMap.NET.WindowsForms.GMapMarker item)
        {
            this.label1.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                ZoomOnMappoint();
            }
            else
            {
                foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
                {
                    gMap_StationDetail(drrow.Cells["id"].Value.ToString());
                }
            }
        }

        private void ZoomOnMappoint()
        {
            Double lo = 0;
            Double la = 0;
            String loc = "";
            GMap.NET.WindowsForms.GMapOverlay markers1 = new GMap.NET.WindowsForms.GMapOverlay("markers1");
            foreach (DataGridViewRow drrow in dataGridView1.SelectedRows)
            {
                Double.TryParse(drrow.Cells["Longitude"].Value.ToString(), out lo);
                Double.TryParse(drrow.Cells["Latitude"].Value.ToString(), out la);
                loc = drrow.Cells["Longitude"].Value.ToString() + " , " + drrow.Cells["Latitude"].Value.ToString();
            }
            gMap.ZoomAndCenterMarkers(loc);
            gMap.Position = new GMap.NET.PointLatLng(la, lo);
            gMap.Zoom = 20;// gMap.Zoom + 2;
        }



        private void FilterLonLat(double Lat, double Lon, int radmeter = 150)
        {
            double fromLon, toLon;
            double fromLat, toLat;
            string stfromLon, sttoLon;
            string stfromLat, sttoLat;
            double radpm;
            radpm = Math.Round((radmeter / 130000.0), 4);

            fromLon = Lon - (double)radpm;
            fromLat = Lat - (double)radpm;
            toLon = Lon + (double)radpm;
            toLat = Lat + (double)radpm;

            stfromLon = fromLon.ToString();
            stfromLat = fromLat.ToString();
            sttoLon = toLon.ToString();
            sttoLat = toLat.ToString();

            if (DecSep == ",")
            {
                stfromLon = stfromLon.Replace(",", ".");
                stfromLat = stfromLat.Replace(",", ".");
                sttoLon = sttoLon.Replace(",", ".");
                sttoLat = sttoLat.Replace(",", ".");
            }


            String aaa = "Longitude >= " + stfromLon + " AND " + "Longitude <= " + sttoLon + " AND " +
                         "Latitude >= " + stfromLat + " AND " + "Latitude <= " + sttoLat;

            //this.Text = aaa + "-" +GlobLat.ToString() +  "+" + GlobLon.ToString();

            if (GlobalDV.RowFilter is null)
            {
                //GlobalDV.RowFilter = aaa;
                GlobalDV = new DataView();
            }
            else
            {
                GlobalDV.RowFilter = aaa;
            }

            dataGridView1.DataSource = GlobalDV;
            if (GlobalDV.Count > 0)
            {
                lblFound.Text = "Stations Found " + GlobalDV.Count.ToString();
            }
            else
            { lblFound.Text = "No Stations Found "; }
        }

        private void DispMap()
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //ServerOnly;
            gMap.SetPositionByKeywords("Athens, Greece");
            gMap.ShowCenter = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddressGeocodeing();
        }

        private void AddressGeocodeing()
        {
            //GMap.NET.GeocodingProvider = 
            float tmpLatitude = 0;
            float tmpLongitude = 0;

            Geocoding.Google.GoogleGeocoder gk = new Geocoding.Google.GoogleGeocoder(GlobIn.apiKey);
            gk.Language = "EL";
            String Addr = DoBoxClick();
            foreach (Geocoding.Google.GoogleAddress aa in gk.Geocode(Addr))
            {
                gMap.Position = new GMap.NET.PointLatLng(aa.Coordinates.Latitude, aa.Coordinates.Longitude);
                gMap.Zoom = 22;
                tmpLatitude = (float)aa.Coordinates.Latitude;
                tmpLongitude = (float)aa.Coordinates.Longitude;
            }
            FilterLonLat(tmpLongitude, tmpLatitude);

            //List<Geocoding.Google.GoogleAddress> aaa = (List<Geocoding.Google.GoogleAddress >)gk.Geocode("Κουσιανόφσκυ 2-6");

        }

        private String DoBoxClick()
        {
            //Set buttons language Czech/English/German/Slovakian/Spanish (default English)
            InputBox.SetLanguage(InputBox.Language.English);
            //Save the DialogResult as res
            DialogResult res = InputBox.ShowDialog("Διεύθυνση:", "Combo InputBox",   //Text message (mandatory), Title (optional)
                InputBox.Icon.Question,                                                                         //Set icon type Error/Exclamation/Question/Warning (default info)
                                                                                                                //InputBox.Icon.Nothing,
                InputBox.Buttons.OkCancel,                                                                      //Set buttons set OK/OKcancel/YesNo/YesNoCancel (default ok)
                InputBox.Type.TextBox,                                                                         //Set type ComboBox/TextBox/Nothing (default nothing)
                new string[] { "Item1", "Item2", "Item3" },                                                        //Set string field as ComboBox items (default null)
                true,                                                                                           //Set visible in taskbar (default false)
                new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold));                        //Set font (default by system)
            //Check InputBox result
            if (res == System.Windows.Forms.DialogResult.OK || res == System.Windows.Forms.DialogResult.Yes)
                return InputBox.ResultValue;                                                                    //Get returned value
            else
                return "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button5_Clickold(sender, e);
        }


        private void button5_Clickold(object sender, EventArgs e)
        {

        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void ClearAllMarkers()
        {
            gMap.Overlays.Clear();
            gMap.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int radiusmeter = (int)numericUpDown1.Value;
            if (!(GlobalDV is null))
                FilterLonLat(GlobLat, GlobLon, radiusmeter);
            ClearAllMarkers();
            SetMarkers2All();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            int zoomnum = (int)numericUpDown2.Value;
            gMap.Zoom = zoomnum;
            gMap.ZoomAndCenterMarkers(GlobLat.ToString() + " " + GlobLon.ToString());

        }

        private void gMap_OnMapZoomChanged()
        {
            numericUpDown2.Value = (int)gMap.Zoom;
        }

        public DataView PopulateDataView(List<string> NonDispFields, string TableName = "Companies")
        {
            DataView DV;
            DV = new DataView();

            SQLiteConnection sqlConn = new SQLiteConnection(GlobIn.connectionString);
            string SelectSt = "SELECT * FROM " + TableName;
            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);
            SQLiteDataReader reader;
            
            DataTable Schemadt;
            sqlConn.Open();
            reader = cmd.ExecuteReader();
            Schemadt = reader.GetSchemaTable();

            try
            {
                DataTable dt = new DataTable();

                foreach (DataRow myField in Schemadt.Rows)
                {
                    try
                    {
                        dt.Columns.Add(myField["ColumnName"].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                    }
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;

                while (reader.Read())
                {
                    DataRow dr1 = dt.NewRow();
                    for (int c = 0; c <= (reader.FieldCount - 1); c++)
                        dr1[c] = reader[c].ToString();
                    dt.Rows.Add(dr1);

                }
                DataView BS = new DataView(dt);
                BS.ApplyDefaultSort = true;
                DV = new DataView(dt);
            }


            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();

            return DV;

        }

        public DataView PopulateSQLDataView(List<string> NonDispFields, string TableName = "[dbo].[Station_Companies]")
        {
            DataView DV;
            DV = new DataView();

            SqlConnection sqlConn = new SqlConnection(GlobIn.connectionString);
            string SelectSt = "SELECT * FROM " + TableName;
            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);
            SqlDataReader reader;

            DataTable Schemadt;
            sqlConn.Open();
            reader = cmd.ExecuteReader();
            Schemadt = reader.GetSchemaTable();

            try
            {
                DataTable dt = new DataTable();

                foreach (DataRow myField in Schemadt.Rows)
                {
                    try
                    {
                        dt.Columns.Add(myField["ColumnName"].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following error occurred: " + ex.Message);
                    }
                }
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["id"];
                dt.PrimaryKey = keys;

                while (reader.Read())
                {
                    DataRow dr1 = dt.NewRow();
                    for (int c = 0; c <= (reader.FieldCount - 1); c++)
                        dr1[c] = reader[c].ToString();
                    dt.Rows.Add(dr1);

                }
                DataView BS = new DataView(dt);
                BS.ApplyDefaultSort = true;
                DV = new DataView(dt);
            }


            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();
            return DV;

        }
        public void UpdateTimeDepend(int Statid,string NewName,int NewCompany, bool NewComOperated)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string dstring = dt.ToString("yyyy-MM-dd HH:mm:ss.000");// + " 00:00:00.000";
            SQLiteConnection sqlConn = new SQLiteConnection(GlobIn.connectionString);
            string UpdateSt = "Update Station_TimeDependData SET Current_Rec = 0 WHERE id =" + Statid.ToString();

            string InsertSt = "Insert Into Station_TimeDependData Values (" + Statid.ToString() + ", '" + dstring + "' ,1, '" + NewName.ToString().Trim()  + "'," + NewCompany.ToString().Trim() + ", " + Convert.ToInt32(NewComOperated) + ", 0 )";

            SQLiteCommand cmdupd = new SQLiteCommand(UpdateSt, sqlConn);
            SQLiteCommand cmdins = new SQLiteCommand(InsertSt, sqlConn);

            sqlConn.Open();
            cmdupd.ExecuteNonQuery();
            cmdins.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void UpdateSQLTimeDepend(int Statid, string NewName, int NewCompany, bool NewComOperated)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string dstring = dt.ToString("yyyy-MM-dd HH:mm:ss.000");// + " 00:00:00.000";
            SqlConnection sqlConn = new SqlConnection(GlobIn.connectionString);
            string UpdateSt = "Update [dbo].[Station_TimeDependData] SET Current_Rec = 0 WHERE id =" + Statid.ToString();

            string InsertSt = "Insert Into [dbo].[Station_TimeDependData] Values (" + Statid.ToString() + ", '" + dstring + "' ,1, '" + NewName.ToString().Trim() + "'," + NewCompany.ToString().Trim() + ", " + Convert.ToInt32(NewComOperated) + ", 0 )";

            SqlCommand cmdupd = new SqlCommand(UpdateSt, sqlConn);
            SqlCommand cmdins = new SqlCommand(InsertSt, sqlConn);

            sqlConn.Open();
            cmdupd.ExecuteNonQuery();
            cmdins.ExecuteNonQuery();
            sqlConn.Close();
        }

        public int GetOtherCompanyId(int GeoCompanyId)
        {
            object a = new object();
            SQLiteConnection sqlConn = new SQLiteConnection(GlobIn.connectionString);
            string SelectSt = "SELECT Other_id  FROM Companies WHERE Id = " + GeoCompanyId.ToString();

            SQLiteCommand cmd = new SQLiteCommand(SelectSt, sqlConn);

            //SQLiteDataReader reader;
            sqlConn.Open();

            try
            {
                a = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();

            return ((int)a);

        }

        public int GetSQLOtherCompanyId(int GeoCompanyId)
        {
            object a = new object();
            SqlConnection sqlConn = new SqlConnection(GlobIn.connectionString);
            string SelectSt = "SELECT Other_id  FROM [dbo].[Station_Companies] WHERE Id = " + GeoCompanyId.ToString();

            SqlCommand cmd = new SqlCommand(SelectSt, sqlConn);

            //SQLiteDataReader reader;
            sqlConn.Open();

            try
            {
                a = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
            sqlConn.Close();

            return ((int)a);

        }


        private void FilterStaId(int StaId)
        {
            String aaa = "id = " + StaId;
            if (GlobalDV.RowFilter is null)
            {
                GlobalDV.RowFilter = aaa;
            }
            else
            {
                GlobalDV.RowFilter = aaa;
            }

            dataGridView1.DataSource = GlobalDV;
            if (GlobalDV.Count > 0)
            {
                lblFound.Text = "Stations Found " + GlobalDV.Count.ToString();
                //string Leo;
                double tmpd;

                double.TryParse(GlobalDV[0][1].ToString(), out tmpd);
                GlobIn.latitude = tmpd;
                GlobLat = tmpd;


                double.TryParse(GlobalDV[0][2].ToString(), out tmpd);
                GlobIn.longitude = tmpd;
                GlobLon = tmpd;

            }
            else
            { lblFound.Text = "No Stations Found "; }
        }



    }
}
