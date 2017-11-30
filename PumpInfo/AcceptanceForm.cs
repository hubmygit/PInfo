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
            


            //if (selectedItem.accepted)
            //{
            //    //delete extra data from objs list

            //    DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την επιλεγμένη εγγραφή; \r\n" + 
            //        "Προσοχή! Οι επιπλέον πληροφορίες που έχουν καταχωρηθεί θα χαθούν;", "Ακύρωση", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        objList.Find(i => i.dataGridViewRowIndex == itemIndex).removeExtraData();

            //        List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);
            //        GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);
            //    }
            //}
            //else
            //{
            //    //add extra data to objs list

            //}


            //if (obj.accepted) //update-delete
            //{

            //}
            //else //insert
            //{

            //}
        }

        public ImpData obj;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}
