namespace PumpData
{
    partial class StationScheduler
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Νομός 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Νομός 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Περιοχή a");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Περιοχή b");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ΤΚ 11111");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("ΤΚ 22222");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ΤΚ 33333");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Περιοχή c", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Νομός 3", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode8});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StationScheduler));
            this.lblVehicleNo = new System.Windows.Forms.Label();
            this.cbVehicleNo = new System.Windows.Forms.ComboBox();
            this.dgvReceiptData = new System.Windows.Forms.DataGridView();
            this.ReceiptDataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accepted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblVehicleNo.Location = new System.Drawing.Point(12, 39);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(68, 20);
            this.lblVehicleNo.TabIndex = 32;
            this.lblVehicleNo.Text = "Vehicle";
            // 
            // cbVehicleNo
            // 
            this.cbVehicleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbVehicleNo.FormattingEnabled = true;
            this.cbVehicleNo.Location = new System.Drawing.Point(86, 36);
            this.cbVehicleNo.Name = "cbVehicleNo";
            this.cbVehicleNo.Size = new System.Drawing.Size(160, 28);
            this.cbVehicleNo.TabIndex = 31;
            this.cbVehicleNo.SelectedIndexChanged += new System.EventHandler(this.cbVehicleNo_SelectedIndexChanged);
            // 
            // dgvReceiptData
            // 
            this.dgvReceiptData.AllowUserToAddRows = false;
            this.dgvReceiptData.AllowUserToDeleteRows = false;
            this.dgvReceiptData.AllowUserToOrderColumns = true;
            this.dgvReceiptData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.ReceiptDataId,
            this.Accepted,
            this.ColNo1,
            this.ColNo2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptData.Location = new System.Drawing.Point(264, 36);
            this.dgvReceiptData.MultiSelect = false;
            this.dgvReceiptData.Name = "dgvReceiptData";
            this.dgvReceiptData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptData.Size = new System.Drawing.Size(508, 248);
            this.dgvReceiptData.TabIndex = 33;
            // 
            // ReceiptDataId
            // 
            this.ReceiptDataId.HeaderText = "ReceiptDataId";
            this.ReceiptDataId.Name = "ReceiptDataId";
            this.ReceiptDataId.Visible = false;
            this.ReceiptDataId.Width = 60;
            // 
            // Accepted
            // 
            this.Accepted.HeaderText = "[-]";
            this.Accepted.Name = "Accepted";
            this.Accepted.Width = 40;
            // 
            // ColNo1
            // 
            this.ColNo1.HeaderText = "ColNo1";
            this.ColNo1.Name = "ColNo1";
            this.ColNo1.ReadOnly = true;
            // 
            // ColNo2
            // 
            this.ColNo2.HeaderText = "ColNo2";
            this.ColNo2.Name = "ColNo2";
            this.ColNo2.ReadOnly = true;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.treeView1.Location = new System.Drawing.Point(16, 88);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Νομός 1";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Νομός 2";
            treeNode3.Name = "Node8";
            treeNode3.Text = "Περιοχή a";
            treeNode4.Name = "Node11";
            treeNode4.Text = "Περιοχή b";
            treeNode5.Name = "Node4";
            treeNode5.Text = "ΤΚ 11111";
            treeNode6.Name = "Node12";
            treeNode6.Text = "ΤΚ 22222";
            treeNode7.Name = "Node13";
            treeNode7.Text = "ΤΚ 33333";
            treeNode8.Name = "Node3";
            treeNode8.Text = "Περιοχή c";
            treeNode9.Name = "Node1";
            treeNode9.Text = "Νομός 3";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(230, 196);
            this.treeView1.TabIndex = 35;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // StationScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dgvReceiptData);
            this.Controls.Add(this.lblVehicleNo);
            this.Controls.Add(this.cbVehicleNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StationScheduler";
            this.Text = "Station Scheduler";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVehicleNo;
        private System.Windows.Forms.ComboBox cbVehicleNo;
        private System.Windows.Forms.DataGridView dgvReceiptData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDataId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Accepted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo2;
        private System.Windows.Forms.TreeView treeView1;
    }
}