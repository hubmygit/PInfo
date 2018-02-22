using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;
using MapForm;
using Maps;

namespace PumpData
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
                
                SampleFiles attachedFiles = new SampleFiles(extraDataId);
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

        private void btnAddGeostation_Click(object sender, EventArgs e)
        {
            if (dgvReceiptData.SelectedRows.Count > 0)
            {
                int extraDataId = Convert.ToInt32(dgvReceiptData.SelectedRows[0].Cells["ExtraDataId"].Value);
                string Lat = dgvReceiptData.SelectedRows[0].Cells["Latitude"].Value.ToString().Trim().Replace('.', ',');
                string Long = dgvReceiptData.SelectedRows[0].Cells["Longitude"].Value.ToString().Trim().Replace('.', ',');

                MapFormParams MapObj = new MapFormParams()
                {
                    latitude = Convert.ToDouble(Lat), //dgvCurrentObj["latitude", 0].Value.ToString().Replace('.', ',')),   //38.2682,
                    longitude = Convert.ToDouble(Long), //dgvCurrentObj["longitude", 0].Value.ToString().Replace('.', ',')), //21.755,
                    radius = 150, //meters
                    apiKey = MapsApi.key, //"AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo"
                    connectionString = SqlDBInfo.connectionString, //Stationsdb.db
                    existsInternetConnection = NetworkConnections.CheckInternetConnection()
                };

                //map form
                //   SearchPlace frmMap = new SearchPlace(MapObj, true); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //   Form2 frmMap = new Form2( ????????????? )
                //   frmMap.ShowDialog(); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //   MapFormGeoData mfGeoData = frmMap.GleoPass; //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                //DbUtilities dbu = new DbUtilities();
                //if(dbu.update_extraData_geostationId(extraDataId, mfGeoData.id))
                //{
                //  MessageBox.Show("Το σημείο καταχωρήθηκε επιτυχώς!");
                //}
            }
        }

        private void btnGridFields_Click(object sender, EventArgs e)
        {
            //DataGridViewColumnCollection columns = dgvReceiptData.Columns;

            //foreach (DataGridViewColumn thisCol in columns)
            //{
            //    MessageBox.Show(thisCol.Index.ToString() + " - " + thisCol.HeaderText + " - (" + thisCol.Name +  ") - " + thisCol.Visible.ToString());
            //}
            
            GridFieldsSelector frmGridFieldsSelector = new GridFieldsSelector(dgvReceiptData.Columns);
            frmGridFieldsSelector.ShowDialog();
        }
    }
}
