using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using PumpLib;
//using MapForm;
using Maps;
using System.Globalization;

namespace PumpInfo
{
    public partial class AcceptanceForm : Form
    {
        public AcceptanceForm()
        {
            InitializeComponent();

            
        }

        ToolTip tpRealLatLong = new ToolTip();
        ToolTip tpGeostation = new ToolTip();

        public AcceptanceForm(ImpData dataGridViewRow)
        {
            InitializeComponent();

            products = DbUtilities.GetProductsList(dataGridViewRow.vehicleNo);

            cbBrand.Items.AddRange(DbUtilities.GetBrandsComboboxItemsList(brands).ToArray<ComboboxItem>());
            cbProduct.Items.AddRange(DbUtilities.GetProductsComboboxItemsList(products).ToArray<ComboboxItem>());
            cbClosedReason.Items.AddRange(DbUtilities.GetRemarksComboboxItemsList(remarks).ToArray<ComboboxItem>());

            maxVolumeDiffPerc = Config.MaxVolumeDiffPerc(); 

            obj = dataGridViewRow;
            
            object[] ObjRow = GridViewUtils.ImpDataToGridViewRow(obj);
            GridViewUtils.ShowObjToDataGridView(dgvCurrentObj, ObjRow);

            cbClosedReason.SelectedIndex = 0; //ΕΛΕΥΘΕΡΑ ΣΧΟΛΙΑ

            if (obj.accepted) //show extra data
            {
                btnDel.Enabled = true;

                cbBrand.SelectedIndex = cbBrand.FindStringExact(obj.brand.Name);
                txtDealer.Text = obj.dealer;
                txtAddress.Text = obj.address;
                cbProduct.SelectedIndex = cbProduct.FindStringExact(obj.product.Name);
                //txtPump.Text = obj.pump;
                
                txtPumpDex.Text = DbUtilities.GetSplittedField(obj.pump, new char[] { '/' }, 0); 
                txtPumpAntlia.Text = DbUtilities.GetSplittedField(obj.pump, new char[] { '/' }, 1); 
                txtPumpAkrof.Text = DbUtilities.GetSplittedField(obj.pump, new char[] { '/' }, 2); 

                txtPumpVol.Text = obj.pumpVolume.ToString();

                //show diff
                //txtPumpVol_Leave(null, null);
                txtPumpVol_Leave(this, EventArgs.Empty);

                txtSampleNo.Text = obj.sampleNo.ToString();

                txtRemarks.Text = obj.remarks;
                if (cbClosedReason.FindStringExact(obj.remarks) >= 0)
                {
                    cbClosedReason.SelectedIndex = cbClosedReason.FindStringExact(obj.remarks);
                }

                txtReceiptNo.Text = obj.receiptNo;
                txtReceiptPrice.Text = obj.receiptPrice.ToString();

                //!!!!!! fill geostationId !!!!!!
                lblGeostationId.Text = obj.geostationId.ToString();

                txtRealLat.Text = obj.realCoordinates.latitude;
                txtRealLong.Text = obj.realCoordinates.longitude;
            }

        }

        public ImpData obj;
        public RecordAction recordAction = RecordAction.None;
        public List<Brand> brands = DbUtilities.GetBrandsList();
        public List<Product> products = DbUtilities.GetProductsList();
        public List<Remarks> remarks = DbUtilities.GetRemarksList();
        public double maxVolumeDiffPerc;
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (cbBrand.Text.Trim() == "" || txtDealer.Text.Trim() == "" || txtAddress.Text.Trim() == "" || cbProduct.Text.Trim() == "" || 
            //    txtPump.Text.Trim() == "" || txtPumpVol.Text.Trim() == "") //SampleNo: can be empty - Remarks: no need to check...
            if (cbBrand.Text.Trim() == "" || txtDealer.Text.Trim() == "" || txtAddress.Text.Trim() == "" || cbProduct.Text.Trim() == "" || 
                (txtPumpDex.Text.Trim() == "" && txtPumpAntlia.Text.Trim() == "" && txtPumpAkrof.Text.Trim() == "") || 
                txtPumpVol.Text.Trim() == "")
            {
                MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει όλα τα πεδία.");
                return;
            }

            if (txtSampleNo.Text.Trim() == "")
            {
                txtSampleNo.Text = "0";
            }

            if (txtReceiptNo.Text.Trim() == "" && cbClosedReason.SelectedIndex == 0) //free remarks
            {
                MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει Αριθμό Απόδειξης.");
            }

            if (txtReceiptPrice.Text.Trim() == "" || txtReceiptPrice.Text.Trim() == "0")// || txtReceiptPrice.Text.Trim() < x || txtReceiptPrice.Text.Trim() > y
            {
                txtReceiptPrice.Text = "0";
                if (cbClosedReason.SelectedIndex == 0)
                {
                    MessageBox.Show("Προσοχή! Δεν έχετε συμπληρώσει Αξία Απόδειξης.");
                }
            }
            else
            {
                double RecPrice = Convert.ToDouble(txtReceiptPrice.Text); //axia apodeixis

                double Litres = 0.0; //litra
                if (dgvCurrentObj.Rows[0].Cells["Volume"].Value.ToString().Trim() == "")
                {
                    Litres = 0.0;
                }
                else
                {
                    Litres = Convert.ToDouble(dgvCurrentObj.Rows[0].Cells["Volume"].Value);
                }

                if (Litres > 0.0)
                {
                    double LtPrice = RecPrice / Litres; //timi litrou

                    //if (RecPrice < 5 || RecPrice > 50) //...4] [51...
                    if (LtPrice < Config.MinLitrePrice() || LtPrice > Config.MaxLitrePrice()) //(LtPrice < 0.8 || LtPrice > 2.5) //...
                    {
                        MessageBox.Show("Προσοχή!\r\n Η Αξία Απόδειξης που καταχωρήσατε, φαίνεται να βρίσκεται εκτός ορίων!");
                    }
                }                                
            }
            

            //add extra data to obj
            if (obj.accepted) //update
            {
                btnDel.Enabled = true;

                if ((txtRealLat.Text.Trim() == "0" && txtRealLong.Text.Trim() == "0") ||
                    (txtRealLat.Text.Trim() == "" && txtRealLong.Text.Trim() == ""))
                {
                    txtRealLat.Text = obj.coordinates.latitude;
                    txtRealLong.Text = obj.coordinates.longitude;
                }
                

                //obj.removeExtraData();
                //obj.addExtraData(((Brand)((ComboboxItem)cbBrand.SelectedItem).Value), txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                obj.addExtraData(DbUtilities.getComboboxItem_Brand(cbBrand), txtDealer.Text, txtAddress.Text, DbUtilities.getComboboxItem_Product(cbProduct),
                                 txtPumpDex.Text + "/" + txtPumpAntlia.Text + "/" + txtPumpAkrof.Text, //txtPump.Text, 
                                 Convert.ToDouble(txtPumpVol.Text), Convert.ToInt32(txtSampleNo.Text), txtRemarks.Text,
                                 Convert.ToInt32(lblGeostationId.Text), new Coordinates() { latitude = txtRealLat.Text, longitude = txtRealLong.Text },
                                 txtReceiptNo.Text, Convert.ToDouble(txtReceiptPrice.Text));
                //getComboboxItem_Brand

                recordAction = RecordAction.Update;

                Close();
            }
            else //insert
            {
                if ((txtRealLat.Text.Trim() == "0" && txtRealLong.Text.Trim() == "0") ||
                    (txtRealLat.Text.Trim() == "" && txtRealLong.Text.Trim() == ""))
                {
                    txtRealLat.Text = obj.coordinates.latitude;
                    txtRealLong.Text = obj.coordinates.longitude;
                }

                //obj.addExtraData(((Brand)((ComboboxItem)cbBrand.SelectedItem).Value), txtDealer.Text, txtAddress.Text, txtProduct.Text, txtPump.Text, txtPumpVol.Text);
                obj.addExtraData(DbUtilities.getComboboxItem_Brand(cbBrand), txtDealer.Text, txtAddress.Text, DbUtilities.getComboboxItem_Product(cbProduct),
                                 txtPumpDex.Text + "/" + txtPumpAntlia.Text + "/" + txtPumpAkrof.Text, //txtPump.Text, 
                                 Convert.ToDouble(txtPumpVol.Text), Convert.ToInt32(txtSampleNo.Text), txtRemarks.Text, 
                                 Convert.ToInt32(lblGeostationId.Text), new Coordinates() { latitude = txtRealLat.Text, longitude = txtRealLong.Text },
                                 txtReceiptNo.Text, Convert.ToDouble(txtReceiptPrice.Text));

                recordAction = RecordAction.Insert;

                Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //remove extra data from obj
            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι ότι θέλετε να ακυρώσετε την επιλεγμένη εγγραφή; \r\n" + 
                "Προσοχή! Οι επιπλέον πληροφορίες που έχουν καταχωρηθεί θα χαθούν;", "Ακύρωση", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                obj.removeExtraData();

                recordAction = RecordAction.Delete;

                Close();                
            }
        }

        private void txtPumpVol_Leave(object sender, EventArgs e)
        {
            double PVol = 0.0;
            if (txtPumpVol.Text.Trim() == "")
            {
                PVol = 0.0;
            }
            else
            {
                PVol = Convert.ToDouble(txtPumpVol.Text.Trim());
            }

            double Vol = 0.0;
            if (dgvCurrentObj.Rows[0].Cells["Volume"].Value.ToString().Trim() == "")
            {
                Vol = 0.0;
            }
            else
            {
                Vol = Convert.ToDouble(dgvCurrentObj.Rows[0].Cells["Volume"].Value);
            }
            
            double percDiff = 0.0;
            if (Vol > 0.0 && PVol > 0.0)
            {
                percDiff = (Vol - PVol) / Vol;
                percDiff = percDiff * 100.0; //??
                percDiff = Math.Round(percDiff, 5);
            }
            


            lblVolDiffPerc.Text = "Volume Difference: " + percDiff.ToString() + " %";
            
            if (Math.Abs(percDiff) > maxVolumeDiffPerc && maxVolumeDiffPerc > 0.0)
            {
                if (percDiff > 0)
                {
                    lblVolDiffPerc.ForeColor = Color.Green;
                }
                else if (percDiff < 0)
                {
                    lblVolDiffPerc.ForeColor = Color.Red;
                }

                if (((Control)sender).GetType().Name.ToUpper() == "TEXTBOX")
                {
                    MessageBox.Show("Προσοχή! \r\nΕντοπίστηκε μεγάλη διαφορά στο πεδίο των λίτρων.");
                }
            }
            
        }

        private void txtPumpVol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if ((((TextBox)sender).Text.IndexOf(",") >= 0 || ((TextBox)sender).Text.Trim() == "" || ((TextBox)sender).SelectionStart == 0) && 
                e.KeyChar == 44) //only one decimal point & not first character
            {
                e.Handled = true;
            }

            //48 - 57 will be numbers
            //44 or 46 - decimal point (44: "," & 46: ".")
            //8 - backspace
        }

        private void txtSampleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allow only integers
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            //48 - 57 will be numbers
            //8 - backspace
        }

        


        private void btnMap_Click(object sender, EventArgs e)
        {
            string realLat = "";
            string realLong = "";

            /*if ((txtRealLat.Text.Trim() == "0" && txtRealLong.Text.Trim() == "0") || (txtRealLat.Text.Trim() == "" && txtRealLong.Text.Trim() == ""))
            {
                realLat = dgvCurrentObj["latitude", 0].Value.ToString().Replace('.', ',');
                realLong = dgvCurrentObj["longitude", 0].Value.ToString().Replace('.', ',');
            }
            else
            {
                realLat = txtRealLat.Text.Trim().Replace('.', ',');
                realLong = txtRealLong.Text.Trim().Replace('.', ',');
            }*/

            if ((txtRealLat.Text.Trim() == "0" && txtRealLong.Text.Trim() == "0") || (txtRealLat.Text.Trim() == "" && txtRealLong.Text.Trim() == ""))
            {
                realLat = dgvCurrentObj["latitude", 0].Value.ToString();
                realLong = dgvCurrentObj["longitude", 0].Value.ToString();
            }
            else
            {
                realLat = txtRealLat.Text.Trim();
                realLong = txtRealLong.Text.Trim();
            }

            String DecSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (DecSep == ",")
            {
                realLat = realLat.Replace('.', ',');
                realLong = realLong.Replace('.', ',');
            }
            else
            {
                realLat = realLat.Replace(',', '.');
                realLong = realLong.Replace(',', '.');
            }



            MapFormParams MapObj = new MapFormParams()
            {
                latitude = Convert.ToDouble(realLat), //dgvCurrentObj["latitude", 0].Value.ToString().Replace('.', ',')),   //38.2682,
                longitude = Convert.ToDouble(realLong), //dgvCurrentObj["longitude", 0].Value.ToString().Replace('.', ',')), //21.755,
                radius = 350, //meters
                apiKey = MapsApi.key, //"AIzaSyCxAKDi4ZgokHWCYK_5sQ8Dg-nlcLT2myo"
                connectionString = SQLiteDBMap.connectionString, //Stationsdb.db
                existsInternetConnection = NetworkConnections.CheckInternetConnection()
            };

            //map form
            //SearchPlace frmMap = new SearchPlace(MapObj); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //frmMap.ShowDialog(); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Form2 frmMap = new Form2(MapObj);
            frmMap.ShowDialog();

            //int id = frmMap.mapFormGeoData.id;
            //string name = frmMap.mapFormGeoData.name;
            //string address = frmMap.mapFormGeoData.address;

            //MessageBox.Show(id.ToString() + "\r\n" + name + "\r\n" + address);

            //lblGeostationId.Text = frmMap.mapFormGeoData.id.ToString();
            //txtDealer.Text = frmMap.mapFormGeoData.name;
            //txtAddress.Text = frmMap.mapFormGeoData.address;

            if (frmMap.GleoPass.id > 0)
            {
                lblGeostationId.Text = frmMap.GleoPass.id.ToString();
                txtAddress.Text = frmMap.GleoPass.address;
                txtDealer.Text = frmMap.GleoPass.name;

                if (brands.Exists(i => i.Id == frmMap.GleoPass.brand_id))
                {
                    cbBrand.SelectedIndex = cbBrand.FindStringExact(brands.Where(i => i.Id == frmMap.GleoPass.brand_id).First().Name); //OK!
                }
                
                txtAddress.ReadOnly = true;
                txtDealer.ReadOnly = true;
                cbBrand.Enabled = false;
            }

            frmMap.Dispose_gMap();
        }

        private void btnRealLatLong_Click(object sender, EventArgs e)
        {
            frmRealCoordinates frmRealCoordinates = new frmRealCoordinates();

            frmRealCoordinates.realCoordinates = new Coordinates() { latitude = txtRealLat.Text, longitude = txtRealLong.Text };

            frmRealCoordinates.ShowDialog(this);

            txtRealLat.Text = frmRealCoordinates.realCoordinates.latitude; //obj.realCoordinates.latitude;
            txtRealLong.Text = frmRealCoordinates.realCoordinates.longitude; //obj.realCoordinates.longitude;
        }

        private void btnNewGeostation_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtAddress.ReadOnly = false;

            txtDealer.Text = "";
            txtDealer.ReadOnly = false;
                        
            cbBrand.Enabled = true;
            cbBrand.SelectedItem = null; //.Text = "";

            lblGeostationId.Text = "10"; //Id 10 = new gas station
        }

        private void AcceptanceForm_Load(object sender, EventArgs e)
        {
            tpRealLatLong.SetToolTip(btnRealLatLong, "Εύρεση Πραγματικών Συντεταγμένων");
            tpGeostation.SetToolTip(btnMap, "Εύρεση Πρατηρίου στο Χάρτη");
        }

        private void txtReceiptPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if ((((TextBox)sender).Text.IndexOf(",") >= 0 || ((TextBox)sender).Text.Trim() == "" || ((TextBox)sender).SelectionStart == 0) &&
                e.KeyChar == 44) //only one decimal point & not first character
            {
                e.Handled = true;
            }

            //48 - 57 will be numbers
            //44 or 46 - decimal point (44: "," & 46: ".")
            //8 - backspace
        }

        private void cbClosedReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClosedReason.SelectedIndex == 0) //Ελεύθερα Σχόλια
            {
                txtRemarks.Text = "";
                txtRemarks.Enabled = true;
                obj.station_Closed_Manually = false;
            }
            else
            {
                txtRemarks.Text = cbClosedReason.Text;
                txtRemarks.Enabled = false;
                txtPumpDex.Text = "0";
                txtPumpAntlia.Text = "0";
                txtPumpAkrof.Text = "0"; 
                txtPumpVol.Text = "0";
                cbProduct.SelectedIndex = 0;

                obj.station_Closed_Manually = ((Remarks)((ComboboxItem)cbClosedReason.SelectedItem).Value).IsClosed;
            }
        }

    }
}
