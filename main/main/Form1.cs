using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace main
{
    public partial class mainForm : Form
    {

        GPS.GPSclass gps_data = new GPS.GPSclass("COM1", 9600);


        public mainForm()
        {
            gps_data.handler = gps_data.handle_GPS_data_available; //MS sucks Donkey Balls!
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textbox.Text = "Test.";
            string[] valid_ports = SerialPort.GetPortNames(); //GetPortNames() checks the registry (i.e. HKEY_LOCAL_MACHINE\HARDWARE\DEVICEMAP\SERIALCOMM)
            textbox.Text = String.Join(", ", valid_ports);    //For some reason this turns up blank on my laptop.
            gps_data.handler();
        }

        private void textbox_Click(object sender, EventArgs e)
        {

        }


    }
}
