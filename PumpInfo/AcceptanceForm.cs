using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            obj = dataGridViewRow;
            
            object[] ObjRow = GridViewUtils.ImpDataToGridViewRow(obj);
            GridViewUtils.ShowObjToDataGridView(dgvCurrentObj, ObjRow);

            if (obj.accepted) //show extra data
            {
                btnDel.Enabled = true;

                txtBrand.Text = obj.brand;
                txtDealer.Text = obj.dealer;
                txtAddress.Text = obj.address;
                txtProduct.Text = obj.product;
                txtPump.Text = obj.pump;
                txtPumpVol.Text = obj.pumpVolume;
            }
            
            
        }

        public ImpData obj;
        public RecordAction recordAction = RecordAction.None;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text.Trim() == "" || txtDealer.Text.Trim() == "" || txtAddress.Text.Trim() == "" || txtProduct.Text.Trim() == "" || txtPump.Text.Trim() == "" || txtPumpVol.Text.Trim() == "")
            {
                MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει όλα τα πεδία.");
                return;
            }


            //add extra data to obj
            if (obj.accepted) //update
            {
                btnDel.Enabled = true;

                //obj.removeExtraData();
                obj.addExtraData(txtBrand.Text, txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                                
                recordAction = RecordAction.Update;

                Close();
            }
            else //insert
            {
                obj.addExtraData(txtBrand.Text, txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);

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
