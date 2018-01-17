using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        public MapFormGeoData mapFormGeoData = new MapFormGeoData();
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
