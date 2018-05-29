namespace PumpInfo
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.lblMaxVolDiff = new System.Windows.Forms.Label();
            this.txtMaxVolDiff = new System.Windows.Forms.TextBox();
            this.lblMinLitrePrice = new System.Windows.Forms.Label();
            this.MaxLitrePrice = new System.Windows.Forms.Label();
            this.txtMinLitrePrice = new System.Windows.Forms.TextBox();
            this.txtMaxLitrePrice = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMaxVolDiff
            // 
            this.lblMaxVolDiff.AutoSize = true;
            this.lblMaxVolDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMaxVolDiff.Location = new System.Drawing.Point(38, 59);
            this.lblMaxVolDiff.Name = "lblMaxVolDiff";
            this.lblMaxVolDiff.Size = new System.Drawing.Size(268, 16);
            this.lblMaxVolDiff.TabIndex = 21;
            this.lblMaxVolDiff.Text = "Μέγιστη διαφορά Λίτρων Αντλίας - Ελέγχου";
            // 
            // txtMaxVolDiff
            // 
            this.txtMaxVolDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtMaxVolDiff.Location = new System.Drawing.Point(312, 56);
            this.txtMaxVolDiff.Name = "txtMaxVolDiff";
            this.txtMaxVolDiff.Size = new System.Drawing.Size(200, 22);
            this.txtMaxVolDiff.TabIndex = 33;
            this.txtMaxVolDiff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleControl_KeyPress);
            // 
            // lblMinLitrePrice
            // 
            this.lblMinLitrePrice.AutoSize = true;
            this.lblMinLitrePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblMinLitrePrice.Location = new System.Drawing.Point(171, 97);
            this.lblMinLitrePrice.Name = "lblMinLitrePrice";
            this.lblMinLitrePrice.Size = new System.Drawing.Size(135, 16);
            this.lblMinLitrePrice.TabIndex = 34;
            this.lblMinLitrePrice.Text = "Ελάχιστη τιμή Λίτρου";
            // 
            // MaxLitrePrice
            // 
            this.MaxLitrePrice.AutoSize = true;
            this.MaxLitrePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MaxLitrePrice.Location = new System.Drawing.Point(176, 135);
            this.MaxLitrePrice.Name = "MaxLitrePrice";
            this.MaxLitrePrice.Size = new System.Drawing.Size(130, 16);
            this.MaxLitrePrice.TabIndex = 35;
            this.MaxLitrePrice.Text = "Μέγιστη τιμή Λίτρου";
            // 
            // txtMinLitrePrice
            // 
            this.txtMinLitrePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtMinLitrePrice.Location = new System.Drawing.Point(312, 94);
            this.txtMinLitrePrice.Name = "txtMinLitrePrice";
            this.txtMinLitrePrice.Size = new System.Drawing.Size(200, 22);
            this.txtMinLitrePrice.TabIndex = 36;
            this.txtMinLitrePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleControl_KeyPress);
            // 
            // txtMaxLitrePrice
            // 
            this.txtMaxLitrePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtMaxLitrePrice.Location = new System.Drawing.Point(312, 132);
            this.txtMaxLitrePrice.Name = "txtMaxLitrePrice";
            this.txtMaxLitrePrice.Size = new System.Drawing.Size(200, 22);
            this.txtMaxLitrePrice.TabIndex = 37;
            this.txtMaxLitrePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleControl_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAdd.Image = global::PumpInfo.Properties.Resources.Save_32x;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(249, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 40);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Αποθήκευση";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 252);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMaxLitrePrice);
            this.Controls.Add(this.txtMinLitrePrice);
            this.Controls.Add(this.MaxLitrePrice);
            this.Controls.Add(this.lblMinLitrePrice);
            this.Controls.Add(this.txtMaxVolDiff);
            this.Controls.Add(this.lblMaxVolDiff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaxVolDiff;
        private System.Windows.Forms.TextBox txtMaxVolDiff;
        private System.Windows.Forms.Label lblMinLitrePrice;
        private System.Windows.Forms.Label MaxLitrePrice;
        private System.Windows.Forms.TextBox txtMinLitrePrice;
        private System.Windows.Forms.TextBox txtMaxLitrePrice;
        public System.Windows.Forms.Button btnAdd;
    }
}