namespace PumpInfo
{
    partial class Scheduler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            this.lblVehicleNo = new System.Windows.Forms.Label();
            this.cbVehicleNo = new System.Windows.Forms.ComboBox();
            this.dgvDistricts = new System.Windows.Forms.DataGridView();
            this.dgvNomoi = new System.Windows.Forms.DataGridView();
            this.DistrictId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeoDistricts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomoiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomoiDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerioxesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPerioxes = new System.Windows.Forms.DataGridView();
            this.PerioxhId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perioxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerioxes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(35, 32);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(68, 20);
            this.lblVehicleNo.TabIndex = 34;
            this.lblVehicleNo.Text = "Vehicle";
            // 
            // cbVehicleNo
            // 
            this.cbVehicleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbVehicleNo.FormattingEnabled = true;
            this.cbVehicleNo.Location = new System.Drawing.Point(109, 29);
            this.cbVehicleNo.Name = "cbVehicleNo";
            this.cbVehicleNo.Size = new System.Drawing.Size(160, 28);
            this.cbVehicleNo.TabIndex = 33;
            this.cbVehicleNo.SelectedIndexChanged += new System.EventHandler(this.cbVehicleNo_SelectedIndexChanged);
            // 
            // dgvDistricts
            // 
            this.dgvDistricts.AllowUserToAddRows = false;
            this.dgvDistricts.AllowUserToDeleteRows = false;
            this.dgvDistricts.AllowUserToOrderColumns = true;
            this.dgvDistricts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDistricts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistricts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DistrictId,
            this.GeoDistricts});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDistricts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDistricts.Location = new System.Drawing.Point(12, 79);
            this.dgvDistricts.MultiSelect = false;
            this.dgvDistricts.Name = "dgvDistricts";
            this.dgvDistricts.RowHeadersVisible = false;
            this.dgvDistricts.RowHeadersWidth = 10;
            this.dgvDistricts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDistricts.Size = new System.Drawing.Size(215, 170);
            this.dgvDistricts.TabIndex = 35;
            this.dgvDistricts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistricts_CellClick);
            // 
            // dgvNomoi
            // 
            this.dgvNomoi.AllowUserToAddRows = false;
            this.dgvNomoi.AllowUserToDeleteRows = false;
            this.dgvNomoi.AllowUserToOrderColumns = true;
            this.dgvNomoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNomoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNomoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNomoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomoiId,
            this.NomoiDescr});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNomoi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNomoi.Location = new System.Drawing.Point(233, 79);
            this.dgvNomoi.MultiSelect = false;
            this.dgvNomoi.Name = "dgvNomoi";
            this.dgvNomoi.RowHeadersVisible = false;
            this.dgvNomoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNomoi.Size = new System.Drawing.Size(230, 270);
            this.dgvNomoi.TabIndex = 36;
            this.dgvNomoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNomoi_CellClick);
            // 
            // DistrictId
            // 
            this.DistrictId.HeaderText = "DistrictId";
            this.DistrictId.Name = "DistrictId";
            this.DistrictId.Visible = false;
            this.DistrictId.Width = 60;
            // 
            // GeoDistricts
            // 
            this.GeoDistricts.HeaderText = "Γεωγραφικές Περιοχές";
            this.GeoDistricts.Name = "GeoDistricts";
            this.GeoDistricts.ReadOnly = true;
            this.GeoDistricts.Width = 200;
            // 
            // NomoiId
            // 
            this.NomoiId.HeaderText = "NomoiId";
            this.NomoiId.Name = "NomoiId";
            this.NomoiId.Visible = false;
            this.NomoiId.Width = 60;
            // 
            // NomoiDescr
            // 
            this.NomoiDescr.HeaderText = "Νομοί";
            this.NomoiDescr.Name = "NomoiDescr";
            this.NomoiDescr.ReadOnly = true;
            this.NomoiDescr.Width = 200;
            // 
            // PerioxesId
            // 
            this.PerioxesId.HeaderText = "PerioxesId";
            this.PerioxesId.Name = "PerioxesId";
            this.PerioxesId.Visible = false;
            this.PerioxesId.Width = 60;
            // 
            // dgvPerioxes
            // 
            this.dgvPerioxes.AllowUserToAddRows = false;
            this.dgvPerioxes.AllowUserToDeleteRows = false;
            this.dgvPerioxes.AllowUserToOrderColumns = true;
            this.dgvPerioxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPerioxes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPerioxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerioxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PerioxhId,
            this.Perioxh});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPerioxes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPerioxes.Location = new System.Drawing.Point(469, 79);
            this.dgvPerioxes.MultiSelect = false;
            this.dgvPerioxes.Name = "dgvPerioxes";
            this.dgvPerioxes.RowHeadersVisible = false;
            this.dgvPerioxes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerioxes.Size = new System.Drawing.Size(230, 270);
            this.dgvPerioxes.TabIndex = 37;
            // 
            // PerioxhId
            // 
            this.PerioxhId.HeaderText = "PerioxhId";
            this.PerioxhId.Name = "PerioxhId";
            this.PerioxhId.Visible = false;
            this.PerioxhId.Width = 60;
            // 
            // Perioxh
            // 
            this.Perioxh.HeaderText = "Περιοχές";
            this.Perioxh.Name = "Perioxh";
            this.Perioxh.ReadOnly = true;
            this.Perioxh.Width = 200;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPerioxes);
            this.Controls.Add(this.dgvNomoi);
            this.Controls.Add(this.dgvDistricts);
            this.Controls.Add(this.lblVehicleNo);
            this.Controls.Add(this.cbVehicleNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Scheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.Scheduler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerioxes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVehicleNo;
        private System.Windows.Forms.ComboBox cbVehicleNo;
        private System.Windows.Forms.DataGridView dgvDistricts;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeoDistricts;
        private System.Windows.Forms.DataGridView dgvNomoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomoiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomoiDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerioxesId;
        private System.Windows.Forms.DataGridView dgvPerioxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerioxhId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perioxh;
    }
}