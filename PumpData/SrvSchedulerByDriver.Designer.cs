namespace PumpData
{
    partial class SrvSchedulerByDriver
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbDates = new System.Windows.Forms.ComboBox();
            this.lblDates = new System.Windows.Forms.Label();
            this.dgvDistricts = new System.Windows.Forms.DataGridView();
            this.DistrictId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeoDistricts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDriver = new System.Windows.Forms.Label();
            this.cbDriver = new System.Windows.Forms.ComboBox();
            this.cbAllComs = new System.Windows.Forms.CheckBox();
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.Com_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Com_Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Com_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.Station_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Nomos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Perioxi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_TK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_ComId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Company_Operated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Station_Station_Closed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Station_Visits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_VisitsG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_VisitsD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_Parav = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_ParavG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_ParavD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_LastVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station_LastDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblStationsCntTitle = new System.Windows.Forms.Label();
            this.lblStationsCnt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDates
            // 
            this.cbDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbDates.FormattingEnabled = true;
            this.cbDates.Location = new System.Drawing.Point(163, 122);
            this.cbDates.Name = "cbDates";
            this.cbDates.Size = new System.Drawing.Size(68, 28);
            this.cbDates.TabIndex = 46;
            this.cbDates.SelectedIndexChanged += new System.EventHandler(this.cbDates_SelectedIndexChanged);
            // 
            // lblDates
            // 
            this.lblDates.AutoSize = true;
            this.lblDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDates.Location = new System.Drawing.Point(12, 125);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(145, 20);
            this.lblDates.TabIndex = 45;
            this.lblDates.Text = "Διάστημα σε μήνες";
            // 
            // dgvDistricts
            // 
            this.dgvDistricts.AllowUserToAddRows = false;
            this.dgvDistricts.AllowUserToDeleteRows = false;
            this.dgvDistricts.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDistricts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistricts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DistrictId,
            this.GeoDistricts});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDistricts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDistricts.Location = new System.Drawing.Point(261, 6);
            this.dgvDistricts.MultiSelect = false;
            this.dgvDistricts.Name = "dgvDistricts";
            this.dgvDistricts.RowHeadersVisible = false;
            this.dgvDistricts.RowHeadersWidth = 10;
            this.dgvDistricts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDistricts.Size = new System.Drawing.Size(215, 270);
            this.dgvDistricts.TabIndex = 44;
            this.dgvDistricts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDistricts_CellClick);
            // 
            // DistrictId
            // 
            this.DistrictId.HeaderText = "DistrictId";
            this.DistrictId.Name = "DistrictId";
            this.DistrictId.Visible = false;
            this.DistrictId.Width = 60;
            // 
            // GeoDistricts
            // 
            this.GeoDistricts.HeaderText = "Γεωγραφικές Περιοχές";
            this.GeoDistricts.Name = "GeoDistricts";
            this.GeoDistricts.ReadOnly = true;
            this.GeoDistricts.Width = 200;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDriver.Location = new System.Drawing.Point(4, 58);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(64, 20);
            this.lblDriver.TabIndex = 43;
            this.lblDriver.Text = "Οδηγός";
            // 
            // cbDriver
            // 
            this.cbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbDriver.FormattingEnabled = true;
            this.cbDriver.Items.AddRange(new object[] {
            "ΟΛΟΙ"});
            this.cbDriver.Location = new System.Drawing.Point(74, 55);
            this.cbDriver.Name = "cbDriver";
            this.cbDriver.Size = new System.Drawing.Size(157, 28);
            this.cbDriver.TabIndex = 42;
            this.cbDriver.SelectedIndexChanged += new System.EventHandler(this.cbDriver_SelectedIndexChanged);
            // 
            // cbAllComs
            // 
            this.cbAllComs.AutoSize = true;
            this.cbAllComs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cbAllComs.Location = new System.Drawing.Point(523, 282);
            this.cbAllComs.Name = "cbAllComs";
            this.cbAllComs.Size = new System.Drawing.Size(126, 20);
            this.cbAllComs.TabIndex = 48;
            this.cbAllComs.Text = "Όλες οι εταιρίες";
            this.cbAllComs.UseVisualStyleBackColor = true;
            this.cbAllComs.CheckedChanged += new System.EventHandler(this.cbAllComs_CheckedChanged);
            // 
            // dgvCompanies
            // 
            this.dgvCompanies.AllowUserToAddRows = false;
            this.dgvCompanies.AllowUserToDeleteRows = false;
            this.dgvCompanies.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Com_Index,
            this.Com_Selected,
            this.Com_Name});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompanies.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCompanies.Location = new System.Drawing.Point(508, 6);
            this.dgvCompanies.MultiSelect = false;
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.ReadOnly = true;
            this.dgvCompanies.RowHeadersVisible = false;
            this.dgvCompanies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanies.Size = new System.Drawing.Size(169, 270);
            this.dgvCompanies.TabIndex = 47;
            this.dgvCompanies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanies_CellContentClick);
            // 
            // Com_Index
            // 
            this.Com_Index.HeaderText = "Index";
            this.Com_Index.Name = "Com_Index";
            this.Com_Index.ReadOnly = true;
            this.Com_Index.Visible = false;
            this.Com_Index.Width = 60;
            // 
            // Com_Selected
            // 
            this.Com_Selected.FalseValue = "";
            this.Com_Selected.HeaderText = "";
            this.Com_Selected.Name = "Com_Selected";
            this.Com_Selected.ReadOnly = true;
            this.Com_Selected.TrueValue = "";
            this.Com_Selected.Width = 40;
            // 
            // Com_Name
            // 
            this.Com_Name.HeaderText = "Εταιρίες";
            this.Com_Name.Name = "Com_Name";
            this.Com_Name.ReadOnly = true;
            // 
            // dgvStations
            // 
            this.dgvStations.AllowUserToAddRows = false;
            this.dgvStations.AllowUserToDeleteRows = false;
            this.dgvStations.AllowUserToOrderColumns = true;
            this.dgvStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Station_Id,
            this.Station_Nomos,
            this.Station_Perioxi,
            this.Station_Address,
            this.Station_TK,
            this.Station_ComId,
            this.Station_Company,
            this.Station_Dealer,
            this.Station_Company_Operated,
            this.Station_Station_Closed,
            this.Station_Visits,
            this.Station_VisitsG,
            this.Station_VisitsD,
            this.Station_Parav,
            this.Station_ParavG,
            this.Station_ParavD,
            this.Station_LastVisit,
            this.Station_LastDiff});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStations.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStations.Location = new System.Drawing.Point(12, 337);
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.RowHeadersWidth = 30;
            this.dgvStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStations.Size = new System.Drawing.Size(1196, 253);
            this.dgvStations.TabIndex = 49;
            // 
            // Station_Id
            // 
            this.Station_Id.HeaderText = "StationId";
            this.Station_Id.Name = "Station_Id";
            this.Station_Id.Visible = false;
            this.Station_Id.Width = 60;
            // 
            // Station_Nomos
            // 
            this.Station_Nomos.HeaderText = "Νομός";
            this.Station_Nomos.Name = "Station_Nomos";
            // 
            // Station_Perioxi
            // 
            this.Station_Perioxi.HeaderText = "Περιοχή";
            this.Station_Perioxi.Name = "Station_Perioxi";
            // 
            // Station_Address
            // 
            this.Station_Address.HeaderText = "Διεύθυνση";
            this.Station_Address.Name = "Station_Address";
            this.Station_Address.ReadOnly = true;
            this.Station_Address.Width = 285;
            // 
            // Station_TK
            // 
            this.Station_TK.HeaderText = "ΤΚ";
            this.Station_TK.Name = "Station_TK";
            this.Station_TK.Width = 70;
            // 
            // Station_ComId
            // 
            this.Station_ComId.HeaderText = "Station_ComId";
            this.Station_ComId.Name = "Station_ComId";
            this.Station_ComId.Visible = false;
            // 
            // Station_Company
            // 
            this.Station_Company.HeaderText = "Εταιρία";
            this.Station_Company.Name = "Station_Company";
            this.Station_Company.ReadOnly = true;
            // 
            // Station_Dealer
            // 
            this.Station_Dealer.HeaderText = "Dealer";
            this.Station_Dealer.Name = "Station_Dealer";
            this.Station_Dealer.ReadOnly = true;
            this.Station_Dealer.Width = 285;
            // 
            // Station_Company_Operated
            // 
            this.Station_Company_Operated.HeaderText = "Ι/Λ";
            this.Station_Company_Operated.Name = "Station_Company_Operated";
            this.Station_Company_Operated.ReadOnly = true;
            this.Station_Company_Operated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Station_Company_Operated.Width = 40;
            // 
            // Station_Station_Closed
            // 
            this.Station_Station_Closed.HeaderText = "Κλειστό";
            this.Station_Station_Closed.Name = "Station_Station_Closed";
            this.Station_Station_Closed.ReadOnly = true;
            this.Station_Station_Closed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Station_Station_Closed.Width = 80;
            // 
            // Station_Visits
            // 
            this.Station_Visits.HeaderText = "Επισκέψεις";
            this.Station_Visits.Name = "Station_Visits";
            this.Station_Visits.ReadOnly = true;
            this.Station_Visits.Width = 95;
            // 
            // Station_VisitsG
            // 
            this.Station_VisitsG.HeaderText = "G";
            this.Station_VisitsG.Name = "Station_VisitsG";
            this.Station_VisitsG.Width = 30;
            // 
            // Station_VisitsD
            // 
            this.Station_VisitsD.HeaderText = "D";
            this.Station_VisitsD.Name = "Station_VisitsD";
            this.Station_VisitsD.Width = 30;
            // 
            // Station_Parav
            // 
            this.Station_Parav.HeaderText = "Παραβάσεις";
            this.Station_Parav.Name = "Station_Parav";
            // 
            // Station_ParavG
            // 
            this.Station_ParavG.HeaderText = "G";
            this.Station_ParavG.Name = "Station_ParavG";
            this.Station_ParavG.Width = 30;
            // 
            // Station_ParavD
            // 
            this.Station_ParavD.HeaderText = "D";
            this.Station_ParavD.Name = "Station_ParavD";
            this.Station_ParavD.Width = 30;
            // 
            // Station_LastVisit
            // 
            this.Station_LastVisit.HeaderText = "Τελ.Επίσκεψη";
            this.Station_LastVisit.Name = "Station_LastVisit";
            this.Station_LastVisit.ReadOnly = true;
            this.Station_LastVisit.Width = 140;
            // 
            // Station_LastDiff
            // 
            this.Station_LastDiff.HeaderText = "Τελ.Διαφορά";
            this.Station_LastDiff.Name = "Station_LastDiff";
            this.Station_LastDiff.Width = 110;
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnCopy.Image = global::PumpData.Properties.Resources.CopyToClipboard_32x;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(12, 291);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(135, 40);
            this.btnCopy.TabIndex = 50;
            this.btnCopy.Text = "Αντιγραφή";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblStationsCntTitle
            // 
            this.lblStationsCntTitle.AutoSize = true;
            this.lblStationsCntTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblStationsCntTitle.Location = new System.Drawing.Point(79, 186);
            this.lblStationsCntTitle.Name = "lblStationsCntTitle";
            this.lblStationsCntTitle.Size = new System.Drawing.Size(78, 20);
            this.lblStationsCntTitle.TabIndex = 51;
            this.lblStationsCntTitle.Text = "Εγγραφές";
            // 
            // lblStationsCnt
            // 
            this.lblStationsCnt.AutoSize = true;
            this.lblStationsCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblStationsCnt.Location = new System.Drawing.Point(159, 186);
            this.lblStationsCnt.Name = "lblStationsCnt";
            this.lblStationsCnt.Size = new System.Drawing.Size(18, 20);
            this.lblStationsCnt.TabIndex = 52;
            this.lblStationsCnt.Text = "0";
            // 
            // SrvSchedulerByDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 602);
            this.Controls.Add(this.lblStationsCnt);
            this.Controls.Add(this.lblStationsCntTitle);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.dgvStations);
            this.Controls.Add(this.cbAllComs);
            this.Controls.Add(this.dgvCompanies);
            this.Controls.Add(this.cbDates);
            this.Controls.Add(this.lblDates);
            this.Controls.Add(this.dgvDistricts);
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.cbDriver);
            this.Name = "SrvSchedulerByDriver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scheduler By Driver";
            this.Load += new System.EventHandler(this.SrvSchedulerByDriver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistricts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDates;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.DataGridView dgvDistricts;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeoDistricts;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.ComboBox cbDriver;
        private System.Windows.Forms.CheckBox cbAllComs;
        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.DataGridViewTextBoxColumn Com_Index;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Com_Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Com_Name;
        private System.Windows.Forms.DataGridView dgvStations;
        public System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblStationsCntTitle;
        private System.Windows.Forms.Label lblStationsCnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Nomos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Perioxi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_TK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_ComId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Dealer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Station_Company_Operated;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Station_Station_Closed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Visits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_VisitsG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_VisitsD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Parav;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_ParavG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_ParavD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_LastVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_LastDiff;
    }
}