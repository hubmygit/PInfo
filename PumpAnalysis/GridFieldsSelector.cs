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

        public GridFieldsSelector(DataGridViewColumnCollection dgvColumns)
        {
            InitializeComponent();

            foreach (DataGridViewColumn thisCol in dgvColumns)
            {
                //    MessageBox.Show(thisCol.Index.ToString() + " - " + thisCol.HeaderText + " - " + thisCol.Visible.ToString());


                dgvReceiptData.Rows.Add(new object[] { thisCol.Visible, thisCol.Index, thisCol.HeaderText });
            }
        }

    }
}
