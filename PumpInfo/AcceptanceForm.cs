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
            if (cbBrand.Text.Trim() == "" || txtDealer.Text.Trim() == "" || txtAddress.Text.Trim() == "" || cbProduct.Text.Trim() == "" || txtPump.Text.Trim() == "" || txtPumpVol.Text.Trim() == "")
            {
                MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει όλα τα πεδία.");
                return;
            }


            //add extra data to obj
            if (obj.accepted) //update
            {
                btnDel.Enabled = true;

                //obj.removeExtraData();
                //obj.addExtraData(((Brand)((ComboboxItem)cbBrand.SelectedItem).Value), txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                obj.addExtraData(DbUtilities.getComboboxItem_Brand(cbBrand), txtDealer.Text, txtAddress.Text, DbUtilities.getComboboxItem_Product(cbProduct), txtPump.Text, Convert.ToDouble(txtPumpVol.Text));
                //getComboboxItem_Brand

                recordAction = RecordAction.Update;

                Close();
            }
            else //insert
            {
                //obj.addExtraData(((Brand)((ComboboxItem)cbBrand.SelectedItem).Value), txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                obj.addExtraData(DbUtilities.getComboboxItem_Brand(cbBrand), txtDealer.Text, txtAddress.Text, DbUtilities.getComboboxItem_Product(cbProduct), txtPump.Text, Convert.ToDouble(txtPumpVol.Text));

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
    }
}
