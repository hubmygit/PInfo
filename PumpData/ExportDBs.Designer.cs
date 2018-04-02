namespace PumpData
{
    partial class ExportDBs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDBs));
            this.btnExportGeoData = new System.Windows.Forms.Button();
            this.btnExportPumpInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportGeoData
            // 
            this.btnExportGeoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnExportGeoData.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExportGeoData.Image = global::PumpData.Properties.Resources.SynchronizeDatabase_48x;
            this.btnExportGeoData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportGeoData.Location = new System.Drawing.Point(69, 84);
            this.btnExportGeoData.Name = "btnExportGeoData";
            this.btnExportGeoData.Size = new System.Drawing.Size(246, 75);
            this.btnExportGeoData.TabIndex = 24;
            this.btnExportGeoData.Text = "Εξαγωγή Βάσης Πρατηρίων";
            this.btnExportGeoData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportGeoData.UseVisualStyleBackColor = true;
            this.btnExportGeoData.Click += new System.EventHandler(this.btnExportGeoData_Click);
            // 
            // btnExportPumpInfo
            // 
            this.btnExportPumpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnExportPumpInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExportPumpInfo.Image = global::PumpData.Properties.Resources.SynchronizeDatabase_48x;
            this.btnExportPumpInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportPumpInfo.Location = new System.Drawing.Point(369, 84);
            this.btnExportPumpInfo.Name = "btnExportPumpInfo";
            this.btnExportPumpInfo.Size = new System.Drawing.Size(246, 75);
            this.btnExportPumpInfo.TabIndex = 25;
            this.btnExportPumpInfo.Text = "Εξαγωγή Βάσης Επισκέψεων";
            this.btnExportPumpInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportPumpInfo.UseVisualStyleBackColor = true;
            this.btnExportPumpInfo.Click += new System.EventHandler(this.btnExportPumpInfo_Click);
            // 
            // ExportDBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 262);
            this.Controls.Add(this.btnExportPumpInfo);
            this.Controls.Add(this.btnExportGeoData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 300);
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "ExportDBs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExportDBs";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnExportGeoData;
        public System.Windows.Forms.Button btnExportPumpInfo;
    }
}