using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;


namespace MapsExec
{
    public partial class ShowMaps : Form
    {
        public ShowMaps()
        {
            InitializeComponent();

            String DecSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (DecSep == ",")
            {
                textBox1.Text = "37,9641";
                textBox2.Text = "23,5660";
            }
            else
            {
                textBox1.Text = "37.9641";
                textBox2.Text = "23.5660";
            }
            textBox3.Text = "50";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             MapFormParams LeoPass = new MapFormParams();
            //LeoPass.longitude = 37.9641;
            //LeoPass.latitude = 23.5660;
            double LeoPasslongitude, LeoPasslatitude;
            int Leoradius;
            double.TryParse(textBox1.Text.ToString().Trim(), out LeoPasslongitude);
            double.TryParse(textBox2.Text.ToString().Trim(), out LeoPasslatitude);
            int.TryParse(textBox3.Text.ToString().Trim(), out Leoradius);
            LeoPass.longitude = LeoPasslongitude;
            LeoPass.latitude  = LeoPasslatitude;
            LeoPass.radius = Leoradius;
            LeoPass.apiKey = "AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo";

            //string dbFilePath = "StationGeoData.db";
            //SQLiteConnectionStringBuilder aaa = new SQLiteConnectionStringBuilder();
            //aaa.DataSource = dbFilePath;
            //LeoPass.connectionString = aaa.ConnectionString;

            LeoPass.connectionString = "Data Source=StationGeoData.db";
            //string dbFile = Application.StartupPath + "\\DBs\\StationGeoData.db";
            //string myconnectionString = "Data Source=" + dbFile + ";Version=3;";
            //LeoPass.connectionString = myconnectionString;

            //StationInterop Leo = new StationInterop();
            //Maps.Form2 tex = new Maps.Form2(23.5660, 37.9641, 500, Leo);
            // Old using Interop Maps.Form2 tex = new Maps.Form2(37.9561, 23.6890, 10, Leo);
            Maps.Form2 tex = new Maps.Form2(LeoPass);
            tex.ShowDialog();
            //tex.GleoPass.address

            MessageBox.Show(tex.GleoPass.address + " " + tex.GleoPass.name + " " + tex.GleoPass.brand_id.ToString() + " " + tex.GleoPass.id.ToString());
            
        }
    }
}
