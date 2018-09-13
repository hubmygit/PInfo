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
    public partial class ShowMyReceipts : Form
    {
        public ShowMyReceipts()
        {
            InitializeComponent();
        }
        
        public ShowMyReceipts(DateTime FromDt, DateTime ToDt)
        {
            InitializeComponent();

            dtFrom.Value = FromDt;
            dtTo.Value = ToDt;          

            applyFilterEvents = true;
            ApplyFilters();
        }
        
        List<Receipts> ReceiptsList = new DbUtilities().getReceipts();
        bool applyFilterEvents = false;

        private void ApplyFilters()
        {
            if (applyFilterEvents == false)
            {
                return;
            }

            List<Receipts> filteredReceiptsList = ReceiptsList;

            DateTime dtFromDate = dtFrom.Value.Date;
            DateTime dtToDate = dtTo.Value.Date;

            filteredReceiptsList = filteredReceiptsList.Where(i => i.Dt >= dtFromDate && i.Dt <= dtToDate.AddDays(1)).ToList();

            if (chbWPrice.CheckState == CheckState.Checked)
            {
                filteredReceiptsList = filteredReceiptsList.Where(i => i.ReceiptPrice > 0.0 ).ToList();
            }
            else if (chbWPrice.CheckState == CheckState.Unchecked)
            {
                filteredReceiptsList = filteredReceiptsList.Where(i => i.ReceiptPrice <= 0.0).ToList();
            }

            double receiptSum = filteredReceiptsList.Sum(i => i.ReceiptPrice);
            txtTotRecPrice.Text = receiptSum.ToString();

            dgvReceipts.Rows.Clear();

            foreach (Receipts thisRec in filteredReceiptsList)
            {
                dgvReceipts.Rows.Add(new object[] { thisRec.Dt.ToString("dd.MM.yyyy HH:mm"), thisRec.Brand, thisRec.Dealer, thisRec.Address, thisRec.Product, thisRec.ReceiptNo, thisRec.ReceiptPrice });
            }

            dgvReceipts.ClearSelection();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            dgvReceipts.RowHeadersVisible = false;

            if (dgvReceipts.Rows.Count > 0)
            {
                dgvReceipts.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

                try
                {
                    Clipboard.SetDataObject(dgvReceipts.GetClipboardContent());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            dgvReceipts.RowHeadersVisible = true;
        }

        private void chbWPrice_CheckStateChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
