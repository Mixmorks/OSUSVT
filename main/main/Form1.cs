using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace main
{
    public partial class mainForm : Form
    {

        GPS.GPSclass gps_data = new GPS.GPSclass();
        
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gps_data.sat_count+=2;
            textbox.Text = gps_data.sat_count.ToString();
        }

        private void textbox_Click(object sender, EventArgs e)
        {

        }

    }
}
