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
        BodyCM.BodyControlModuleclass body_control_data = new BodyCM.BodyControlModuleclass("COM3", 9600);
        public delegate void SetTextCallback(string text);


        public mainForm()
        {
            InitializeComponent();
            GPS.GPSclass.gps_port.DataReceived += gps_data.handle_GPS_data_available; //Shortcut way of writing port.DataReceived += new SerialDataReceivedEventHandler(eventhandler)
            BodyCM.BodyControlModuleclass.body_control_module_port.DataReceived += handle_body_control_data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textbox.Text = "Test.";
            string[] valid_ports = SerialPort.GetPortNames(); //GetPortNames() checks the registry (i.e. HKEY_LOCAL_MACHINE\HARDWARE\DEVICEMAP\SERIALCOMM)
            textbox.Text = String.Join(", ", valid_ports);    //For some reason this turns up blank on my laptop.

        }

        private void handle_GPS_data(object sender, SerialDataReceivedEventArgs e)
        { 

        }

        private void handle_body_control_data(object sender, SerialDataReceivedEventArgs e)
        {
            body_control_data.read_port();
            reset_ui(body_control_data.teststring);
        }

        private void reset_ui(string text)
        {

            if (conupdate.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(reset_ui);
                Invoke(d, new object[] { text });
            }
            else
            {
                conupdate.Text = body_control_data.teststring;
            }

        }

    }
}
