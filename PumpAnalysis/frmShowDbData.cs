using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;

namespace PumpAnalysis
{
    public partial class frmShowDbData : Form
    {
        public frmShowDbData()
        {
            InitializeComponent();

            DbUtilities dbu = new DbUtilities();
            List<ImpData> objList = dbu.ReceiptDBLines_To_ObjectList();

            List<object[]> ObjRows = GridViewUtils.ImpDataListToGridViewRowList(objList, true);

            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

        }

        private void dgvReceiptData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int itemIndex = GridViewUtils.getItemIndex(dgvReceiptData, e.RowIndex);

                MessageBox.Show(e.RowIndex.ToString() + "-" + itemIndex.ToString() + "???");
            }
        }
    }
}
