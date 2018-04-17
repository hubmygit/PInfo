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
            this.btnExportToSqlite = new System.Windows.Forms.Button();
            this.btnStationScheduler = new System.Windows.Forms.Button();
            this.btnShowConsumption = new System.Windows.Forms.Button();
            this.btnShowDbData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportToSqlite
            // 
            this.btnExportToSqlite.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnExportToSqlite.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExportToSqlite.Image = global::PumpData.Properties.Resources.SynchronizeDatabase_48x;
            this.btnExportToSqlite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToSqlite.Location = new System.Drawing.Point(380, 214);
            this.btnExportToSqlite.Name = "btnExportToSqlite";
            this.btnExportToSqlite.Size = new System.Drawing.Size(225, 75);
            this.btnExportToSqlite.TabIndex = 23;
            this.btnExportToSqlite.Text = "Εξαγωγή Νέων Βάσεων";
            this.btnExportToSqlite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToSqlite.UseVisualStyleBackColor = true;
            this.btnExportToSqlite.Click += new System.EventHandler(this.btnExportToSqlite_Click);
            // 
            // btnStationScheduler
            // 
            this.btnStationScheduler.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnStationScheduler.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnStationScheduler.Image = global::PumpData.Properties.Resources.TemporalTable_48x;
            this.btnStationScheduler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStationScheduler.Location = new System.Drawing.Point(80, 214);
            this.btnStationScheduler.Name = "btnStationScheduler";
            this.btnStationScheduler.Size = new System.Drawing.Size(225, 75);
            this.btnStationScheduler.TabIndex = 22;
            this.btnStationScheduler.Text = "Πλάνο Επαναλήψεων";
            this.btnStationScheduler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStationScheduler.UseVisualStyleBackColor = true;
            this.btnStationScheduler.Click += new System.EventHandler(this.btnStationScheduler_Click);
            // 
            // btnShowConsumption
            // 
            this.btnShowConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnShowConsumption.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnShowConsumption.Image = global::PumpData.Properties.Resources.IntelliTrace_48x;
            this.btnShowConsumption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowConsumption.Location = new System.Drawing.Point(380, 74);
            this.btnShowConsumption.Name = "btnShowConsumption";
            this.btnShowConsumption.Size = new System.Drawing.Size(225, 75);
            this.btnShowConsumption.TabIndex = 21;
            this.btnShowConsumption.Text = "Κατανάλωση";
            this.btnShowConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowConsumption.UseVisualStyleBackColor = true;
            this.btnShowConsumption.Click += new System.EventHandler(this.btnShowConsumption_Click);
            // 
            // btnShowDbData
            // 
            this.btnShowDbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnShowDbData.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnShowDbData.Image = global::PumpData.Properties.Resources.DatabaseAuditSpecification_48x;
            this.btnShowDbData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowDbData.Location = new System.Drawing.Point(80, 74);
            this.btnShowDbData.Name = "btnShowDbData";
            this.btnShowDbData.Size = new System.Drawing.Size(225, 75);
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
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.btnExportToSqlite);
            this.Controls.Add(this.btnStationScheduler);
            this.Controls.Add(this.btnShowConsumption);
            this.Controls.Add(this.btnShowDbData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 400);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frmPumpData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pump Data";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnShowDbData;
        public System.Windows.Forms.Button btnShowConsumption;
        public System.Windows.Forms.Button btnStationScheduler;
        public System.Windows.Forms.Button btnExportToSqlite;
    }
}

