using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PumpLib;

namespace PumpAnalysis
{
    public partial class frmVehicleTrace : Form
    {
        public frmVehicleTrace()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int veh = Convert.ToInt32(textBox13.Text);
            int yyyy = Convert.ToInt32(textBox14.Text);
            int mm = Convert.ToInt32(textBox15.Text);

            DbUtilities dbu = new DbUtilities();
            List<string[]> results = dbu.getVehicleTraceData(veh, yyyy, mm);

            textBox1.Text = results[0][0].ToString();
            textBox2.Text = results[0][1].ToString();
            textBox3.Text = results[0][2].ToString();
            textBox4.Text = results[0][3].ToString();
            textBox5.Text = results[0][4].ToString();
            textBox6.Text = results[0][5].ToString();

            textBox7.Text = results[1][0].ToString();
            textBox8.Text = results[1][1].ToString();
            textBox9.Text = results[1][2].ToString();
            textBox10.Text = results[1][3].ToString();
            textBox11.Text = results[1][4].ToString();
            textBox12.Text = results[1][5].ToString();
            
            textBox16.Text = (Convert.ToInt32(results[1][3]) - Convert.ToInt32(results[0][3])).ToString();
            textBox17.Text = "0.00"; //(Convert.ToInt32(results[0][4]) + Convert.ToInt32(results[1][4])).ToString();
            textBox18.Text = "0.00"; //(Convert.ToInt32(results[0][5]) + Convert.ToInt32(results[1][5])).ToString();
        }
    }
}
