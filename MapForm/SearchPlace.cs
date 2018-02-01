using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SQLite;
using System.Globalization;

namespace MapForm
{
    public partial class SearchPlace : Form
    {
        List<string> NonDispFields = new List<string>();
        List<Bitmap> BitList = new List<Bitmap>();
        string DecSep;
        MapFormParams GlobIn;
        double GlobLon;
        double GlobLat;
        DataView GlobalDV;
        public MapFormGeoData GleoPass = new MapFormGeoData();

        public SearchPlace()
        {
            constructorFunctions();

            InitializeComponent();

            DispMap();
        }

        public SearchPlace(MapFormParams leo)
        {
            constructorFunctions();
            InitializeComponent();
            DispMap();

            GlobIn = leo;
            GlobLat = GlobIn.latitude;
            GlobLon = GlobIn.longitude;
            numericUpDownRadius.Value = GlobIn.radius;
            numericUpDownZoom.Value = (int)gMap.Zoom;
            numericUpDownZoom.Minimum = gMap.MinZoom;
            numericUpDownZoom.Maximum = gMap.MaxZoom;

            ShowDataToGrid(dataGridView1, NonDispFields);
            FilterLonLat(GlobIn.latitude, GlobIn.longitude, GlobIn.radius);
            SetMarkers2All();
        }

        void constructorFunctions()
        {
            for (int x = 1; x < 15; x++)
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
            }

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
            
            DecSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        private void DispMap()
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //ServerOnly;
            gMap.SetPositionByKeywords("Athens, Greece");
            gMap.ShowCenter = false;
        }

        public void ShowDataToGrid(DataGridView Grid, List<string> NonDispFields)
        {
            SQLiteConnection sqlConn = new SQLiteConnection(GlobIn.connectionString);

            string SelectSt = "SELECT * FROM " + "Station_View";
            
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
                    catch(Exception ex)
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
            sqlConn.Open();
        }

        private void FilterLonLat(double Lon, double Lat, int radmeter = 150)
        {
            double fromLon, toLon;
            double fromLat, toLat;
            string stfromLon, sttoLon;
            string stfromLat, sttoLat;
            double radpm;
            radpm = Math.Round((radmeter / 12000.0), 4);

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

            if (GlobalDV.RowFilter is null)
            {
                GlobalDV.RowFilter = aaa;
            }
            else
            {
                GlobalDV.RowFilter = aaa;
                //GlobalDV.RowFilter = GlobalDV.RowFilter + aaa;
            }

            dataGridView1.DataSource = GlobalDV;
            if (GlobalDV.Count > 0)
            {
                lblFound.Text = "Stations Found " + GlobalDV.Count.ToString();
            }
            else
            {
                lblFound.Text = "No Stations Found ";
            }
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
                if (comid > 17)
                { comid = 1; }
                else { comid--; }

                loc = drrow.Cells["Longitude"].Value.ToString() + " , " + drrow.Cells["Latitude"].Value.ToString();
                GMap.NET.WindowsForms.GMapMarker marker1 = (
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new GMap.NET.PointLatLng(la, lo), BitList[comid]));
                //new Bitmap("ico\\3-min.png")));
                //GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin));
                marker1.Tag = drrow.Cells["Address"].Value.ToString() + "+-+" + drrow.Cells["id"].Value.ToString();
                markers1.Markers.Add(marker1);
            }
            //markers.Markers.Add(marker);
            gMap.Overlays.Add(markers1);
            gMap.SetPositionByKeywords(loc);
            gMap.ZoomAndCenterMarkers(loc);
            gMap.Position = new GMap.NET.PointLatLng(la, lo);
        }

        private void ClearAllMarkers()
        {
            gMap.Overlays.Clear();
            gMap.Refresh();
        }

        private void numericUpDownRadius_ValueChanged(object sender, EventArgs e)
        {
            int radiusmeter = (int)numericUpDownRadius.Value;
            if (!(GlobalDV is null))
                FilterLonLat(GlobLat, GlobLon, radiusmeter);
            ClearAllMarkers();
            SetMarkers2All();
        }

        private void numericUpDownZoom_ValueChanged(object sender, EventArgs e)
        {
            int zoomnum = (int)numericUpDownZoom.Value;
            gMap.Zoom = zoomnum;
            gMap.ZoomAndCenterMarkers(GlobLat.ToString() + " " + GlobLon.ToString());
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
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
            gMap.Zoom = gMap.Zoom + 2;
        }

        private void gMap_OnMapZoomChanged()
        {
            numericUpDownZoom.Value = (int)gMap.Zoom;
        }

        private void gMap_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            //Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string[] words;
            string[] stringSep;
            stringSep = new string[] { "+-+" }; ;
            words = item.Tag.ToString().Split(stringSep, StringSplitOptions.RemoveEmptyEntries);
            //string message = item.Tag.ToString();
            string message = words[0];
            string caption = "Επιλογή Πρατηρίου";
            //MessageBox.Show(item.Tag.ToString());
            result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);

            if (result == DialogResult.Yes)
            {
                int tmpid;
                
                Int32.TryParse(words[1], out tmpid);
                GleoPass.id = tmpid;
                GleoPass.address = words[0];
                Close();
            }
        }

        private void gMap_OnMarkerEnter(GMap.NET.WindowsForms.GMapMarker item)
        {
            this.lblInfo.Text = item.Tag.ToString();
        }

        private void gMap_OnMarkerLeave(GMap.NET.WindowsForms.GMapMarker item)
        {
            this.lblInfo.Text = "";
        }



        /*
        public SearchPlace()
        {
            InitializeComponent();
        }        

        public SearchPlace(MapFormParams MapFrmParamsObj)
        {
            InitializeComponent();

            textBox1.Text = MapFrmParamsObj.latitude.ToString();
            textBox2.Text = MapFrmParamsObj.longitude.ToString();
            textBox3.Text = MapFrmParamsObj.radius.ToString();
            textBox4.Text = MapFrmParamsObj.apiKey;
            textBox5.Text = MapFrmParamsObj.connectionString;
            textBox6.Text = MapFrmParamsObj.existsInternetConnection.ToString();


            textBox7.Text = "123";
            textBox8.Text = "Δοκιμή";
            textBox9.Text = "Δοκιμαστική Εγγραφή 321";

            mapFormGeoData.id = Convert.ToInt32(textBox7.Text);
            mapFormGeoData.name = textBox8.Text; 
            mapFormGeoData.address = textBox9.Text;

            ConstructorFunctions(MapFrmParamsObj.latitude, MapFrmParamsObj.longitude); //oposite params!
        }

        public MapFormGeoData mapFormGeoData = new MapFormGeoData();

        //============================ * functions from Leonidas' project * ============================
        DataView GlobalDV;

        public void ShowDataToGrid(DataGridView Grid, List<string> NonDispFields)
        {
            //string dbFilePath = @"Stationsdb.db";
            string dbFilePath = "Data Source=" + Application.StartupPath + "\\DBs\\Stationsdb.db;Version=3;";
            dbFilePath = Application.StartupPath + "\\DBs\\Stationsdb.db";

            SQLiteConnectionStringBuilder aaa = new SQLiteConnectionStringBuilder();

            aaa.DataSource = dbFilePath;
            SQLiteConnection sqlConn = new SQLiteConnection(aaa.ConnectionString);
            string SelectSt = "SELECT * FROM " + "GeoStations";

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
                    dt.Columns.Add(myField["ColumnName"].ToString());

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
            sqlConn.Open();
        }

        private void DispMap()
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //ServerOnly;
            gMap.SetPositionByKeywords("Athens, Greece");
            gMap.ShowCenter = false;
        }

        private void FilterLonLat(double Lon, double Lat)
        {
            double fromLon, toLon;
            double fromLat, toLat;

            fromLon = Lon - (double)0.004;
            fromLat = Lat - (double)0.004;
            toLon = Lon + (double)0.004;
            toLat = Lat + (double)0.004;

            String aaa = "Longitude >= " + fromLon.ToString() + " AND " + "Longitude <= " + toLon.ToString() + " AND " +
                         "Latitude >= " + fromLat.ToString() + " AND " + "Latitude <= " + toLat.ToString();

            aaa = aaa.Replace(',', '.');

            this.Text = aaa;

            if (GlobalDV.RowFilter is null || GlobalDV.RowFilter.Trim() == "")
            {
                GlobalDV.RowFilter = aaa;
            }
            else
            {
                GlobalDV.RowFilter = GlobalDV.RowFilter + aaa;
            }

            dataGridView1.DataSource = GlobalDV;
        }

        void ConstructorFunctions(double Long, double Lat)
        {
            //-----------> public Form2()
            List<string> NonDispFields = new List<string>();
            ShowDataToGrid(dataGridView1, NonDispFields);
            DispMap();

            //-----------> public Form2(double Lon, double Lat):this()
            //Application.Run(new Form2(38.0549, 23.752));
            //FilterLonLat(Lat, Lon);
            //FilterLonLat(38.0549, 23.752);
            FilterLonLat(Long, Lat);
        }
        //============================ * functions from Leonidas' project * ============================
        */
    }


}
