﻿namespace PumpInfo
{
    partial class Form1
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.dgvReceiptData = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(135, 40);
            this.btnOpenFile.TabIndex = 10;
            this.btnOpenFile.Text = "Αρχείο";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // dgvReceiptData
            // 
            this.dgvReceiptData.AllowUserToAddRows = false;
            this.dgvReceiptData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceiptData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceiptData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvReceiptData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptData.Location = new System.Drawing.Point(12, 80);
            this.dgvReceiptData.Name = "dgvReceiptData";
            this.dgvReceiptData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptData.Size = new System.Drawing.Size(880, 350);
            this.dgvReceiptData.TabIndex = 11;
            // 
            // Accepted
            // 
            this.Accepted.HeaderText = "";
            this.Accepted.Name = "Accepted";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 442);
            this.Controls.Add(this.dgvReceiptData);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.DataGridView dgvReceiptData;
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
    }
}

