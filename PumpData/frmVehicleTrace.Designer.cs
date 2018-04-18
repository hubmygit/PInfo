namespace PumpData
{
    partial class frmVehicleTrace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleTrace));
            this.cbVehicleNo = new System.Windows.Forms.ComboBox();
            this.lblVehicleNo = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.dgvVehicleTraceList = new System.Windows.Forms.DataGridView();
            this.lblKm = new System.Windows.Forms.Label();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.lblConsUnit = new System.Windows.Forms.Label();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblAvCons = new System.Windows.Forms.Label();
            this.lblDist = new System.Windows.Forms.Label();
            this.lblPumpVol = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtPumpVol = new System.Windows.Forms.TextBox();
            this.txtVehVol = new System.Windows.Forms.TextBox();
            this.lblVehVol = new System.Windows.Forms.Label();
            this.lblTotCons = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtTotCons = new System.Windows.Forms.TextBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTotRecPrice = new System.Windows.Forms.Label();
            this.lblEuros = new System.Windows.Forms.Label();
            this.txtTotRecPrice = new System.Windows.Forms.TextBox();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KmFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KmTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KmDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PumpVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotReceiptPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTraceList)).BeginInit();
            this.SuspendLayout();
            // 
            // cbVehicleNo
            // 
            this.cbVehicleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbVehicleNo.FormattingEnabled = true;
            this.cbVehicleNo.Location = new System.Drawing.Point(86, 20);
            this.cbVehicleNo.Name = "cbVehicleNo";
            this.cbVehicleNo.Size = new System.Drawing.Size(160, 28);
            this.cbVehicleNo.TabIndex = 1;
            this.cbVehicleNo.SelectedIndexChanged += new System.EventHandler(this.cbVehicleNo_SelectedIndexChanged);
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(12, 23);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(68, 20);
            this.lblVehicleNo.TabIndex = 30;
            this.lblVehicleNo.Text = "Vehicle";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(16, 80);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(80, 28);
            this.cbYear.TabIndex = 2;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(12, 57);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(47, 20);
            this.lblYear.TabIndex = 32;
            this.lblYear.Text = "Year";
            // 
            // dgvVehicleTraceList
            // 
            this.dgvVehicleTraceList.AllowUserToAddRows = false;
            this.dgvVehicleTraceList.AllowUserToDeleteRows = false;
            this.dgvVehicleTraceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicleTraceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehicleTraceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleTraceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntryDate,
            this.KmFrom,
            this.KmTo,
            this.KmDiff,
            this.PumpVol,
            this.VehicleVol,
            this.TotReceiptPrice,
            this.DriverName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicleTraceList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehicleTraceList.Location = new System.Drawing.Point(12, 128);
            this.dgvVehicleTraceList.MultiSelect = false;
            this.dgvVehicleTraceList.Name = "dgvVehicleTraceList";
            this.dgvVehicleTraceList.ReadOnly = true;
            this.dgvVehicleTraceList.RowHeadersWidth = 38;
            this.dgvVehicleTraceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleTraceList.Size = new System.Drawing.Size(1135, 342);
            this.dgvVehicleTraceList.TabIndex = 3;
            this.dgvVehicleTraceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleTraceList_CellClick);
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKm.Location = new System.Drawing.Point(563, 57);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(32, 20);
            this.lblKm.TabIndex = 34;
            this.lblKm.Text = "Km";
            // 
            // txtKm
            // 
            this.txtKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKm.Location = new System.Drawing.Point(457, 54);
            this.txtKm.Name = "txtKm";
            this.txtKm.ReadOnly = true;
            this.txtKm.Size = new System.Drawing.Size(100, 26);
            this.txtKm.TabIndex = 33;
            this.txtKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKm_KeyPress);
            // 
            // lblConsUnit
            // 
            this.lblConsUnit.AutoSize = true;
            this.lblConsUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblConsUnit.Location = new System.Drawing.Point(563, 25);
            this.lblConsUnit.Name = "lblConsUnit";
            this.lblConsUnit.Size = new System.Drawing.Size(77, 20);
            this.lblConsUnit.TabIndex = 36;
            this.lblConsUnit.Text = "Lt/100Km";
            // 
            // txtConsumption
            // 
            this.txtConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtConsumption.Location = new System.Drawing.Point(457, 22);
            this.txtConsumption.Name = "txtConsumption";
            this.txtConsumption.Size = new System.Drawing.Size(100, 26);
            this.txtConsumption.TabIndex = 35;
            this.txtConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumption_KeyPress);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMonth.Location = new System.Drawing.Point(98, 57);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(59, 20);
            this.lblMonth.TabIndex = 38;
            this.lblMonth.Text = "Month";
            // 
            // lblAvCons
            // 
            this.lblAvCons.AutoSize = true;
            this.lblAvCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblAvCons.Location = new System.Drawing.Point(307, 25);
            this.lblAvCons.Name = "lblAvCons";
            this.lblAvCons.Size = new System.Drawing.Size(144, 20);
            this.lblAvCons.TabIndex = 40;
            this.lblAvCons.Text = "Av. Consumption";
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDist.Location = new System.Drawing.Point(371, 57);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(80, 20);
            this.lblDist.TabIndex = 41;
            this.lblDist.Text = "Distance";
            // 
            // lblPumpVol
            // 
            this.lblPumpVol.AutoSize = true;
            this.lblPumpVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPumpVol.Location = new System.Drawing.Point(950, 25);
            this.lblPumpVol.Name = "lblPumpVol";
            this.lblPumpVol.Size = new System.Drawing.Size(75, 20);
            this.lblPumpVol.TabIndex = 42;
            this.lblPumpVol.Text = "Pump Lt";
            // 
            // txtDay
            // 
            this.txtDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDay.Location = new System.Drawing.Point(188, 80);
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size(80, 26);
            this.txtDay.TabIndex = 43;
            // 
            // txtPumpVol
            // 
            this.txtPumpVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtPumpVol.Location = new System.Drawing.Point(1031, 22);
            this.txtPumpVol.Name = "txtPumpVol";
            this.txtPumpVol.ReadOnly = true;
            this.txtPumpVol.Size = new System.Drawing.Size(100, 26);
            this.txtPumpVol.TabIndex = 45;
            // 
            // txtVehVol
            // 
            this.txtVehVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtVehVol.Location = new System.Drawing.Point(1031, 54);
            this.txtVehVol.Name = "txtVehVol";
            this.txtVehVol.ReadOnly = true;
            this.txtVehVol.Size = new System.Drawing.Size(100, 26);
            this.txtVehVol.TabIndex = 47;
            // 
            // lblVehVol
            // 
            this.lblVehVol.AutoSize = true;
            this.lblVehVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehVol.Location = new System.Drawing.Point(936, 57);
            this.lblVehVol.Name = "lblVehVol";
            this.lblVehVol.Size = new System.Drawing.Size(89, 20);
            this.lblVehVol.TabIndex = 46;
            this.lblVehVol.Text = "Vehicle Lt";
            // 
            // lblTotCons
            // 
            this.lblTotCons.AutoSize = true;
            this.lblTotCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTotCons.Location = new System.Drawing.Point(703, 57);
            this.lblTotCons.Name = "lblTotCons";
            this.lblTotCons.Size = new System.Drawing.Size(70, 20);
            this.lblTotCons.TabIndex = 37;
            this.lblTotCons.Text = "Total Lt";
            // 
            // btnCalc
            // 
            this.btnCalc.Enabled = false;
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCalc.Image = global::PumpData.Properties.Resources.MeasureCalculate_32x;
            this.btnCalc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalc.Location = new System.Drawing.Point(707, 11);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(172, 37);
            this.btnCalc.TabIndex = 39;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtTotCons
            // 
            this.txtTotCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTotCons.Location = new System.Drawing.Point(779, 54);
            this.txtTotCons.Name = "txtTotCons";
            this.txtTotCons.ReadOnly = true;
            this.txtTotCons.Size = new System.Drawing.Size(100, 26);
            this.txtTotCons.TabIndex = 44;
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Enabled = false;
            this.cbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(102, 80);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(80, 28);
            this.cbMonth.TabIndex = 48;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDay.Location = new System.Drawing.Point(184, 57);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(40, 20);
            this.lblDay.TabIndex = 49;
            this.lblDay.Text = "Day";
            // 
            // lblTotRecPrice
            // 
            this.lblTotRecPrice.AutoSize = true;
            this.lblTotRecPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTotRecPrice.Location = new System.Drawing.Point(898, 89);
            this.lblTotRecPrice.Name = "lblTotRecPrice";
            this.lblTotRecPrice.Size = new System.Drawing.Size(127, 20);
            this.lblTotRecPrice.TabIndex = 50;
            this.lblTotRecPrice.Text = "Tot. Rec. Price";
            // 
            // lblEuros
            // 
            this.lblEuros.AutoSize = true;
            this.lblEuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblEuros.Location = new System.Drawing.Point(1137, 89);
            this.lblEuros.Name = "lblEuros";
            this.lblEuros.Size = new System.Drawing.Size(18, 20);
            this.lblEuros.TabIndex = 51;
            this.lblEuros.Text = "€";
            // 
            // txtTotRecPrice
            // 
            this.txtTotRecPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTotRecPrice.Location = new System.Drawing.Point(1031, 86);
            this.txtTotRecPrice.Name = "txtTotRecPrice";
            this.txtTotRecPrice.ReadOnly = true;
            this.txtTotRecPrice.Size = new System.Drawing.Size(100, 26);
            this.txtTotRecPrice.TabIndex = 52;
            // 
            // EntryDate
            // 
            this.EntryDate.HeaderText = "Entry Date";
            this.EntryDate.Name = "EntryDate";
            this.EntryDate.ReadOnly = true;
            this.EntryDate.Width = 150;
            // 
            // KmFrom
            // 
            this.KmFrom.HeaderText = "Km From";
            this.KmFrom.Name = "KmFrom";
            this.KmFrom.ReadOnly = true;
            // 
            // KmTo
            // 
            this.KmTo.HeaderText = "Km To";
            this.KmTo.Name = "KmTo";
            this.KmTo.ReadOnly = true;
            // 
            // KmDiff
            // 
            this.KmDiff.HeaderText = "Km Diff";
            this.KmDiff.Name = "KmDiff";
            this.KmDiff.ReadOnly = true;
            // 
            // PumpVol
            // 
            this.PumpVol.HeaderText = "Pump Vol.";
            this.PumpVol.Name = "PumpVol";
            this.PumpVol.ReadOnly = true;
            this.PumpVol.Width = 120;
            // 
            // VehicleVol
            // 
            this.VehicleVol.HeaderText = "Vehicle Vol.";
            this.VehicleVol.Name = "VehicleVol";
            this.VehicleVol.ReadOnly = true;
            this.VehicleVol.Width = 120;
            // 
            // TotReceiptPrice
            // 
            this.TotReceiptPrice.HeaderText = "Receipt Price";
            this.TotReceiptPrice.Name = "TotReceiptPrice";
            this.TotReceiptPrice.ReadOnly = true;
            this.TotReceiptPrice.Width = 140;
            // 
            // DriverName
            // 
            this.DriverName.HeaderText = "Driver";
            this.DriverName.Name = "DriverName";
            this.DriverName.ReadOnly = true;
            this.DriverName.Width = 120;
            // 
            // frmVehicleTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 482);
            this.Controls.Add(this.txtTotRecPrice);
            this.Controls.Add(this.lblEuros);
            this.Controls.Add(this.lblTotRecPrice);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.txtTotCons);
            this.Controls.Add(this.lblTotCons);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.txtVehVol);
            this.Controls.Add(this.lblVehVol);
            this.Controls.Add(this.txtPumpVol);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.lblPumpVol);
            this.Controls.Add(this.lblDist);
            this.Controls.Add(this.lblAvCons);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblConsUnit);
            this.Controls.Add(this.txtConsumption);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.dgvVehicleTraceList);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.lblVehicleNo);
            this.Controls.Add(this.cbVehicleNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1175, 520);
            this.Name = "frmVehicleTrace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle Trace";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTraceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbVehicleNo;
        private System.Windows.Forms.Label lblVehicleNo;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.DataGridView dgvVehicleTraceList;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.Label lblConsUnit;
        private System.Windows.Forms.TextBox txtConsumption;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblAvCons;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lblPumpVol;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtPumpVol;
        private System.Windows.Forms.TextBox txtVehVol;
        private System.Windows.Forms.Label lblVehVol;
        private System.Windows.Forms.Label lblTotCons;
        public System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtTotCons;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTotRecPrice;
        private System.Windows.Forms.Label lblEuros;
        private System.Windows.Forms.TextBox txtTotRecPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn PumpVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotReceiptPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverName;
    }
}