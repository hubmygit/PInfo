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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<ImpData> objList = new List<ImpData>();

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            string receiptFile_Path = ofd.FileName;
            if (receiptFile_Path.Trim() == "")
            {
                return;
            }

            DbUtilities DBU = new DbUtilities(receiptFile_Path);

            List<ImpData> receiptObjList = DBU.FillListFromReceipt();

            objList = DBU.GetDataNotExistsInSQLiteTable(receiptObjList);

            List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList);

            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

            //bool successfulInsertion = DBU.InsertReceiptAllDataIntoSQLiteTable(objList);

        }

        private void dgvReceiptData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //MessageBox.Show("Row: " + e.RowIndex.ToString() + ", Column: " + e.ColumnIndex.ToString());
                

                int itemIndex = GridViewUtils.getItemIndex(dgvReceiptData, e.RowIndex);
                //bool accepted = (bool)dgvReceiptData.Rows[e.RowIndex].Cells["Accepted"].Value;
                ImpData selectedItem = objList.Find(i => i.dataGridViewRowIndex == itemIndex);

                
                AcceptanceForm frmAcceptance = new AcceptanceForm(selectedItem);
                frmAcceptance.ShowDialog();
                


            }
        }
    }
}
