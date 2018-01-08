using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;

namespace PumpInfo
{
    public partial class AcceptanceForm : Form
    {
        public AcceptanceForm()
        {
            InitializeComponent();           
        }

        public AcceptanceForm(ImpData dataGridViewRow)
        {
            InitializeComponent();

            cbBrand.Items.AddRange(DbUtilities.GetBrandsComboboxItemsList(brands).ToArray<ComboboxItem>());
            cbProduct.Items.AddRange(DbUtilities.GetProductsComboboxItemsList(products).ToArray<ComboboxItem>());

            obj = dataGridViewRow;
            
            object[] ObjRow = GridViewUtils.ImpDataToGridViewRow(obj);
            GridViewUtils.ShowObjToDataGridView(dgvCurrentObj, ObjRow);

            if (obj.accepted) //show extra data
            {
                btnDel.Enabled = true;

                cbBrand.SelectedIndex = cbBrand.FindStringExact(obj.brand.Name);
                txtDealer.Text = obj.dealer;
                txtAddress.Text = obj.address;
                cbProduct.SelectedIndex = cbProduct.FindStringExact(obj.product.Name);
                txtPump.Text = obj.pump;
                txtPumpVol.Text = obj.pumpVolume.ToString();
                
                //show diff
                txtPumpVol_Leave(null, null);

                txtSampleNo.Text = obj.sampleNo.ToString();
                txtRemarks.Text = obj.remarks;

            }
            
            
        }

        public ImpData obj;
        public RecordAction recordAction = RecordAction.None;
        public List<Brand> brands = DbUtilities.GetBrandsList();
        public List<Product> products = DbUtilities.GetProductsList();

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbBrand.Text.Trim() == "" || txtDealer.Text.Trim() == "" || txtAddress.Text.Trim() == "" || cbProduct.Text.Trim() == "" || 
                txtPump.Text.Trim() == "" || txtPumpVol.Text.Trim() == "") //SampleNo: can be empty - Remarks: no need to check...
            {
                MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει όλα τα πεδία.");
                return;
            }

            if (txtSampleNo.Text.Trim() == "")
            {
                txtSampleNo.Text = "0";
            }

            //add extra data to obj
            if (obj.accepted) //update
            {
                btnDel.Enabled = true;

                //obj.removeExtraData();
                //obj.addExtraData(((Brand)((ComboboxItem)cbBrand.SelectedItem).Value), txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                obj.addExtraData(DbUtilities.getComboboxItem_Brand(cbBrand), txtDealer.Text, txtAddress.Text, DbUtilities.getComboboxItem_Product(cbProduct), 
                                 txtPump.Text, Convert.ToDouble(txtPumpVol.Text), Convert.ToInt32(txtSampleNo.Text), txtRemarks.Text);
                //getComboboxItem_Brand

                recordAction = RecordAction.Update;

                Close();
            }
            else //insert
            {
                //obj.addExtraData(((Brand)((ComboboxItem)cbBrand.SelectedItem).Value), txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                obj.addExtraData(DbUtilities.getComboboxItem_Brand(cbBrand), txtDealer.Text, txtAddress.Text, DbUtilities.getComboboxItem_Product(cbProduct), 
                                 txtPump.Text, Convert.ToDouble(txtPumpVol.Text), Convert.ToInt32(txtSampleNo.Text), txtRemarks.Text);

                recordAction = RecordAction.Insert;

                Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //remove extra data from obj
            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την επιλεγμένη εγγραφή; \r\n" + 
                "Προσοχή! Οι επιπλέον πληροφορίες που έχουν καταχωρηθεί θα χαθούν;", "Ακύρωση", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                obj.removeExtraData();

                recordAction = RecordAction.Delete;

                Close();                
            }
        }

        private void txtPumpVol_Leave(object sender, EventArgs e)
        {
            double PVol = 0.0;
            if (txtPumpVol.Text.Trim() == "")
            {
                PVol = 0.0;
            }
            else
            {
                PVol = Convert.ToDouble(txtPumpVol.Text.Trim());
            }

            double Vol = 0.0;
            if (dgvCurrentObj.Rows[0].Cells["Volume"].Value.ToString().Trim() == "")
            {
                Vol = 0.0;
            }
            else
            {
                Vol = Convert.ToDouble(dgvCurrentObj.Rows[0].Cells["Volume"].Value);
            }
            
            double percDiff = 0.0;
            if (Vol > 0.0 && PVol > 0.0)
            {
                percDiff = (Vol - PVol) / Vol;
                percDiff = percDiff * 100.0; //??
                percDiff = Math.Round(percDiff, 5);
            }





            lblVolDiffPerc.Text = "Volume Difference: " + percDiff.ToString() + " %";
           

        }

        private void txtPumpVol_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSampleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only integers
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            //48 - 57 will be numbers
            //8 - backspace
        }
    }
}
