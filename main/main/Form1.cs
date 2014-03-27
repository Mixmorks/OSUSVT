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

        //GPS.GPSclass gps_data = new GPS.GPSclass("COM1", 9600);
        BodyCM.BodyControlModuleclass body_control_data = new BodyCM.BodyControlModuleclass("COM5", 9600);
        public delegate void SetTextCallback();


        public mainForm()
        {
            InitializeComponent();
            //GPS.GPSclass.gps_port.DataReceived += gps_data.handle_GPS_data_available; //Shortcut way of writing port.DataReceived += new SerialDataReceivedEventHandler(eventhandler)
            BodyCM.BodyControlModuleclass.body_control_module_port.DataReceived += handle_body_control_data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valid_ports = SerialPort.GetPortNames(); //GetPortNames() checks the registry (i.e. HKEY_LOCAL_MACHINE\HARDWARE\DEVICEMAP\SERIALCOMM)
            textbox.Text = String.Join(", ", valid_ports);
            BodyCM.BodyControlModuleclass.body_control_module_port.Write("testmess");

        }

        private void handle_GPS_data(object sender, SerialDataReceivedEventArgs e)
        {
            //gps_data.handle_GPS_data_available();
            update_ui(); //handle_GPS_data is on the main thread so reset_ui takes us back to the main thread in order to update
        }

        private void handle_body_control_data(object sender, SerialDataReceivedEventArgs e)
        {
            body_control_data.read_port();
            update_ui();
        }

        private void update_ui()
        {

            if (conupdate.InvokeRequired || latitude.InvokeRequired)
            {
                SetTextCallback reset_ui_delegate = new SetTextCallback(update_ui); //This delegate will call update_ui when called.
                Invoke(reset_ui_delegate); //Calls the reset_ui_delegate but on the thread
            }
            else
            {
                conupdate.Text = body_control_data.teststring;
                /*latitude.Text = gps_data.Latitude;
                longitude.Text = gps_data.Longitude;
                satcount.Text = gps_data.Sat_count;
                velocity.Text = gps_data.Velocity;
                altitude.Text = gps_data.Altitude;
                bearing.Text = gps_data.Bearing;
                nos.Text = gps_data.NoS;
                eow.Text = gps_data.EoW;*/
            }

        }

    }
}
