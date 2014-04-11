using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

//Video Libraries. These are part of the AForge Framework stored under C:/Programs(x86)/AForge.NET/framework/release/
// and have been added through Project --> Add Reference
using AForge.Video;
using AForge.Video.DirectShow;


namespace main
{
    public partial class mainForm : Form
    {
        private Timer ui_update_timer = new Timer();
        int count = 0;

        GPS.GPSclass gps_data = new GPS.GPSclass();
        BodyCM.BodyControlModuleclass body_control_data = new BodyCM.BodyControlModuleclass();
        USBcam.USBcamclass camera_data = new USBcam.USBcamclass();
        SQL.SQLclass sql_interface = new SQL.SQLclass();

        public mainForm()
        {
            InitializeComponent();
            ui_update_timer.Tick += new EventHandler(update_ui);
            ui_update_timer.Interval = 500;
            ui_update_timer.Start();

            //camera_data.camera_stream.NewFrame += handle_new_camera_frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valid_ports = SerialPort.GetPortNames(); //GetPortNames() checks the registry (i.e. HKEY_LOCAL_MACHINE\HARDWARE\DEVICEMAP\SERIALCOMM)
            textbox.Text = String.Join(", ", valid_ports);

            if (body_control_data.body_control_module_found_flag)
                body_control_data.body_control_module_port.Write("buttonaa");

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void handle_new_camera_frame(object sender, NewFrameEventArgs camera_event_data)
        {
            camera_data.fetch_new_image(camera_event_data);
            camera_window.Image = camera_data.camera_image;
        }

        private void update_ui(object sender, EventArgs e)
        {
                conupdate.Text = body_control_data.Teststring;
                latitude.Text = gps_data.Latitude;
                longitude.Text = gps_data.Longitude;
                satcount.Text = gps_data.Sat_count;
                velocity.Text = gps_data.Velocity;
                altitude.Text = gps_data.Altitude;
                bearing.Text = gps_data.Bearing;
                nos.Text = gps_data.NoS;
                eow.Text = count.ToString();
                count++;
        }

    }
}
