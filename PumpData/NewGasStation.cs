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
    public partial class NewGasStation : Form
    {
        public NewGasStation()
        {
            InitializeComponent();
        }

        public int NewGeostationId = 0;
        public int ExtraDataId = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int extraDataId = Convert.ToInt32(txtExtraDataId.Text);

            int GeoDataNextId = DbUtilities.GetStation_GeoDataNextId();

            int brandId = DbUtilities.getComboboxItem_Brand(cbBrand).Id;

            //BrandId -> CompanyId
            int companyId = DbUtilities.GetStationCompaniesId(brandId); //id from station_Companies

            bool succeeded = false;

            //insert into: [Station_GeoData] & [Station_TimeDependData]
            Station_GeoData stationGeoData = new Station_GeoData()
            {
                Id = GeoDataNextId,
                Address =  txtAddress.Text,
                Address2 = txtPerioxi.Text,
                Address3 = txtNomos.Text,
                PostalCode = ((PostalCode)((ComboboxItem)cbPostalCode.SelectedItem).Value).TK_NoSpace,
                Country = "Greece",
                Latitude = (float)Conversions.stringToDouble(txtLat.Text),
                Longitude = (float)Conversions.stringToDouble(txtLong.Text),
                Active = 1
            };

            //insert_xxxxxxx_(stationGeoData)
            if (DbUtilities.insert_into_StationGeoData(stationGeoData))
            {
                Station_TimeDependData stationTimeDependData = new Station_TimeDependData()
                {
                    Id = GeoDataNextId,
                    Current_Rec = 1,
                    Comp_Name = txtDealer.Text,
                    Company_Id = DbUtilities.GetStationCompaniesId(brandId), //BrandId to Company_Id
                    Company_Operated = cbCompanyOperated.Checked,
                    Station_Closed = false
                };

                //insert_yyyyyyy_(stationTimeDependData)
                succeeded = DbUtilities.insert_into_StationTimeDependData(stationTimeDependData);
            }
            //....................................

            //update: [extraData]
            if (GeoDataNextId > 0 && succeeded) //point selected
            {
                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να καταχωρηθεί το νέο πρατήριο στη συγκεκριμένη εγγραφή;", "Καταχώρηση Πρατηρίου", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbUtilities dbu = new DbUtilities();
                    if (dbu.update_extraData_geostationId(ExtraDataId, GeoDataNextId))
                    {
                        MessageBox.Show("Το σημείο καταχωρήθηκε επιτυχώς!");
                        DialogResult = DialogResult.Yes;
                        NewGeostationId = GeoDataNextId;
                    }
                    else
                    {
                        MessageBox.Show("Προσοχή!\r\nΑπέτυχε η καταχώρηση νέου σημείου.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Προσοχή!\r\nΑπέτυχε η καταχώρηση νέου σημείου.");
            }

            Close();
        }

        private void cbPostalCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNomos.Text = ((PostalCode)((ComboboxItem)cbPostalCode.SelectedItem).Value).Nomos;
            txtPerioxi.Text = ((PostalCode)((ComboboxItem)cbPostalCode.SelectedItem).Value).Perioxi;
        }
    }
}
