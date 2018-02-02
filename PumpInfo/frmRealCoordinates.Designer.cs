namespace PumpInfo
{
    partial class frmRealCoordinates
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
            this.dgvRealCoordinates = new System.Windows.Forms.DataGridView();
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
            this.cbLinesFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealCoordinates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRealCoordinates
            // 
            this.dgvRealCoordinates.AllowUserToAddRows = false;
            this.dgvRealCoordinates.AllowUserToDeleteRows = false;
            this.dgvRealCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRealCoordinates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRealCoordinates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealCoordinates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Volume});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRealCoordinates.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRealCoordinates.Location = new System.Drawing.Point(12, 81);
            this.dgvRealCoordinates.MultiSelect = false;
            this.dgvRealCoordinates.Name = "dgvRealCoordinates";
            this.dgvRealCoordinates.ReadOnly = true;
            this.dgvRealCoordinates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRealCoordinates.Size = new System.Drawing.Size(880, 269);
            this.dgvRealCoordinates.TabIndex = 13;
            this.dgvRealCoordinates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRealCoordinates_CellDoubleClick);
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
            // cbLinesFilter
            // 
            this.cbLinesFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLinesFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbLinesFilter.FormattingEnabled = true;
            this.cbLinesFilter.Location = new System.Drawing.Point(12, 24);
            this.cbLinesFilter.Name = "cbLinesFilter";
            this.cbLinesFilter.Size = new System.Drawing.Size(280, 28);
            this.cbLinesFilter.TabIndex = 32;
            this.cbLinesFilter.SelectedIndexChanged += new System.EventHandler(this.cbLinesFilter_SelectedIndexChanged);
            // 
            // frmRealCoordinates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 362);
            this.Controls.Add(this.cbLinesFilter);
            this.Controls.Add(this.dgvRealCoordinates);
            this.Name = "frmRealCoordinates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Real Coordinates";
            this.Load += new System.EventHandler(this.frmRealCoordinates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealCoordinates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRealCoordinates;
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
        private System.Windows.Forms.ComboBox cbLinesFilter;
    }
}