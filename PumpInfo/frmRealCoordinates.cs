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

        private void frmRealCoordinates_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Owner.Name);
            ImpData AcceptedLineData = ((AcceptanceForm)this.Owner).obj;

            //MessageBox.Show(this.Owner.Owner.Name);
            List<ImpData> AllDataObjList = ((frmPumpInfo)this.Owner.Owner).objList;

            List<ImpData> oneLineBefore = AllDataObjList.Where(i => i.dataGridViewRowIndex == AcceptedLineData.dataGridViewRowIndex - 1).ToList();
            //List<ImpData> sameDateData = AllDataObjList.Where(i => i.date == AcceptedLineData.date).ToList();

            DbUtilities dbu = new DbUtilities();
            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(oneLineBefore);
            GridViewUtils.ShowDataToDataGridView(dgvRealCoordinates, ObjRows);

            
        }
    }
}
