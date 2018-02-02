namespace PumpInfo
{
    partial class frmSetKm
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
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.lblVehicleNo = new System.Windows.Forms.Label();
            this.txtDtYear = new System.Windows.Forms.TextBox();
            this.lblDtYear = new System.Windows.Forms.Label();
            this.txtDtMonth = new System.Windows.Forms.TextBox();
            this.lblDtMonth = new System.Windows.Forms.Label();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.lblKm = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtVehicleNo.Location = new System.Drawing.Point(142, 24);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.ReadOnly = true;
            this.txtVehicleNo.Size = new System.Drawing.Size(280, 22);
            this.txtVehicleNo.TabIndex = 1;
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(62, 27);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(74, 16);
            this.lblVehicleNo.TabIndex = 33;
            this.lblVehicleNo.Text = "Vehicle No";
            // 
            // txtDtYear
            // 
            this.txtDtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDtYear.Location = new System.Drawing.Point(142, 52);
            this.txtDtYear.Name = "txtDtYear";
            this.txtDtYear.ReadOnly = true;
            this.txtDtYear.Size = new System.Drawing.Size(280, 22);
            this.txtDtYear.TabIndex = 2;
            // 
            // lblDtYear
            // 
            this.lblDtYear.AutoSize = true;
            this.lblDtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtYear.Location = new System.Drawing.Point(99, 55);
            this.lblDtYear.Name = "lblDtYear";
            this.lblDtYear.Size = new System.Drawing.Size(37, 16);
            this.lblDtYear.TabIndex = 35;
            this.lblDtYear.Text = "Year";
            // 
            // txtDtMonth
            // 
            this.txtDtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDtMonth.Location = new System.Drawing.Point(142, 80);
            this.txtDtMonth.Name = "txtDtMonth";
            this.txtDtMonth.ReadOnly = true;
            this.txtDtMonth.Size = new System.Drawing.Size(280, 22);
            this.txtDtMonth.TabIndex = 3;
            // 
            // lblDtMonth
            // 
            this.lblDtMonth.AutoSize = true;
            this.lblDtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtMonth.Location = new System.Drawing.Point(92, 83);
            this.lblDtMonth.Name = "lblDtMonth";
            this.lblDtMonth.Size = new System.Drawing.Size(44, 16);
            this.lblDtMonth.TabIndex = 37;
            this.lblDtMonth.Text = "Month";
            // 
            // txtKm
            // 
            this.txtKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKm.Location = new System.Drawing.Point(142, 159);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(280, 22);
            this.txtKm.TabIndex = 38;
            this.txtKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKm_KeyPress);
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKm.Location = new System.Drawing.Point(77, 162);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(59, 16);
            this.lblKm.TabIndex = 39;
            this.lblKm.Text = "Final Km";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::PumpInfo.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(175, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSetKm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.txtDtMonth);
            this.Controls.Add(this.lblDtMonth);
            this.Controls.Add(this.txtDtYear);
            this.Controls.Add(this.lblDtYear);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.lblVehicleNo);
            this.Name = "frmSetKm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Final Km";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetKm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label lblVehicleNo;
        private System.Windows.Forms.TextBox txtDtYear;
        private System.Windows.Forms.Label lblDtYear;
        private System.Windows.Forms.TextBox txtDtMonth;
        private System.Windows.Forms.Label lblDtMonth;
        private System.Windows.Forms.Label lblKm;
        public System.Windows.Forms.TextBox txtKm;
        public System.Windows.Forms.Button btnSave;
    }
}