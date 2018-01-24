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
    public partial class frmRealCoordinates : Form
    {
        public frmRealCoordinates()
        {
            InitializeComponent();
        }

        public ImpData AcceptedLineData = new ImpData();
        public List<ImpData> AllDataObjList = new List<ImpData>();

        private void frmRealCoordinates_Load(object sender, EventArgs e)
        {
            AcceptedLineData = ((AcceptanceForm)this.Owner).obj;
            AllDataObjList = ((frmPumpInfo)this.Owner.Owner).objList;

            List<ImpData> prevLine = AllDataObjList.Where(i => (i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex || i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex - 1) && i.date == AcceptedLineData.date).ToList();
            
            DbUtilities dbu = new DbUtilities();
            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(prevLine);
            GridViewUtils.ShowDataToDataGridView(dgvRealCoordinates, ObjRows);

            //...if index of list is equal to index of datagridview
            int indexOfDataGridView = prevLine.FindIndex(i => i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.Font = new Font(dgvRealCoordinates.DefaultCellStyle.Font, FontStyle.Italic);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.BackColor = Color.LightSteelBlue;

            dgvRealCoordinates.ClearSelection();

            if (prevLine.Count < 2)
            {
                MessageBox.Show("Δε βρέθηκε πιό πρόσφατη εγγραφή με ίδια ημερομηνία!");
            }
        }

        private void btnPrevLine_Click(object sender, EventArgs e)
        {
            dgvRealCoordinates.Rows.Clear();

            List<ImpData> prevLine = AllDataObjList.Where(i => (i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex || i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex - 1) && i.date == AcceptedLineData.date).ToList();
            
            DbUtilities dbu = new DbUtilities();
            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(prevLine);
            GridViewUtils.ShowDataToDataGridView(dgvRealCoordinates, ObjRows);

            //...if index of list is equal to index of datagridview
            int indexOfDataGridView = prevLine.FindIndex(i => i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.Font = new Font(dgvRealCoordinates.DefaultCellStyle.Font, FontStyle.Italic);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.BackColor = Color.LightSteelBlue;

            dgvRealCoordinates.ClearSelection();

            if (prevLine.Count < 2)
            {
                MessageBox.Show("Δε βρέθηκε πιό πρόσφατη εγγραφή με ίδια ημερομηνία!");
            }
        }

        private void btnSameDtLines_Click(object sender, EventArgs e)
        {
            dgvRealCoordinates.Rows.Clear();

            List<ImpData> sameDateLines = AllDataObjList.Where(i => i.date == AcceptedLineData.date).ToList();
            DbUtilities dbu = new DbUtilities();
            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(sameDateLines);
            GridViewUtils.ShowDataToDataGridView(dgvRealCoordinates, ObjRows);

            //...if index of list is equal to index of datagridview
            int indexOfDataGridView = sameDateLines.FindIndex(i => i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.Font = new Font(dgvRealCoordinates.DefaultCellStyle.Font, FontStyle.Italic);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            
            dgvRealCoordinates.ClearSelection();
        }

        private void btnAllLines_Click(object sender, EventArgs e)
        {
            dgvRealCoordinates.Rows.Clear();

            List<ImpData> allLines = AllDataObjList;
            DbUtilities dbu = new DbUtilities();
            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(allLines);
            GridViewUtils.ShowDataToDataGridView(dgvRealCoordinates, ObjRows);

            //...if index of list is equal to index of datagridview
            int indexOfDataGridView = allLines.FindIndex(i => i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.Font = new Font(dgvRealCoordinates.DefaultCellStyle.Font, FontStyle.Italic);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.BackColor = Color.LightSteelBlue;

            dgvRealCoordinates.ClearSelection();
        }

        private void dgvRealCoordinates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                MessageBox.Show(dgvRealCoordinates.Rows[e.RowIndex].Cells["Latitude"].Value.ToString());
                MessageBox.Show(dgvRealCoordinates.Rows[e.RowIndex].Cells["Longitude"].Value.ToString());

                //AcceptedLineData.realLat = dgvRealCoordinates.Rows[e.RowIndex].Cells["Latitude"].Value;
                //AcceptedLineData.realLong = dgvRealCoordinates.Rows[e.RowIndex].Cells["Longitude"].Value;
            }
        }
    }
}
