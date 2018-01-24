namespace PumpInfo
{
    partial class AcceptanceForm
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
            this.dgvCurrentObj = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblDealer = new System.Windows.Forms.Label();
            this.txtDealer = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPumpVol = new System.Windows.Forms.Label();
            this.txtPumpVol = new System.Windows.Forms.TextBox();
            this.lblPump = new System.Windows.Forms.Label();
            this.txtPump = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblVolDiffPerc = new System.Windows.Forms.Label();
            this.lblSampleNo = new System.Windows.Forms.Label();
            this.txtSampleNo = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnMap = new System.Windows.Forms.Button();
            this.lblGeostationIdTitle = new System.Windows.Forms.Label();
            this.lblGeostationId = new System.Windows.Forms.Label();
            this.lblRealLat = new System.Windows.Forms.Label();
            this.lblRealLong = new System.Windows.Forms.Label();
            this.txtRealLat = new System.Windows.Forms.TextBox();
            this.txtRealLong = new System.Windows.Forms.TextBox();
            this.btnRealLatLong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentObj)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCurrentObj
            // 
            this.dgvCurrentObj.AllowUserToAddRows = false;
            this.dgvCurrentObj.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrentObj.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCurrentObj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentObj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Accepted,
            this.Vehicle,
            this.Date,
            this.Time,
            this.Latitude,
            this.Longitude,
            this.Weight,
            this.Temp,
            this.Density,
            this.Volume});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentObj.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCurrentObj.Location = new System.Drawing.Point(12, 80);
            this.dgvCurrentObj.MultiSelect = false;
            this.dgvCurrentObj.Name = "dgvCurrentObj";
            this.dgvCurrentObj.ReadOnly = true;
            this.dgvCurrentObj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentObj.Size = new System.Drawing.Size(880, 90);
            this.dgvCurrentObj.TabIndex = 12;
            // 
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Visible = false;
            this.Index.Width = 60;
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
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblBrand.Location = new System.Drawing.Point(87, 213);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(44, 16);
            this.lblBrand.TabIndex = 14;
            this.lblBrand.Text = "Brand";
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDealer.Location = new System.Drawing.Point(500, 213);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(49, 16);
            this.lblDealer.TabIndex = 16;
            this.lblDealer.Text = "Dealer";
            // 
            // txtDealer
            // 
            this.txtDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDealer.Location = new System.Drawing.Point(555, 210);
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.Size = new System.Drawing.Size(280, 22);
            this.txtDealer.TabIndex = 15;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAddress.Location = new System.Drawing.Point(490, 263);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 16);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAddress.Location = new System.Drawing.Point(555, 260);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(280, 22);
            this.txtAddress.TabIndex = 17;
            // 
            // lblPumpVol
            // 
            this.lblPumpVol.AutoSize = true;
            this.lblPumpVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPumpVol.Location = new System.Drawing.Point(457, 381);
            this.lblPumpVol.Name = "lblPumpVol";
            this.lblPumpVol.Size = new System.Drawing.Size(92, 16);
            this.lblPumpVol.TabIndex = 24;
            this.lblPumpVol.Text = "Pump Volume";
            // 
            // txtPumpVol
            // 
            this.txtPumpVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtPumpVol.Location = new System.Drawing.Point(555, 378);
            this.txtPumpVol.Name = "txtPumpVol";
            this.txtPumpVol.Size = new System.Drawing.Size(280, 22);
            this.txtPumpVol.TabIndex = 23;
            this.txtPumpVol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPumpVol_KeyPress);
            this.txtPumpVol.Leave += new System.EventHandler(this.txtPumpVol_Leave);
            // 
            // lblPump
            // 
            this.lblPump.AutoSize = true;
            this.lblPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPump.Location = new System.Drawing.Point(506, 331);
            this.lblPump.Name = "lblPump";
            this.lblPump.Size = new System.Drawing.Size(43, 16);
            this.lblPump.TabIndex = 22;
            this.lblPump.Text = "Pump";
            // 
            // txtPump
            // 
            this.txtPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtPump.Location = new System.Drawing.Point(555, 328);
            this.txtPump.Name = "txtPump";
            this.txtPump.Size = new System.Drawing.Size(280, 22);
            this.txtPump.TabIndex = 21;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblProduct.Location = new System.Drawing.Point(77, 331);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(54, 16);
            this.lblProduct.TabIndex = 20;
            this.lblProduct.Text = "Product";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(757, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 40);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Έξοδος";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbBrand
            // 
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(137, 210);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(280, 24);
            this.cbBrand.TabIndex = 28;
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(137, 328);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(280, 24);
            this.cbProduct.TabIndex = 29;
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnDel.Image = global::PumpInfo.Properties.Resources.Cancel_32x;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(192, 23);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(135, 40);
            this.btnDel.TabIndex = 26;
            this.btnDel.Text = "Ακύρωση";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAdd.Image = global::PumpInfo.Properties.Resources.Save_32x;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 40);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Καταχώρηση";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblVolDiffPerc
            // 
            this.lblVolDiffPerc.AutoSize = true;
            this.lblVolDiffPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVolDiffPerc.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVolDiffPerc.Location = new System.Drawing.Point(552, 403);
            this.lblVolDiffPerc.Name = "lblVolDiffPerc";
            this.lblVolDiffPerc.Size = new System.Drawing.Size(142, 15);
            this.lblVolDiffPerc.TabIndex = 30;
            this.lblVolDiffPerc.Text = "Volume Diff Perc: 0.0";
            // 
            // lblSampleNo
            // 
            this.lblSampleNo.AutoSize = true;
            this.lblSampleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSampleNo.Location = new System.Drawing.Point(473, 446);
            this.lblSampleNo.Name = "lblSampleNo";
            this.lblSampleNo.Size = new System.Drawing.Size(76, 16);
            this.lblSampleNo.TabIndex = 31;
            this.lblSampleNo.Text = "Sample No";
            // 
            // txtSampleNo
            // 
            this.txtSampleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSampleNo.Location = new System.Drawing.Point(555, 443);
            this.txtSampleNo.Name = "txtSampleNo";
            this.txtSampleNo.Size = new System.Drawing.Size(280, 22);
            this.txtSampleNo.TabIndex = 32;
            this.txtSampleNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSampleNo_KeyPress);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRemarks.Location = new System.Drawing.Point(68, 403);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(63, 16);
            this.lblRemarks.TabIndex = 33;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRemarks.Location = new System.Drawing.Point(137, 400);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(280, 65);
            this.txtRemarks.TabIndex = 34;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(841, 259);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(23, 23);
            this.btnMap.TabIndex = 35;
            this.btnMap.Text = "*";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // lblGeostationIdTitle
            // 
            this.lblGeostationIdTitle.AutoSize = true;
            this.lblGeostationIdTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGeostationIdTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblGeostationIdTitle.Location = new System.Drawing.Point(552, 285);
            this.lblGeostationIdTitle.Name = "lblGeostationIdTitle";
            this.lblGeostationIdTitle.Size = new System.Drawing.Size(92, 15);
            this.lblGeostationIdTitle.TabIndex = 37;
            this.lblGeostationIdTitle.Text = "GeostationId:";
            // 
            // lblGeostationId
            // 
            this.lblGeostationId.AutoSize = true;
            this.lblGeostationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGeostationId.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblGeostationId.Location = new System.Drawing.Point(650, 285);
            this.lblGeostationId.Name = "lblGeostationId";
            this.lblGeostationId.Size = new System.Drawing.Size(15, 15);
            this.lblGeostationId.TabIndex = 38;
            this.lblGeostationId.Text = "0";
            // 
            // lblRealLat
            // 
            this.lblRealLat.AutoSize = true;
            this.lblRealLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRealLat.Location = new System.Drawing.Point(68, 248);
            this.lblRealLat.Name = "lblRealLat";
            this.lblRealLat.Size = new System.Drawing.Size(58, 16);
            this.lblRealLat.TabIndex = 39;
            this.lblRealLat.Text = "Real Lat";
            // 
            // lblRealLong
            // 
            this.lblRealLong.AutoSize = true;
            this.lblRealLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRealLong.Location = new System.Drawing.Point(61, 278);
            this.lblRealLong.Name = "lblRealLong";
            this.lblRealLong.Size = new System.Drawing.Size(70, 16);
            this.lblRealLong.TabIndex = 40;
            this.lblRealLong.Text = "Real Long";
            // 
            // txtRealLat
            // 
            this.txtRealLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRealLat.Location = new System.Drawing.Point(137, 245);
            this.txtRealLat.Name = "txtRealLat";
            this.txtRealLat.ReadOnly = true;
            this.txtRealLat.Size = new System.Drawing.Size(280, 22);
            this.txtRealLat.TabIndex = 41;
            // 
            // txtRealLong
            // 
            this.txtRealLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtRealLong.Location = new System.Drawing.Point(137, 275);
            this.txtRealLong.Name = "txtRealLong";
            this.txtRealLong.ReadOnly = true;
            this.txtRealLong.Size = new System.Drawing.Size(280, 22);
            this.txtRealLong.TabIndex = 42;
            // 
            // btnRealLatLong
            // 
            this.btnRealLatLong.Location = new System.Drawing.Point(423, 259);
            this.btnRealLatLong.Name = "btnRealLatLong";
            this.btnRealLatLong.Size = new System.Drawing.Size(23, 23);
            this.btnRealLatLong.TabIndex = 43;
            this.btnRealLatLong.Text = "*";
            this.btnRealLatLong.UseVisualStyleBackColor = true;
            this.btnRealLatLong.Click += new System.EventHandler(this.btnRealLatLong_Click);
            // 
            // AcceptanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(906, 502);
            this.Controls.Add(this.btnRealLatLong);
            this.Controls.Add(this.txtRealLong);
            this.Controls.Add(this.txtRealLat);
            this.Controls.Add(this.lblRealLong);
            this.Controls.Add(this.lblRealLat);
            this.Controls.Add(this.lblGeostationId);
            this.Controls.Add(this.lblGeostationIdTitle);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtSampleNo);
            this.Controls.Add(this.lblSampleNo);
            this.Controls.Add(this.lblVolDiffPerc);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblPumpVol);
            this.Controls.Add(this.txtPumpVol);
            this.Controls.Add(this.lblPump);
            this.Controls.Add(this.txtPump);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.txtDealer);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.dgvCurrentObj);
            this.MaximumSize = new System.Drawing.Size(922, 540);
            this.Name = "AcceptanceForm";
            this.Text = "AcceptanceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentObj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurrentObj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
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
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.TextBox txtDealer;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPumpVol;
        private System.Windows.Forms.TextBox txtPumpVol;
        private System.Windows.Forms.Label lblPump;
        private System.Windows.Forms.TextBox txtPump;
        private System.Windows.Forms.Label lblProduct;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Label lblVolDiffPerc;
        private System.Windows.Forms.Label lblSampleNo;
        private System.Windows.Forms.TextBox txtSampleNo;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Label lblGeostationIdTitle;
        private System.Windows.Forms.Label lblGeostationId;
        private System.Windows.Forms.Label lblRealLat;
        private System.Windows.Forms.Label lblRealLong;
        private System.Windows.Forms.TextBox txtRealLat;
        private System.Windows.Forms.TextBox txtRealLong;
        private System.Windows.Forms.Button btnRealLatLong;
    }
}