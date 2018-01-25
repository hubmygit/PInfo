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

            List<object[]> ObjRows = GridViewUtils.DBDataToGridViewRowList(objList);

            GridViewUtils.ShowDataToDataGridView(dgvReceiptData, ObjRows);

        }

        private void dgvReceiptData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex != -1)
            {
                int itemIndex = GridViewUtils.getItemIndex(dgvReceiptData, e.RowIndex);

                //MessageBox.Show(e.RowIndex.ToString() + "-" + itemIndex.ToString() + "???");

                OpenFileDialog ofd = new OpenFileDialog();
                //sfd.Filter = "PDF files (*.pdf)|*.pdf";
                
                DialogResult result = ofd.ShowDialog();
                
                if (ofd.FileName.Trim() == "" || result != DialogResult.OK)
                {
                    return;
                }
                
            }
            */
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                int receiptDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ReceiptDataId"].Value);
                int extraDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value);


                SampleFiles attachedFiles = new SampleFiles();
                attachedFiles.ShowDialog();



                //check -> "void addFilesIntoListView(ListView myListView, string[] fileNames)" from "protocol" project
                ////Open File Dialog...
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Title = "Add Files";
                //ofd.Multiselect = true; //array of files
                //DialogResult result = ofd.ShowDialog();  //ofd.ShowDialog();

                //if (ofd.FileName.Trim() == "" || result != DialogResult.OK)
                //{
                //    return;
                //}




            }
        }
    }
}
