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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetKm));
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.lblVehicleNo = new System.Windows.Forms.Label();
            this.txtKmTo = new System.Windows.Forms.TextBox();
            this.lblKmTo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDt = new System.Windows.Forms.Label();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.txtKmFrom = new System.Windows.Forms.TextBox();
            this.lblKmFrom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtVehicleNo.Location = new System.Drawing.Point(142, 29);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.ReadOnly = true;
            this.txtVehicleNo.Size = new System.Drawing.Size(280, 22);
            this.txtVehicleNo.TabIndex = 2;
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(62, 32);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(74, 16);
            this.lblVehicleNo.TabIndex = 33;
            this.lblVehicleNo.Text = "Vehicle No";
            // 
            // txtKmTo
            // 
            this.txtKmTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKmTo.Location = new System.Drawing.Point(142, 143);
            this.txtKmTo.Name = "txtKmTo";
            this.txtKmTo.Size = new System.Drawing.Size(280, 22);
            this.txtKmTo.TabIndex = 1;
            this.txtKmTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKm_KeyPress);
            // 
            // lblKmTo
            // 
            this.lblKmTo.AutoSize = true;
            this.lblKmTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKmTo.Location = new System.Drawing.Point(89, 146);
            this.lblKmTo.Name = "lblKmTo";
            this.lblKmTo.Size = new System.Drawing.Size(47, 16);
            this.lblKmTo.TabIndex = 39;
            this.lblKmTo.Text = "Km To";
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
            // lblDt
            // 
            this.lblDt.AutoSize = true;
            this.lblDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDt.Location = new System.Drawing.Point(99, 70);
            this.lblDt.Name = "lblDt";
            this.lblDt.Size = new System.Drawing.Size(37, 16);
            this.lblDt.TabIndex = 41;
            this.lblDt.Text = "Date";
            // 
            // txtDt
            // 
            this.txtDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtDt.Location = new System.Drawing.Point(142, 67);
            this.txtDt.Name = "txtDt";
            this.txtDt.ReadOnly = true;
            this.txtDt.Size = new System.Drawing.Size(280, 22);
            this.txtDt.TabIndex = 42;
            // 
            // txtKmFrom
            // 
            this.txtKmFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtKmFrom.Location = new System.Drawing.Point(142, 105);
            this.txtKmFrom.Name = "txtKmFrom";
            this.txtKmFrom.Size = new System.Drawing.Size(280, 22);
            this.txtKmFrom.TabIndex = 43;
            // 
            // lblKmFrom
            // 
            this.lblKmFrom.AutoSize = true;
            this.lblKmFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblKmFrom.Location = new System.Drawing.Point(75, 108);
            this.lblKmFrom.Name = "lblKmFrom";
            this.lblKmFrom.Size = new System.Drawing.Size(61, 16);
            this.lblKmFrom.TabIndex = 44;
            this.lblKmFrom.Text = "Km From";
            // 
            // frmSetKm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.txtKmFrom);
            this.Controls.Add(this.lblKmFrom);
            this.Controls.Add(this.txtDt);
            this.Controls.Add(this.lblDt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtKmTo);
            this.Controls.Add(this.lblKmTo);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.lblVehicleNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetKm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetKm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label lblVehicleNo;
        private System.Windows.Forms.Label lblKmTo;
        public System.Windows.Forms.TextBox txtKmTo;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDt;
        private System.Windows.Forms.TextBox txtDt;
        public System.Windows.Forms.TextBox txtKmFrom;
        private System.Windows.Forms.Label lblKmFrom;
    }
}