namespace PumpInfo
{
    partial class ShowMyReceipts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowMyReceipts));
            this.dgvReceipts = new System.Windows.Forms.DataGridView();
            this.Rec_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_receiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rec_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDtFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDtTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.txtTotRecPrice = new System.Windows.Forms.TextBox();
            this.lblEuros = new System.Windows.Forms.Label();
            this.lblTotRecPrice = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.chbWPrice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReceipts
            // 
            this.dgvReceipts.AllowUserToAddRows = false;
            this.dgvReceipts.AllowUserToDeleteRows = false;
            this.dgvReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceipts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rec_Date,
            this.Rec_Brand,
            this.Rec_Dealer,
            this.Rec_Address,
            this.Rec_Product,
            this.Rec_receiptNo,
            this.Rec_Price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceipts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceipts.Location = new System.Drawing.Point(12, 80);
            this.dgvReceipts.Name = "dgvReceipts";
            this.dgvReceipts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceipts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceipts.Size = new System.Drawing.Size(940, 350);
            this.dgvReceipts.TabIndex = 12;
            // 
            // Rec_Date
            // 
            this.Rec_Date.HeaderText = "Date (of Meas.)";
            this.Rec_Date.Name = "Rec_Date";
            this.Rec_Date.ReadOnly = true;
            this.Rec_Date.Width = 150;
            // 
            // Rec_Brand
            // 
            this.Rec_Brand.HeaderText = "Brand";
            this.Rec_Brand.Name = "Rec_Brand";
            this.Rec_Brand.ReadOnly = true;
            // 
            // Rec_Dealer
            // 
            this.Rec_Dealer.HeaderText = "Dealer";
            this.Rec_Dealer.Name = "Rec_Dealer";
            this.Rec_Dealer.ReadOnly = true;
            this.Rec_Dealer.Width = 140;
            // 
            // Rec_Address
            // 
            this.Rec_Address.HeaderText = "Address";
            this.Rec_Address.Name = "Rec_Address";
            this.Rec_Address.ReadOnly = true;
            this.Rec_Address.Width = 140;
            // 
            // Rec_Product
            // 
            this.Rec_Product.HeaderText = "Product";
            this.Rec_Product.Name = "Rec_Product";
            this.Rec_Product.ReadOnly = true;
            this.Rec_Product.Width = 120;
            // 
            // Rec_receiptNo
            // 
            this.Rec_receiptNo.HeaderText = "ReceiptNo";
            this.Rec_receiptNo.Name = "Rec_receiptNo";
            this.Rec_receiptNo.ReadOnly = true;
            this.Rec_receiptNo.Width = 110;
            // 
            // Rec_Price
            // 
            this.Rec_Price.HeaderText = "Price";
            this.Rec_Price.Name = "Rec_Price";
            this.Rec_Price.ReadOnly = true;
            // 
            // lblDtFrom
            // 
            this.lblDtFrom.AutoSize = true;
            this.lblDtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtFrom.Location = new System.Drawing.Point(12, 17);
            this.lblDtFrom.Name = "lblDtFrom";
            this.lblDtFrom.Size = new System.Drawing.Size(33, 16);
            this.lblDtFrom.TabIndex = 34;
            this.lblDtFrom.Text = "Από";
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtFrom.Location = new System.Drawing.Point(51, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(234, 22);
            this.dtFrom.TabIndex = 33;
            this.dtFrom.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // lblDtTo
            // 
            this.lblDtTo.AutoSize = true;
            this.lblDtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDtTo.Location = new System.Drawing.Point(12, 51);
            this.lblDtTo.Name = "lblDtTo";
            this.lblDtTo.Size = new System.Drawing.Size(33, 16);
            this.lblDtTo.TabIndex = 36;
            this.lblDtTo.Text = "Έως";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dtTo.Location = new System.Drawing.Point(51, 46);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(234, 22);
            this.dtTo.TabIndex = 35;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // txtTotRecPrice
            // 
            this.txtTotRecPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtTotRecPrice.Location = new System.Drawing.Point(513, 28);
            this.txtTotRecPrice.Name = "txtTotRecPrice";
            this.txtTotRecPrice.ReadOnly = true;
            this.txtTotRecPrice.Size = new System.Drawing.Size(100, 22);
            this.txtTotRecPrice.TabIndex = 55;
            // 
            // lblEuros
            // 
            this.lblEuros.AutoSize = true;
            this.lblEuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblEuros.Location = new System.Drawing.Point(619, 31);
            this.lblEuros.Name = "lblEuros";
            this.lblEuros.Size = new System.Drawing.Size(15, 16);
            this.lblEuros.TabIndex = 54;
            this.lblEuros.Text = "€";
            // 
            // lblTotRecPrice
            // 
            this.lblTotRecPrice.AutoSize = true;
            this.lblTotRecPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTotRecPrice.Location = new System.Drawing.Point(367, 31);
            this.lblTotRecPrice.Name = "lblTotRecPrice";
            this.lblTotRecPrice.Size = new System.Drawing.Size(140, 16);
            this.lblTotRecPrice.TabIndex = 53;
            this.lblTotRecPrice.Text = "Άθροισμα Αποδείξεων";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCopy.Image = global::PumpInfo.Properties.Resources.CopyToClipboard_32x;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(817, 19);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(135, 40);
            this.btnCopy.TabIndex = 56;
            this.btnCopy.Text = "Αντιγραφή";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // chbWPrice
            // 
            this.chbWPrice.AutoSize = true;
            this.chbWPrice.Checked = true;
            this.chbWPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbWPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chbWPrice.Location = new System.Drawing.Point(692, 30);
            this.chbWPrice.Name = "chbWPrice";
            this.chbWPrice.Size = new System.Drawing.Size(73, 20);
            this.chbWPrice.TabIndex = 57;
            this.chbWPrice.Text = "Με αξία";
            this.chbWPrice.ThreeState = true;
            this.chbWPrice.UseVisualStyleBackColor = true;
            this.chbWPrice.CheckStateChanged += new System.EventHandler(this.chbWPrice_CheckStateChanged);
            // 
            // ShowMyReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 442);
            this.Controls.Add(this.chbWPrice);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtTotRecPrice);
            this.Controls.Add(this.lblEuros);
            this.Controls.Add(this.lblTotRecPrice);
            this.Controls.Add(this.lblDtTo);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.lblDtFrom);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.dgvReceipts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(980, 480);
            this.Name = "ShowMyReceipts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Receipts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceipts;
        private System.Windows.Forms.Label lblDtFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblDtTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.TextBox txtTotRecPrice;
        private System.Windows.Forms.Label lblEuros;
        private System.Windows.Forms.Label lblTotRecPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_receiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rec_Price;
        public System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox chbWPrice;
    }
}