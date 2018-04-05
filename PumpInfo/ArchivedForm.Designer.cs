namespace PumpInfo
{
    partial class ArchivedForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchivedForm));
            this.dgvReceiptData = new System.Windows.Forms.DataGridView();
            this.Vehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Driver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pump = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PumpVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeostationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbVehicle = new System.Windows.Forms.ComboBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblDtFrom = new System.Windows.Forms.Label();
            this.lblDtTo = new System.Windows.Forms.Label();
            this.btnGeostation = new System.Windows.Forms.Button();
            this.cbColorMode = new System.Windows.Forms.CheckBox();
            this.cbDrivers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReceiptData
            // 
            this.dgvReceiptData.AllowUserToAddRows = false;
            this.dgvReceiptData.AllowUserToDeleteRows = false;
            this.dgvReceiptData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceiptData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceiptData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vehicle,
            this.Product,
            this.Driver,
            this.gridDateTime,
            this.Brand,
            this.Dealer,
            this.Address,
            this.Weight,
            this.Temp,
            this.Density,
            this.Volume,
            this.Pump,
            this.PumpVolume,
            this.VolDiff,
            this.GeostationId,
            this.SampleNo,
            this.Remarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptData.Location = new System.Drawing.Point(12, 83);
            this.dgvReceiptData.MultiSelect = false;
            this.dgvReceiptData.Name = "dgvReceiptData";
            this.dgvReceiptData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceiptData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceiptData.RowHeadersWidth = 25;
            this.dgvReceiptData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptData.Size = new System.Drawing.Size(1160, 407);
            this.dgvReceiptData.TabIndex = 12;
            // 
            // Vehicle
            // 
            this.Vehicle.HeaderText = "Vehicle";
            this.Vehicle.Name = "Vehicle";
            this.Vehicle.ReadOnly = true;
            this.Vehicle.Width = 64;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Driver
            // 
            this.Driver.HeaderText = "Driver";
            this.Driver.Name = "Driver";
            this.Driver.ReadOnly = true;
            this.Driver.Width = 75;
            // 
            // gridDateTime
            // 
            this.gridDateTime.HeaderText = "DateTime";
            this.gridDateTime.Name = "gridDateTime";
            this.gridDateTime.ReadOnly = true;
            this.gridDateTime.Width = 136;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 84;
            // 
            // Dealer
            // 
            this.Dealer.HeaderText = "Dealer";
            this.Dealer.Name = "Dealer";
            this.Dealer.ReadOnly = true;
            this.Dealer.Width = 140;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 140;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 64;
            // 
            // Temp
            // 
            this.Temp.HeaderText = "Temp";
            this.Temp.Name = "Temp";
            this.Temp.ReadOnly = true;
            this.Temp.Width = 60;
            // 
            // Density
            // 
            this.Density.HeaderText = "Density";
            this.Density.Name = "Density";
            this.Density.ReadOnly = true;
            this.Density.Width = 66;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            this.Volume.Width = 66;
            // 
            // Pump
            // 
            this.Pump.HeaderText = "Pump";
            this.Pump.Name = "Pump";
            this.Pump.ReadOnly = true;
            // 
            // PumpVolume
            // 
            this.PumpVolume.HeaderText = "PumpVolume";
            this.PumpVolume.Name = "PumpVolume";
            this.PumpVolume.ReadOnly = true;
            this.PumpVolume.Width = 105;
            // 
            // VolDiff
            // 
            this.VolDiff.HeaderText = "VolDiff";
            this.VolDiff.Name = "VolDiff";
            this.VolDiff.ReadOnly = true;
            this.VolDiff.Width = 80;
            // 
            // GeostationId
            // 
            this.GeostationId.HeaderText = "GeostationId";
            this.GeostationId.Name = "GeostationId";
            this.GeostationId.ReadOnly = true;
            this.GeostationId.Visible = false;
            // 
            // SampleNo
            // 
            this.SampleNo.HeaderText = "SampleNo";
            this.SampleNo.Name = "SampleNo";
            this.SampleNo.ReadOnly = true;
            this.SampleNo.Width = 84;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 75;
            // 
            // cbVehicle
            // 
            this.cbVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbVehicle.FormattingEnabled = true;
            this.cbVehicle.Items.AddRange(new object[] {
            "Όλα τα οχήματα",
            "Όχημα 1 - Βενζίνη",
            "Όχημα 2 - Diesel"});
            this.cbVehicle.Location = new System.Drawing.Point(12, 12);
            this.cbVehicle.Name = "cbVehicle";
            this.cbVehicle.Size = new System.Drawing.Size(200, 24);
            this.cbVehicle.TabIndex = 29;
            this.cbVehicle.SelectedIndexChanged += new System.EventHandler(this.cbVehicle_SelectedIndexChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtFrom.Location = new System.Drawing.Point(287, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(234, 22);
            this.dtFrom.TabIndex = 30;
            this.dtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtTo.Location = new System.Drawing.Point(287, 40);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(234, 22);
            this.dtTo.TabIndex = 31;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // lblDtFrom
            // 
            this.lblDtFrom.AutoSize = true;
            this.lblDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtFrom.Location = new System.Drawing.Point(248, 15);
            this.lblDtFrom.Name = "lblDtFrom";
            this.lblDtFrom.Size = new System.Drawing.Size(33, 16);
            this.lblDtFrom.TabIndex = 32;
            this.lblDtFrom.Text = "Από";
            // 
            // lblDtTo
            // 
            this.lblDtTo.AutoSize = true;
            this.lblDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtTo.Location = new System.Drawing.Point(248, 43);
            this.lblDtTo.Name = "lblDtTo";
            this.lblDtTo.Size = new System.Drawing.Size(33, 16);
            this.lblDtTo.TabIndex = 33;
            this.lblDtTo.Text = "Έως";
            // 
            // btnGeostation
            // 
            this.btnGeostation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnGeostation.Image = global::PumpInfo.Properties.Resources.GeoLocation_32x;
            this.btnGeostation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeostation.Location = new System.Drawing.Point(1012, 22);
            this.btnGeostation.Name = "btnGeostation";
            this.btnGeostation.Size = new System.Drawing.Size(160, 40);
            this.btnGeostation.TabIndex = 34;
            this.btnGeostation.Text = "Θέση στο Χάρτη";
            this.btnGeostation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeostation.UseVisualStyleBackColor = true;
            this.btnGeostation.Click += new System.EventHandler(this.btnGeostation_Click);
            // 
            // cbColorMode
            // 
            this.cbColorMode.AutoSize = true;
            this.cbColorMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbColorMode.Location = new System.Drawing.Point(838, 31);
            this.cbColorMode.Name = "cbColorMode";
            this.cbColorMode.Size = new System.Drawing.Size(168, 20);
            this.cbColorMode.TabIndex = 42;
            this.cbColorMode.Text = "Volume Diff Color Mode";
            this.cbColorMode.UseVisualStyleBackColor = true;
            this.cbColorMode.CheckedChanged += new System.EventHandler(this.cbColorMode_CheckedChanged);
            // 
            // cbDrivers
            // 
            this.cbDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbDrivers.FormattingEnabled = true;
            this.cbDrivers.Items.AddRange(new object[] {
            "Όλοι οι οδηγοί",
            "Βασίλης",
            "Ιωσήφ"});
            this.cbDrivers.Location = new System.Drawing.Point(12, 42);
            this.cbDrivers.Name = "cbDrivers";
            this.cbDrivers.Size = new System.Drawing.Size(200, 24);
            this.cbDrivers.TabIndex = 43;
            this.cbDrivers.SelectedIndexChanged += new System.EventHandler(this.cbDrivers_SelectedIndexChanged);
            // 
            // ArchivedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 502);
            this.Controls.Add(this.cbDrivers);
            this.Controls.Add(this.cbColorMode);
            this.Controls.Add(this.btnGeostation);
            this.Controls.Add(this.lblDtTo);
            this.Controls.Add(this.lblDtFrom);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.cbVehicle);
            this.Controls.Add(this.dgvReceiptData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 540);
            this.Name = "ArchivedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceiptData;
        private System.Windows.Forms.ComboBox cbVehicle;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblDtFrom;
        private System.Windows.Forms.Label lblDtTo;
        public System.Windows.Forms.Button btnGeostation;
        private System.Windows.Forms.CheckBox cbColorMode;
        private System.Windows.Forms.ComboBox cbDrivers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Driver;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Density;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pump;
        private System.Windows.Forms.DataGridViewTextBoxColumn PumpVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeostationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}