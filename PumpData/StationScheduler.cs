using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;

namespace PumpData
{
    public partial class StationScheduler : Form
    {
        public StationScheduler()
        {
            InitializeComponent();

            cbVehicleNo.Items.AddRange(DbUtilities.GetVehiclesComboboxItemsList(vehicles).ToArray<ComboboxItem>());

            applyFilterEvents = true;


            dgvReceiptData.Rows.Add(new object[] { 1, 0, "TestA1", "TestA2" });
            dgvReceiptData.Rows.Add(new object[] { 1, 0, "TestB1", "TestB2" });

        }

        public List<Vehicle> vehicles = DbUtilities.GetSqlVehiclesList();
        bool applyFilterEvents = false;

        private void cbVehicleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applyFilterEvents == false)
            {
                return;
            }

            //...
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }
    }
}
