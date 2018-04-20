namespace PumpInfo
{
    partial class ShowMyKms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowMyKms));
            this.lblDtTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblDtFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dgvKms = new System.Windows.Forms.DataGridView();
            this.Km_VehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Km_Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Km_Dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Km_KmFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Km_KmTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbVehicle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKms)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDtTo
            // 
            this.lblDtTo.AutoSize = true;
            this.lblDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtTo.Location = new System.Drawing.Point(392, 51);
            this.lblDtTo.Name = "lblDtTo";
            this.lblDtTo.Size = new System.Drawing.Size(33, 16);
            this.lblDtTo.TabIndex = 40;
            this.lblDtTo.Text = "Έως";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtTo.Location = new System.Drawing.Point(431, 46);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(234, 22);
            this.dtTo.TabIndex = 39;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // lblDtFrom
            // 
            this.lblDtFrom.AutoSize = true;
            this.lblDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtFrom.Location = new System.Drawing.Point(392, 17);
            this.lblDtFrom.Name = "lblDtFrom";
            this.lblDtFrom.Size = new System.Drawing.Size(33, 16);
            this.lblDtFrom.TabIndex = 38;
            this.lblDtFrom.Text = "Από";
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtFrom.Location = new System.Drawing.Point(431, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(234, 22);
            this.dtFrom.TabIndex = 37;
            this.dtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dgvKms
            // 
            this.dgvKms.AllowUserToAddRows = false;
            this.dgvKms.AllowUserToDeleteRows = false;
            this.dgvKms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Km_VehicleNo,
            this.Km_Product,
            this.Km_Dt,
            this.Km_KmFrom,
            this.Km_KmTo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKms.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKms.Location = new System.Drawing.Point(12, 80);
            this.dgvKms.Name = "dgvKms";
            this.dgvKms.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKms.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKms.Size = new System.Drawing.Size(658, 350);
            this.dgvKms.TabIndex = 41;
            // 
            // Km_VehicleNo
            // 
            this.Km_VehicleNo.HeaderText = "Vehicle No";
            this.Km_VehicleNo.Name = "Km_VehicleNo";
            this.Km_VehicleNo.ReadOnly = true;
            this.Km_VehicleNo.Width = 120;
            // 
            // Km_Product
            // 
            this.Km_Product.HeaderText = "Vehicle Type";
            this.Km_Product.Name = "Km_Product";
            this.Km_Product.ReadOnly = true;
            this.Km_Product.Width = 130;
            // 
            // Km_Dt
            // 
            this.Km_Dt.HeaderText = "Date";
            this.Km_Dt.Name = "Km_Dt";
            this.Km_Dt.ReadOnly = true;
            this.Km_Dt.Width = 120;
            // 
            // Km_KmFrom
            // 
            this.Km_KmFrom.HeaderText = "Km From";
            this.Km_KmFrom.Name = "Km_KmFrom";
            this.Km_KmFrom.ReadOnly = true;
            // 
            // Km_KmTo
            // 
            this.Km_KmTo.HeaderText = "Km To";
            this.Km_KmTo.Name = "Km_KmTo";
            this.Km_KmTo.ReadOnly = true;
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
            this.cbVehicle.Location = new System.Drawing.Point(12, 28);
            this.cbVehicle.Name = "cbVehicle";
            this.cbVehicle.Size = new System.Drawing.Size(200, 24);
            this.cbVehicle.TabIndex = 42;
            this.cbVehicle.SelectedIndexChanged += new System.EventHandler(this.cbVehicle_SelectedIndexChanged);
            // 
            // ShowMyKms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 442);
            this.Controls.Add(this.cbVehicle);
            this.Controls.Add(this.dgvKms);
            this.Controls.Add(this.lblDtTo);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.lblDtFrom);
            this.Controls.Add(this.dtFrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(698, 480);
            this.Name = "ShowMyKms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Kms";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDtTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblDtFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridView dgvKms;
        private System.Windows.Forms.ComboBox cbVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Km_VehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Km_Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Km_Dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Km_KmFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Km_KmTo;
    }
}