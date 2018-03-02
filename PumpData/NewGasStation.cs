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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int extraDataId = 0;

            int Id = DbUtilities.GetStation_GeoDataNextId();

            int brandId = DbUtilities.getComboboxItem_Brand(cbBrand).Id;

            //BrandId -> CompanyId
            int companyId = DbUtilities.GetStationCompaniesId(brandId); //id from station_Companies
            
            //insert into: [Station_GeoData] & [Station_TimeDependData]
            //....................................
            
            //update: [extraData]
            if (Id > 0) //point selected
            {
                DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να καταχωρηθεί το πρατήριο στη συγκεκριμένη εγγραφή;", "Καταχώρηση Πρατηρίου", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DbUtilities dbu = new DbUtilities();
                    if (dbu.update_extraData_geostationId(extraDataId, Id))
                    {
                        MessageBox.Show("Το σημείο καταχωρήθηκε επιτυχώς!");
                    }
                }
            }
            Close();
        }
    }
}
