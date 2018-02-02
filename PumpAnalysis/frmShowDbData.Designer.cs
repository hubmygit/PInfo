﻿namespace PumpAnalysis
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
            this.dgvReceiptData = new System.Windows.Forms.DataGridView();
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
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddGeostation = new System.Windows.Forms.Button();
            this.btnShowVehicleTrace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).BeginInit();
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
            this.RealLong});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptData.Location = new System.Drawing.Point(12, 80);
            this.dgvReceiptData.MultiSelect = false;
            this.dgvReceiptData.Name = "dgvReceiptData";
            this.dgvReceiptData.ReadOnly = true;
            this.dgvReceiptData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptData.Size = new System.Drawing.Size(950, 410);
            this.dgvReceiptData.TabIndex = 15;
            this.dgvReceiptData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptData_CellDoubleClick);
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
            this.Accepted.Width = 50;
            // 
            // Vehicle
            // 
            this.Vehicle.HeaderText = "VehicleNo";
            this.Vehicle.Name = "Vehicle";
            this.Vehicle.ReadOnly = true;
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
            this.Latitude.Width = 90;
            // 
            // Longitude
            // 
            this.Longitude.HeaderText = "Longitude";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Longitude.Width = 90;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 80;
            // 
            // Temp
            // 
            this.Temp.HeaderText = "Temp";
            this.Temp.Name = "Temp";
            this.Temp.ReadOnly = true;
            this.Temp.Width = 80;
            // 
            // Density
            // 
            this.Density.HeaderText = "Density";
            this.Density.Name = "Density";
            this.Density.ReadOnly = true;
            this.Density.Width = 80;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            this.Volume.Width = 80;
            // 
            // VolDiffPerc
            // 
            this.VolDiffPerc.HeaderText = "VolDiff%";
            this.VolDiffPerc.Name = "VolDiffPerc";
            this.VolDiffPerc.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // Dealer
            // 
            this.Dealer.HeaderText = "Dealer";
            this.Dealer.Name = "Dealer";
            this.Dealer.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
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
            // 
            // MachineNo
            // 
            this.MachineNo.HeaderText = "MachineNo";
            this.MachineNo.Name = "MachineNo";
            this.MachineNo.ReadOnly = true;
            // 
            // GeostationId
            // 
            this.GeostationId.HeaderText = "GeostationId";
            this.GeostationId.Name = "GeostationId";
            this.GeostationId.ReadOnly = true;
            // 
            // RealLat
            // 
            this.RealLat.HeaderText = "RealLat";
            this.RealLat.Name = "RealLat";
            this.RealLat.ReadOnly = true;
            // 
            // RealLong
            // 
            this.RealLong.HeaderText = "RealLong";
            this.RealLong.Name = "RealLong";
            this.RealLong.ReadOnly = true;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(12, 28);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(123, 23);
            this.btnAddFile.TabIndex = 16;
            this.btnAddFile.Text = "Sample File(s)";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddGeostation
            // 
            this.btnAddGeostation.Location = new System.Drawing.Point(853, 28);
            this.btnAddGeostation.Name = "btnAddGeostation";
            this.btnAddGeostation.Size = new System.Drawing.Size(109, 23);
            this.btnAddGeostation.TabIndex = 17;
            this.btnAddGeostation.Text = "Geostation";
            this.btnAddGeostation.UseVisualStyleBackColor = true;
            this.btnAddGeostation.Click += new System.EventHandler(this.btnAddGeostation_Click);
            // 
            // btnShowVehicleTrace
            // 
            this.btnShowVehicleTrace.Location = new System.Drawing.Point(259, 28);
            this.btnShowVehicleTrace.Name = "btnShowVehicleTrace";
            this.btnShowVehicleTrace.Size = new System.Drawing.Size(109, 23);
            this.btnShowVehicleTrace.TabIndex = 18;
            this.btnShowVehicleTrace.Text = "Vehicle Trace";
            this.btnShowVehicleTrace.UseVisualStyleBackColor = true;
            this.btnShowVehicleTrace.Click += new System.EventHandler(this.btnShowVehicleTrace_Click);
            // 
            // frmShowDbData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 502);
            this.Controls.Add(this.btnShowVehicleTrace);
            this.Controls.Add(this.btnAddGeostation);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.dgvReceiptData);
            this.Name = "frmShowDbData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Εμφάνιση Δεδομένων";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceiptData;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddGeostation;
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
        private System.Windows.Forms.Button btnShowVehicleTrace;
    }
}