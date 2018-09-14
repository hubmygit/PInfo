namespace PumpData
{
    partial class frmShowDbData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDbData));
            this.dgvReceiptData = new System.Windows.Forms.DataGridView();
            this.cbGeoFilter = new System.Windows.Forms.ComboBox();
            this.btnNewGeoPoint = new System.Windows.Forms.Button();
            this.btnSampleFile = new System.Windows.Forms.Button();
            this.btnGridFields = new System.Windows.Forms.Button();
            this.btnGeostation = new System.Windows.Forms.Button();
            this.lblDtTo = new System.Windows.Forms.Label();
            this.lblDtFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbColorMode = new System.Windows.Forms.CheckBox();
            this.ReceiptDataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraDataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accepted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Vehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolDiffPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pump = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PumpVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeostationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealLong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmbientTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReceiptData
            // 
            this.dgvReceiptData.AllowUserToAddRows = false;
            this.dgvReceiptData.AllowUserToDeleteRows = false;
            this.dgvReceiptData.AllowUserToOrderColumns = true;
            this.dgvReceiptData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceiptData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceiptData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptDataId,
            this.ExtraDataId,
            this.Accepted,
            this.Vehicle,
            this.Date,
            this.Time,
            this.Latitude,
            this.Longitude,
            this.Weight,
            this.Temp,
            this.Density,
            this.Volume,
            this.VolDiffPerc,
            this.Brand,
            this.Dealer,
            this.Address,
            this.Product,
            this.Pump,
            this.PumpVol,
            this.SampleNo,
            this.Remarks,
            this.MachineNo,
            this.GeostationId,
            this.RealLat,
            this.RealLong,
            this.ProductGroup,
            this.ReceiptNo,
            this.ReceiptPrice,
            this.Driver,
            this.AmbientTemp});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptData.Location = new System.Drawing.Point(0, 80);
            this.dgvReceiptData.MultiSelect = false;
            this.dgvReceiptData.Name = "dgvReceiptData";
            this.dgvReceiptData.ReadOnly = true;
            this.dgvReceiptData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptData.Size = new System.Drawing.Size(1084, 397);
            this.dgvReceiptData.TabIndex = 15;
            this.dgvReceiptData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptData_CellDoubleClick);
            this.dgvReceiptData.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvReceiptData_SortCompare);
            // 
            // cbGeoFilter
            // 
            this.cbGeoFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGeoFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbGeoFilter.FormattingEnabled = true;
            this.cbGeoFilter.Location = new System.Drawing.Point(344, 31);
            this.cbGeoFilter.Name = "cbGeoFilter";
            this.cbGeoFilter.Size = new System.Drawing.Size(190, 28);
            this.cbGeoFilter.TabIndex = 33;
            this.cbGeoFilter.SelectedIndexChanged += new System.EventHandler(this.cbGeoFilter_SelectedIndexChanged);
            // 
            // btnNewGeoPoint
            // 
            this.btnNewGeoPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnNewGeoPoint.Image = global::PumpData.Properties.Resources.NewGeoPoint_32x;
            this.btnNewGeoPoint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewGeoPoint.Location = new System.Drawing.Point(540, 19);
            this.btnNewGeoPoint.Name = "btnNewGeoPoint";
            this.btnNewGeoPoint.Size = new System.Drawing.Size(160, 40);
            this.btnNewGeoPoint.TabIndex = 34;
            this.btnNewGeoPoint.Text = "Νέο Πρατήριο";
            this.btnNewGeoPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewGeoPoint.UseVisualStyleBackColor = true;
            this.btnNewGeoPoint.Click += new System.EventHandler(this.btnNewGeoPoint_Click);
            // 
            // btnSampleFile
            // 
            this.btnSampleFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSampleFile.Image = global::PumpData.Properties.Resources.PerformanceLog_32x;
            this.btnSampleFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSampleFile.Location = new System.Drawing.Point(12, 19);
            this.btnSampleFile.Name = "btnSampleFile";
            this.btnSampleFile.Size = new System.Drawing.Size(160, 40);
            this.btnSampleFile.TabIndex = 23;
            this.btnSampleFile.Text = "Αρχεία Δειγμάτων";
            this.btnSampleFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSampleFile.UseVisualStyleBackColor = true;
            this.btnSampleFile.Click += new System.EventHandler(this.btnSampleFile_Click);
            // 
            // btnGridFields
            // 
            this.btnGridFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnGridFields.Image = global::PumpData.Properties.Resources.CheckboxFieldColumn_32x;
            this.btnGridFields.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGridFields.Location = new System.Drawing.Point(912, 7);
            this.btnGridFields.Name = "btnGridFields";
            this.btnGridFields.Size = new System.Drawing.Size(160, 40);
            this.btnGridFields.TabIndex = 22;
            this.btnGridFields.Text = "Επιλογή Πεδίων";
            this.btnGridFields.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGridFields.UseVisualStyleBackColor = true;
            this.btnGridFields.Click += new System.EventHandler(this.btnGridFields_Click);
            // 
            // btnGeostation
            // 
            this.btnGeostation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnGeostation.Image = global::PumpData.Properties.Resources.GeoLocation_32x;
            this.btnGeostation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeostation.Location = new System.Drawing.Point(178, 19);
            this.btnGeostation.Name = "btnGeostation";
            this.btnGeostation.Size = new System.Drawing.Size(160, 40);
            this.btnGeostation.TabIndex = 21;
            this.btnGeostation.Text = "Θέση στο Χάρτη";
            this.btnGeostation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeostation.UseVisualStyleBackColor = true;
            this.btnGeostation.Click += new System.EventHandler(this.btnGeostation_Click);
            // 
            // lblDtTo
            // 
            this.lblDtTo.AutoSize = true;
            this.lblDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtTo.Location = new System.Drawing.Point(706, 43);
            this.lblDtTo.Name = "lblDtTo";
            this.lblDtTo.Size = new System.Drawing.Size(33, 16);
            this.lblDtTo.TabIndex = 38;
            this.lblDtTo.Text = "Έως";
            // 
            // lblDtFrom
            // 
            this.lblDtFrom.AutoSize = true;
            this.lblDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtFrom.Location = new System.Drawing.Point(706, 19);
            this.lblDtFrom.Name = "lblDtFrom";
            this.lblDtFrom.Size = new System.Drawing.Size(33, 16);
            this.lblDtFrom.TabIndex = 37;
            this.lblDtFrom.Text = "Από";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(745, 38);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(123, 22);
            this.dtTo.TabIndex = 36;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(745, 14);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(123, 22);
            this.dtFrom.TabIndex = 35;
            this.dtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCounter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripCounter
            // 
            this.toolStripCounter.Name = "toolStripCounter";
            this.toolStripCounter.Size = new System.Drawing.Size(71, 17);
            this.toolStripCounter.Text = "Εγγραφές: 0";
            // 
            // cbColorMode
            // 
            this.cbColorMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbColorMode.AutoSize = true;
            this.cbColorMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbColorMode.Location = new System.Drawing.Point(912, 53);
            this.cbColorMode.Name = "cbColorMode";
            this.cbColorMode.Size = new System.Drawing.Size(168, 20);
            this.cbColorMode.TabIndex = 41;
            this.cbColorMode.Text = "Volume Diff Color Mode";
            this.cbColorMode.UseVisualStyleBackColor = true;
            this.cbColorMode.CheckedChanged += new System.EventHandler(this.cbColorMode_CheckedChanged);
            // 
            // ReceiptDataId
            // 
            this.ReceiptDataId.HeaderText = "ReceiptDataId";
            this.ReceiptDataId.Name = "ReceiptDataId";
            this.ReceiptDataId.ReadOnly = true;
            this.ReceiptDataId.Visible = false;
            this.ReceiptDataId.Width = 60;
            // 
            // ExtraDataId
            // 
            this.ExtraDataId.HeaderText = "ExtraDataId";
            this.ExtraDataId.Name = "ExtraDataId";
            this.ExtraDataId.ReadOnly = true;
            this.ExtraDataId.Visible = false;
            // 
            // Accepted
            // 
            this.Accepted.HeaderText = "";
            this.Accepted.Name = "Accepted";
            this.Accepted.ReadOnly = true;
            this.Accepted.Visible = false;
            this.Accepted.Width = 50;
            // 
            // Vehicle
            // 
            this.Vehicle.HeaderText = "VehicleNo";
            this.Vehicle.Name = "Vehicle";
            this.Vehicle.ReadOnly = true;
            this.Vehicle.Visible = false;
            this.Vehicle.Width = 90;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 60;
            // 
            // Latitude
            // 
            this.Latitude.HeaderText = "Latitude";
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            this.Latitude.Visible = false;
            this.Latitude.Width = 90;
            // 
            // Longitude
            // 
            this.Longitude.HeaderText = "Longitude";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Longitude.Visible = false;
            this.Longitude.Width = 90;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 75;
            // 
            // Temp
            // 
            this.Temp.HeaderText = "Temp";
            this.Temp.Name = "Temp";
            this.Temp.ReadOnly = true;
            this.Temp.Width = 75;
            // 
            // Density
            // 
            this.Density.HeaderText = "Density";
            this.Density.Name = "Density";
            this.Density.ReadOnly = true;
            this.Density.Width = 75;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            this.Volume.Width = 75;
            // 
            // VolDiffPerc
            // 
            this.VolDiffPerc.HeaderText = "VolDiff%";
            this.VolDiffPerc.Name = "VolDiffPerc";
            this.VolDiffPerc.ReadOnly = true;
            this.VolDiffPerc.Width = 90;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 90;
            // 
            // Dealer
            // 
            this.Dealer.HeaderText = "Dealer";
            this.Dealer.Name = "Dealer";
            this.Dealer.ReadOnly = true;
            this.Dealer.Width = 150;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 150;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Pump
            // 
            this.Pump.HeaderText = "Pump";
            this.Pump.Name = "Pump";
            this.Pump.ReadOnly = true;
            this.Pump.Visible = false;
            this.Pump.Width = 70;
            // 
            // PumpVol
            // 
            this.PumpVol.HeaderText = "PumpVolume";
            this.PumpVol.Name = "PumpVol";
            this.PumpVol.ReadOnly = true;
            this.PumpVol.Width = 110;
            // 
            // SampleNo
            // 
            this.SampleNo.HeaderText = "SampleNo";
            this.SampleNo.Name = "SampleNo";
            this.SampleNo.ReadOnly = true;
            this.SampleNo.Width = 90;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 80;
            // 
            // MachineNo
            // 
            this.MachineNo.HeaderText = "MachineNo";
            this.MachineNo.Name = "MachineNo";
            this.MachineNo.ReadOnly = true;
            this.MachineNo.Visible = false;
            // 
            // GeostationId
            // 
            this.GeostationId.HeaderText = "Geostation";
            this.GeostationId.Name = "GeostationId";
            this.GeostationId.ReadOnly = true;
            this.GeostationId.Width = 95;
            // 
            // RealLat
            // 
            this.RealLat.HeaderText = "RealLat";
            this.RealLat.Name = "RealLat";
            this.RealLat.ReadOnly = true;
            this.RealLat.Visible = false;
            // 
            // RealLong
            // 
            this.RealLong.HeaderText = "RealLong";
            this.RealLong.Name = "RealLong";
            this.RealLong.ReadOnly = true;
            this.RealLong.Visible = false;
            // 
            // ProductGroup
            // 
            this.ProductGroup.HeaderText = "VehicleType";
            this.ProductGroup.Name = "ProductGroup";
            this.ProductGroup.ReadOnly = true;
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.HeaderText = "ReceiptNo";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.ReadOnly = true;
            this.ReceiptNo.Visible = false;
            // 
            // ReceiptPrice
            // 
            this.ReceiptPrice.HeaderText = "ReceiptPrice";
            this.ReceiptPrice.Name = "ReceiptPrice";
            this.ReceiptPrice.ReadOnly = true;
            // 
            // Driver
            // 
            this.Driver.HeaderText = "Driver";
            this.Driver.Name = "Driver";
            this.Driver.ReadOnly = true;
            // 
            // AmbientTemp
            // 
            this.AmbientTemp.HeaderText = "AmbientTemp";
            this.AmbientTemp.Name = "AmbientTemp";
            this.AmbientTemp.ReadOnly = true;
            this.AmbientTemp.Visible = false;
            this.AmbientTemp.Width = 110;
            // 
            // frmShowDbData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 502);
            this.Controls.Add(this.cbColorMode);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDtTo);
            this.Controls.Add(this.lblDtFrom);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.btnNewGeoPoint);
            this.Controls.Add(this.cbGeoFilter);
            this.Controls.Add(this.btnSampleFile);
            this.Controls.Add(this.btnGridFields);
            this.Controls.Add(this.btnGeostation);
            this.Controls.Add(this.dgvReceiptData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 540);
            this.Name = "frmShowDbData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Εμφάνιση Δεδομένων";
            this.Load += new System.EventHandler(this.frmShowDbData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceiptData;
        public System.Windows.Forms.Button btnGeostation;
        public System.Windows.Forms.Button btnGridFields;
        public System.Windows.Forms.Button btnSampleFile;
        private System.Windows.Forms.ComboBox cbGeoFilter;
        public System.Windows.Forms.Button btnNewGeoPoint;
        private System.Windows.Forms.Label lblDtTo;
        private System.Windows.Forms.Label lblDtFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCounter;
        private System.Windows.Forms.CheckBox cbColorMode;
        public System.Windows.Forms.DateTimePicker dtTo;
        public System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraDataId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Accepted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Density;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolDiffPerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pump;
        private System.Windows.Forms.DataGridViewTextBoxColumn PumpVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeostationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealLong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmbientTemp;
    }
}