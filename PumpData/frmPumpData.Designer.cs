namespace PumpData
{
    partial class frmPumpData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPumpData));
            this.btnShowConsumption = new System.Windows.Forms.Button();
            this.btnShowDbData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowConsumption
            // 
            this.btnShowConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnShowConsumption.Image = global::PumpData.Properties.Resources.ShowDbData_32x;
            this.btnShowConsumption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowConsumption.Location = new System.Drawing.Point(75, 148);
            this.btnShowConsumption.Name = "btnShowConsumption";
            this.btnShowConsumption.Size = new System.Drawing.Size(135, 40);
            this.btnShowConsumption.TabIndex = 21;
            this.btnShowConsumption.Text = "Κατανάλωση";
            this.btnShowConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowConsumption.UseVisualStyleBackColor = true;
            this.btnShowConsumption.Click += new System.EventHandler(this.btnShowConsumption_Click);
            // 
            // btnShowDbData
            // 
            this.btnShowDbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnShowDbData.Image = global::PumpData.Properties.Resources.ShowDbData_32x;
            this.btnShowDbData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowDbData.Location = new System.Drawing.Point(75, 75);
            this.btnShowDbData.Name = "btnShowDbData";
            this.btnShowDbData.Size = new System.Drawing.Size(135, 40);
            this.btnShowDbData.TabIndex = 20;
            this.btnShowDbData.Text = "Δεδομένα";
            this.btnShowDbData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowDbData.UseVisualStyleBackColor = true;
            this.btnShowDbData.Click += new System.EventHandler(this.btnShowDbData_Click);
            // 
            // frmPumpData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnShowConsumption);
            this.Controls.Add(this.btnShowDbData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPumpData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pump Data";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnShowDbData;
        public System.Windows.Forms.Button btnShowConsumption;
    }
}

