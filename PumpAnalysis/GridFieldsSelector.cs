using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PumpAnalysis
{
    public partial class GridFieldsSelector : Form
    {
        public GridFieldsSelector()
        {
            InitializeComponent();
        }

        DataGridViewColumnCollection dgvColumnsRef;

        public GridFieldsSelector(DataGridViewColumnCollection dgvColumns)
        {
            InitializeComponent();

            dgvColumnsRef = dgvColumns;
            foreach (DataGridViewColumn thisCol in dgvColumns)
            {
                dgvReceiptData.Rows.Add(new object[] { thisCol.Visible, thisCol.Index, thisCol.HeaderText });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < dgvReceiptData.Rows.Count; i++)
            {
                dgvColumnsRef[i].Visible = Convert.ToBoolean(dgvReceiptData["Visibility", i].Value);
            }

            Close();            
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvReceiptData.Rows.Count; i++)
            {
                dgvReceiptData["Visibility", i].Value = cbSelectAll.Checked;
            }
        }
    }
}
