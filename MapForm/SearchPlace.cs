using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SQLite;

namespace MapForm
{
    public partial class SearchPlace : Form
    {
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

    }

    public class MapFormParams
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int radius { get; set; }
        public string connectionString { get; set; }
        public string apiKey { get; set; }
        public bool existsInternetConnection { get; set; }
    }

    public class MapFormGeoData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
