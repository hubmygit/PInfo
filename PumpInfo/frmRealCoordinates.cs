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

            cbLinesFilter.Items.AddRange(new object[] { "Προηγούμενη Εγγραφή", "Εγγραφές Ημέρας", "Όλα" }); 
        }

        public ImpData AcceptedLineData = new ImpData();
        public List<ImpData> AllDataObjList = new List<ImpData>();

        public Coordinates realCoordinates = new Coordinates();
        private void frmRealCoordinates_Load(object sender, EventArgs e)
        {
            AcceptedLineData = ((AcceptanceForm)this.Owner).obj;
            AllDataObjList = ((frmPumpInfo)this.Owner.Owner).objList;

            cbLinesFilter.SelectedIndex = 0;  //default: "Προηγούμενη Εγγραφή"
        }
        
        private void dgvRealCoordinates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                realCoordinates.latitude = dgvRealCoordinates.Rows[e.RowIndex].Cells["Latitude"].Value.ToString();
                realCoordinates.longitude = dgvRealCoordinates.Rows[e.RowIndex].Cells["Longitude"].Value.ToString();

                Close();
            }
        }

        private void cbLinesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvRealCoordinates.Rows.Clear();
            List<ImpData> filteredLines = new List<ImpData>();

            if (cbLinesFilter.SelectedIndex == 0) //"Προηγούμενη Εγγραφή"
            {
                filteredLines = AllDataObjList.Where(i => (i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex || i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex - 1) && i.date == AcceptedLineData.date).ToList();
                if (filteredLines.Count < 2)
                {
                    MessageBox.Show("Δε βρέθηκε πιό πρόσφατη εγγραφή με ίδια ημερομηνία!");
                }
            }
            else if (cbLinesFilter.SelectedIndex == 1) //"Εγγραφές Ημέρας"
            {
                filteredLines = AllDataObjList.Where(i => i.date == AcceptedLineData.date).ToList();
            }
            else if (cbLinesFilter.SelectedIndex == 2) //"Όλα"
            {
                filteredLines = AllDataObjList;
            }

            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(filteredLines);
            GridViewUtils.ShowDataToDataGridView(dgvRealCoordinates, ObjRows);

            //index of list 'filteredLines' is equal to index of datagridview (added in the same order) so...
            int indexOfDataGridView = filteredLines.FindIndex(i => i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.Font = new Font(dgvRealCoordinates.DefaultCellStyle.Font, FontStyle.Italic);
            dgvRealCoordinates.Rows[indexOfDataGridView].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvRealCoordinates.ClearSelection();
        }
    }
}
