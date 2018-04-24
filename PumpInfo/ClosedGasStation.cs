using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;
using Maps;
using System.Globalization;

namespace PumpInfo
{
    public partial class ClosedGasStation : Form
    {
        public ClosedGasStation()
        {
            InitializeComponent();

            cbBrand.Items.AddRange(DbUtilities.GetBrandsComboboxItemsList(brands).ToArray<ComboboxItem>());
            
            //coo.latitude = "38.1234";
            //coo.longitude = "21.4321";
            //dt_date = "2018-04-01";
            //dt = new DateTime(2018, 4, 1, 10, 5, 0);
            //dt_time = "10:05";
        }

        public List<Brand> brands = DbUtilities.GetBrandsList();

        public Coordinates coo = new Coordinates();
        public string dt_date;
        public DateTime dt;
        public string dt_time;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblGeostationId.Text == "0")
            {
                MessageBox.Show("Δε βρέθηκε σημείο που να αντιστοιχεί σε πρατήριο.");
            }
            else
            {
                dt_date = dtp_date.Value.ToString("yyyy-MM-dd");
                dt_time = dtp_time.Value.ToString("HH:mm");
                dt = new DateTime(dtp_date.Value.Year, dtp_date.Value.Month, dtp_date.Value.Day, dtp_time.Value.Hour, dtp_time.Value.Minute, dtp_time.Value.Second);      

                this.DialogResult = DialogResult.OK; //includes 'close()' !!!
            }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            string realLat = "";
            string realLong = "";

            if (txtCooLat.Text.Trim() == "" && txtCooLong.Text.Trim() == "")
            {
                realLat = "0";
                realLong = "0";
            }
            else
            {
                realLat = txtCooLat.Text.Trim();
                realLong = txtCooLong.Text.Trim();
            }

            String DecSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (DecSep == ",")
            {
                realLat = realLat.Replace('.', ',');
                realLong = realLong.Replace('.', ',');
            }
            else
            {
                realLat = realLat.Replace(',', '.');
                realLong = realLong.Replace(',', '.');
            }


            MapFormParams MapObj = new MapFormParams()
            {
                latitude = Convert.ToDouble(realLat), 
                longitude = Convert.ToDouble(realLong), 
                radius = 350, //meters
                apiKey = MapsApi.key, //"AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo"
                connectionString = SQLiteDBMap.connectionString, //Stationsdb.db
                existsInternetConnection = NetworkConnections.CheckInternetConnection()
            };


            Form2 frmMap = new Form2(MapObj);
            frmMap.ShowDialog();

            if (frmMap.GleoPass.id > 0)
            {
                lblGeostationId.Text = frmMap.GleoPass.id.ToString();
                txtAddress.Text = frmMap.GleoPass.address;
                txtDealer.Text = frmMap.GleoPass.name;

                if (brands.Exists(i => i.Id == frmMap.GleoPass.brand_id))
                {
                    cbBrand.SelectedIndex = cbBrand.FindStringExact(brands.Where(i => i.Id == frmMap.GleoPass.brand_id).First().Name); //OK!
                }

                coo.latitude = realLat;
                coo.longitude = realLong;
            }

            frmMap.Dispose_gMap();
        }

        private void txtCoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if ((((TextBox)sender).Text.IndexOf(",") >= 0 || ((TextBox)sender).Text.Trim() == "" || ((TextBox)sender).SelectionStart == 0) &&
                    e.KeyChar == 44) //only one decimal point & not first character
                {
                    e.Handled = true;
                }

                //48 - 57 will be numbers
                //44 or 46 - decimal point (44: "," & 46: ".")
                //8 - backspace
            }
        }

    }
}
