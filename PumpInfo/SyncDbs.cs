using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PumpInfo
{
    public partial class SyncDbs : Form
    {
        public SyncDbs()
        {
            InitializeComponent();
        }

        private void btnSyncGeoData_Click(object sender, EventArgs e)
        {
            Sync("StationGeoData.db");
        }

        private void btnSyncPumpInfo_Click(object sender, EventArgs e)
        {
            Sync("PumpInfo.db");
        }

        void Sync(string dbFile)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "DB File|StationGeoData.db";
            ofd.Filter = "DB File|" + dbFile;
            DialogResult result = ofd.ShowDialog();

            string DBs_Path = ofd.FileName;
            if (DBs_Path.Trim() == "" || result != DialogResult.OK)
            {
                return;
            }

            string Destination = Application.StartupPath + "\\DBs\\";
            //MessageBox.Show("Copying...\r\nFrom [" + DBs_Path + "] to [" + Destination + "]");

            try
            {
                System.IO.File.Replace(DBs_Path, Destination + dbFile, Destination + "Backup"+ DateTime.Now.ToString("yyyyMMdd_HHmmss_") + dbFile);
                MessageBox.Show("Η βάση ενημερώθηκε επιτυχώς!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
    }
}
