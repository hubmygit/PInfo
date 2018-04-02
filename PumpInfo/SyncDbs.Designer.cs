namespace PumpInfo
{
    partial class SyncDbs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncDbs));
            this.btnSyncPumpInfo = new System.Windows.Forms.Button();
            this.btnSyncGeoData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSyncPumpInfo
            // 
            this.btnSyncPumpInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSyncPumpInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSyncPumpInfo.Image = global::PumpInfo.Properties.Resources.SynchronizeDatabase_48x;
            this.btnSyncPumpInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSyncPumpInfo.Location = new System.Drawing.Point(315, 99);
            this.btnSyncPumpInfo.Name = "btnSyncPumpInfo";
            this.btnSyncPumpInfo.Size = new System.Drawing.Size(200, 64);
            this.btnSyncPumpInfo.TabIndex = 22;
            this.btnSyncPumpInfo.Text = "Επισκέψεις";
            this.btnSyncPumpInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSyncPumpInfo.UseVisualStyleBackColor = true;
            this.btnSyncPumpInfo.Click += new System.EventHandler(this.btnSyncPumpInfo_Click);
            // 
            // btnSyncGeoData
            // 
            this.btnSyncGeoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSyncGeoData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSyncGeoData.Image = global::PumpInfo.Properties.Resources.SynchronizeDatabase_48x;
            this.btnSyncGeoData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSyncGeoData.Location = new System.Drawing.Point(69, 99);
            this.btnSyncGeoData.Name = "btnSyncGeoData";
            this.btnSyncGeoData.Size = new System.Drawing.Size(200, 64);
            this.btnSyncGeoData.TabIndex = 21;
            this.btnSyncGeoData.Text = "Πρατήρια";
            this.btnSyncGeoData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSyncGeoData.UseVisualStyleBackColor = true;
            this.btnSyncGeoData.Click += new System.EventHandler(this.btnSyncGeoData_Click);
            // 
            // SyncDbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.btnSyncPumpInfo);
            this.Controls.Add(this.btnSyncGeoData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SyncDbs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Συγχρονισμός Βάσεων";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnSyncGeoData;
        public System.Windows.Forms.Button btnSyncPumpInfo;
    }
}