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
    public partial class ArchivedForm : Form
    {
        public ArchivedForm()
        {
            InitializeComponent();

            //select R.Id, R.Accepted, R.VehicleNo, R.Dt, B.Name, E.Dealer, E.Address, E.GeostationId, P.Name, 
            //R.Weight, R.Temp, R.Density, R.Volume, E.Pump, E.PumpVolume, E.SampleNo, E.Remarks
            //from receiptData R left outer join
            //extraData E on R.Id = E.ReceiptDataId left outer join
            //Brand B on E.BrandId = B.Id left outer join
            //Product P on E.ProductId = P.Id

            List<object[]> arcivedDataList = PumpLib.DbUtilities.ArcivedData();
            PumpLib.GridViewUtils.ShowDataToDataGridView(dgvReceiptData, arcivedDataList);
            dgvReceiptData.ClearSelection();
        }
    }
}
