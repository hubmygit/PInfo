namespace MapForm
{
    partial class SearchPlace
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
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownZoom = new System.Windows.Forms.NumericUpDown();
            this.lblFound = new System.Windows.Forms.Label();
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = true;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(12, 12);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 100;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = false;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = false;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(754, 390);
            this.gMap.TabIndex = 11;
            this.gMap.Zoom = 12D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMap_OnMarkerClick);
            this.gMap.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMap_OnMarkerEnter);
            this.gMap.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gMap_OnMarkerLeave);
            this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gMap_OnMapZoomChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 471);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(754, 120);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // numericUpDownRadius
            // 
            this.numericUpDownRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.numericUpDownRadius.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRadius.Location = new System.Drawing.Point(88, 443);
            this.numericUpDownRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownRadius.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRadius.Name = "numericUpDownRadius";
            this.numericUpDownRadius.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownRadius.TabIndex = 17;
            this.numericUpDownRadius.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRadius.ValueChanged += new System.EventHandler(this.numericUpDownRadius_ValueChanged);
            // 
            // numericUpDownZoom
            // 
            this.numericUpDownZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.numericUpDownZoom.Location = new System.Drawing.Point(700, 443);
            this.numericUpDownZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownZoom.Name = "numericUpDownZoom";
            this.numericUpDownZoom.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownZoom.TabIndex = 20;
            this.numericUpDownZoom.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownZoom.ValueChanged += new System.EventHandler(this.numericUpDownZoom_ValueChanged);
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblFound.Location = new System.Drawing.Point(160, 445);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(55, 16);
            this.lblFound.TabIndex = 21;
            this.lblFound.Text = "Found...";
            // 
            // lblRadius
            // 
            this.lblRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRadius.AutoSize = true;
            this.lblRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblRadius.Location = new System.Drawing.Point(12, 445);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(70, 16);
            this.lblRadius.TabIndex = 22;
            this.lblRadius.Text = "Ακτίνα (m)";
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblZoom.Location = new System.Drawing.Point(651, 445);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(43, 16);
            this.lblZoom.TabIndex = 23;
            this.lblZoom.Text = "Zoom";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblInfo.Location = new System.Drawing.Point(12, 417);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(447, 23);
            this.lblInfo.TabIndex = 24;
            this.lblInfo.Text = "-";
            // 
            // SearchPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 602);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.numericUpDownZoom);
            this.Controls.Add(this.numericUpDownRadius);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gMap);
            this.MaximumSize = new System.Drawing.Size(800, 640);
            this.Name = "SearchPlace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Επιλογή Πρατηρίου";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDownRadius;
        private System.Windows.Forms.NumericUpDown numericUpDownZoom;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label lblInfo;
    }
}

