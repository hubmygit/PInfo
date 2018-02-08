namespace PumpAnalysis
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTraceList)).BeginInit();
            this.SuspendLayout();
            // 
            // cbVehicleNo
            // 
            this.cbVehicleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbVehicleNo.FormattingEnabled = true;
            this.cbVehicleNo.Location = new System.Drawing.Point(394, 56);
            this.cbVehicleNo.Name = "cbVehicleNo";
            this.cbVehicleNo.Size = new System.Drawing.Size(100, 24);
            this.cbVehicleNo.TabIndex = 29;
            this.cbVehicleNo.SelectedIndexChanged += new System.EventHandler(this.cbVehicleNo_SelectedIndexChanged);
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(407, 37);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(74, 16);
            this.lblVehicleNo.TabIndex = 30;
            this.lblVehicleNo.Text = "Vehicle No";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(530, 56);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(100, 24);
            this.cbYear.TabIndex = 31;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblYear.Location = new System.Drawing.Point(562, 37);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 16);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicleTraceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehicleTraceList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVehicleTraceList.Location = new System.Drawing.Point(12, 126);
            this.dgvVehicleTraceList.MultiSelect = false;
            this.dgvVehicleTraceList.Name = "dgvVehicleTraceList";
            this.dgvVehicleTraceList.ReadOnly = true;
            this.dgvVehicleTraceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleTraceList.Size = new System.Drawing.Size(1000, 402);
            this.dgvVehicleTraceList.TabIndex = 33;
            // 
            // frmVehicleTrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 540);
            this.Controls.Add(this.dgvVehicleTraceList);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.lblVehicleNo);
            this.Controls.Add(this.cbVehicleNo);
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
    }
}