﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PumpInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            
            string receiptFile_Path = ofd.FileName;

            if (receiptFile_Path.Trim() == "")
            {
                return;
            }

            DbUtilities DBU = new DbUtilities(receiptFile_Path);
            List<ImpData> objList = DBU.FillListFromReceipt();

            objList = DBU.GetDataNotExistsInSQLiteTable(objList);

            List<object[]> ObjRows = DBU.ImpDataListToGridViewRowList(objList);

            DBU.ShowDataToDataGridView(dgvReceiptData, ObjRows);

            int help = 0;
            //bool successfulInsertion = DBU.InsertReceiptAllDataIntoSQLiteTable(objList);

        }
    }
}
