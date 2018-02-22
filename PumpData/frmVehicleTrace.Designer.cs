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
            this.KmDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Km = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevEntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvVehicleTraceList = new System.Windows.Forms.DataGridView();
            this.lblKm = new System.Windows.Forms.Label();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.lblConsumption = new System.Windows.Forms.Label();
            this.txtConsumption = new System.Windows.Forms.TextBox();
            this.lblTotConsumption = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTraceList)).BeginInit();
            this.SuspendLayout();
            // 
            // cbVehicleNo
            // 
            this.cbVehicleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbVehicleNo.FormattingEnabled = true;
            this.cbVehicleNo.Location = new System.Drawing.Point(145, 23);
            this.cbVehicleNo.Name = "cbVehicleNo";
            this.cbVehicleNo.Size = new System.Drawing.Size(160, 28);
            this.cbVehicleNo.TabIndex = 1;
            this.cbVehicleNo.SelectedIndexChanged += new System.EventHandler(this.cbVehicleNo_SelectedIndexChanged);
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(25, 26);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(95, 20);
            this.lblVehicleNo.TabIndex = 30;
            this.lblVehicleNo.Text = "Vehicle No";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(145, 71);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(95, 28);
            this.cbYear.TabIndex = 2;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(62, 74);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(47, 20);
            this.lblYear.TabIndex = 32;
            this.lblYear.Text = "Year";
            // 
            // KmDiff
            // 
            this.KmDiff.HeaderText = "KmDiff";
            this.KmDiff.Name = "KmDiff";
            this.KmDiff.ReadOnly = true;
            // 
            // Km
            // 
            this.Km.HeaderText = "Km";
            this.Km.Name = "Km";
            this.Km.ReadOnly = true;
            // 
            // EntryDate
            // 
            this.EntryDate.HeaderText = "EntryDate";
            this.EntryDate.Name = "EntryDate";
            this.EntryDate.ReadOnly = true;
            this.EntryDate.Width = 120;
            // 
            // Month
            // 
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            this.Month.ReadOnly = true;
            this.Month.Width = 90;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 80;
            // 
            // PrevKm
            // 
            this.PrevKm.HeaderText = "PrevKm";
            this.PrevKm.Name = "PrevKm";
            this.PrevKm.ReadOnly = true;
            // 
            // PrevEntryDate
            // 
            this.PrevEntryDate.HeaderText = "PrevEntryDate";
            this.PrevEntryDate.Name = "PrevEntryDate";
            this.PrevEntryDate.ReadOnly = true;
            this.PrevEntryDate.Width = 120;
            // 
            // PrevMonth
            // 
            this.PrevMonth.HeaderText = "PrevMonth";
            this.PrevMonth.Name = "PrevMonth";
            this.PrevMonth.ReadOnly = true;
            this.PrevMonth.Width = 90;
            // 
            // PrevYear
            // 
            this.PrevYear.HeaderText = "PrevYear";
            this.PrevYear.Name = "PrevYear";
            this.PrevYear.ReadOnly = true;
            this.PrevYear.Width = 80;
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
            this.PrevYear,
            this.PrevMonth,
            this.PrevEntryDate,
            this.PrevKm,
            this.Year,
            this.Month,
            this.EntryDate,
            this.Km,
            this.KmDiff});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicleTraceList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehicleTraceList.Location = new System.Drawing.Point(12, 140);
            this.dgvVehicleTraceList.MultiSelect = false;
            this.dgvVehicleTraceList.Name = "dgvVehicleTraceList";
            this.dgvVehicleTraceList.ReadOnly = true;
            this.dgvVehicleTraceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleTraceList.Size = new System.Drawing.Size(1000, 330);
            this.dgvVehicleTraceList.TabIndex = 3;
            this.dgvVehicleTraceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleTraceList_CellClick);
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKm.Location = new System.Drawing.Point(547, 74);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(34, 20);
            this.lblKm.TabIndex = 34;
            this.lblKm.Text = "Km";
            // 
            // txtKm
            // 
            this.txtKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKm.Location = new System.Drawing.Point(424, 71);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(100, 26);
            this.txtKm.TabIndex = 33;
            this.txtKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKm_KeyPress);
            // 
            // lblConsumption
            // 
            this.lblConsumption.AutoSize = true;
            this.lblConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblConsumption.Location = new System.Drawing.Point(547, 26);
            this.lblConsumption.Name = "lblConsumption";
            this.lblConsumption.Size = new System.Drawing.Size(85, 20);
            this.lblConsumption.TabIndex = 36;
            this.lblConsumption.Text = "Lt/100Km";
            // 
            // txtConsumption
            // 
            this.txtConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtConsumption.Location = new System.Drawing.Point(424, 23);
            this.txtConsumption.Name = "txtConsumption";
            this.txtConsumption.Size = new System.Drawing.Size(100, 26);
            this.txtConsumption.TabIndex = 35;
            this.txtConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumption_KeyPress);
            // 
            // lblTotConsumption
            // 
            this.lblTotConsumption.AutoSize = true;
            this.lblTotConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTotConsumption.Location = new System.Drawing.Point(746, 74);
            this.lblTotConsumption.Name = "lblTotConsumption";
            this.lblTotConsumption.Size = new System.Drawing.Size(75, 20);
            this.lblTotConsumption.TabIndex = 37;
            this.lblTotConsumption.Text = "Total Lt:";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMonth.Location = new System.Drawing.Point(757, 26);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(64, 20);
            this.lblMonth.TabIndex = 38;
            this.lblMonth.Text = "Month:";
            // 
            // btnCalc
            // 
            this.btnCalc.Enabled = false;
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCalc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalc.Location = new System.Drawing.Point(938, 43);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 40);
            this.btnCalc.TabIndex = 39;
            this.btnCalc.Text = "Calc";
            this.btnCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // frmVehicleTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 482);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblTotConsumption);
            this.Controls.Add(this.lblConsumption);
            this.Controls.Add(this.txtConsumption);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.dgvVehicleTraceList);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.lblVehicleNo);
            this.Controls.Add(this.cbVehicleNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn KmDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Km;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevEntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevYear;
        private System.Windows.Forms.DataGridView dgvVehicleTraceList;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.Label lblConsumption;
        private System.Windows.Forms.TextBox txtConsumption;
        private System.Windows.Forms.Label lblTotConsumption;
        private System.Windows.Forms.Label lblMonth;
        public System.Windows.Forms.Button btnCalc;
    }
}