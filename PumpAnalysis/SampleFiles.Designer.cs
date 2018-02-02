namespace PumpAnalysis
{
    partial class SampleFiles
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
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lvAttachedFiles = new System.Windows.Forms.ListView();
            this.AttachedFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnAddFiles.Image = global::PumpAnalysis.Properties.Resources.AddAttachment_16x;
            this.btnAddFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFiles.Location = new System.Drawing.Point(28, 22);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(120, 28);
            this.btnAddFiles.TabIndex = 27;
            this.btnAddFiles.Text = "Add File(s)";
            this.btnAddFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // lvAttachedFiles
            // 
            this.lvAttachedFiles.AllowDrop = true;
            this.lvAttachedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttachedFiles});
            this.lvAttachedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lvAttachedFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAttachedFiles.Location = new System.Drawing.Point(172, 22);
            this.lvAttachedFiles.MultiSelect = false;
            this.lvAttachedFiles.Name = "lvAttachedFiles";
            this.lvAttachedFiles.Size = new System.Drawing.Size(280, 148);
            this.lvAttachedFiles.TabIndex = 26;
            this.lvAttachedFiles.UseCompatibleStateImageBehavior = false;
            this.lvAttachedFiles.View = System.Windows.Forms.View.Details;
            this.lvAttachedFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvAttachedFiles_DragDrop);
            this.lvAttachedFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvAttachedFiles_DragEnter);
            // 
            // AttachedFiles
            // 
            this.AttachedFiles.Text = "Sample Files";
            this.AttachedFiles.Width = 250;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnOpenFile.Image = global::PumpAnalysis.Properties.Resources.OpenAttachment_16x;
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.Location = new System.Drawing.Point(26, 62);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(120, 28);
            this.btnOpenFile.TabIndex = 28;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRemoveAll.Image = global::PumpAnalysis.Properties.Resources.DeleteAttachment_16x;
            this.btnRemoveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveAll.Location = new System.Drawing.Point(26, 142);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveAll.TabIndex = 30;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnRemoveFile.Image = global::PumpAnalysis.Properties.Resources.DeleteAttachment_16x;
            this.btnRemoveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFile.Location = new System.Drawing.Point(26, 102);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveFile.TabIndex = 29;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnSave.Image = global::PumpAnalysis.Properties.Resources.Save_32x;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(175, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Αποθήκευση";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SampleFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.lvAttachedFiles);
            this.Name = "SampleFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sample Files";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnAddFiles;
        public System.Windows.Forms.ListView lvAttachedFiles;
        private System.Windows.Forms.ColumnHeader AttachedFiles;
        public System.Windows.Forms.Button btnSave;
    }
}