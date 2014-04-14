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

        #region Variables for Blinkers
        private Timer blinker_timer = new Timer();

        bool left_blinker_state = false;
        bool left_button_image_state = false;
        bool right_blinker_state = false;
        bool right_button_image_state = false;
        bool emergency_blinker_state = false;
        bool emergency_button_image_state = false;

        #endregion

        private delegate void camera_image_delegate(object sender, NewFrameEventArgs NewCameraInformation);

        int count = 0;

        GPS.GPSclass gps_data = new GPS.GPSclass();
        BodyCM.BodyControlModuleclass body_control_data = new BodyCM.BodyControlModuleclass();
        USBcam.USBcamclass camera_data = new USBcam.USBcamclass();
        //SQL.SQLclass sql_interface = new SQL.SQLclass();

        public mainForm()
        {
            InitializeComponent();

            ui_update_timer.Tick += new EventHandler(update_ui);
            ui_update_timer.Interval = 100;
            ui_update_timer.Start();

            blinker_timer.Interval = 700;

            camera_data.camera_stream.NewFrame += handle_new_camera_frame;

        }
        #region Upper Left Button Click Event
        private void button1_Click(object sender, EventArgs e)
        {
            #region Checking for other blinker states to turn off
            if (right_blinker_state)
            {
                right_blinker_state = false;
                button2.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperRightButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= right_blink_handler;
            }
            if (emergency_blinker_state)
            {
                emergency_blinker_state = false;
                button3.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/LowerLeftButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= emergency_blink_handler;
            }
            #endregion

            if (!left_blinker_state)
            {
                left_blinker_state = true;
                blinker_timer.Tick += left_blink_handler;
                blinker_timer.Start();
            }
            else 
            {
                left_blinker_state = false;
                blinker_timer.Stop();
                blinker_timer.Tick -= left_blink_handler;
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButton.png");

            }
            
        }
        #endregion
        #region Upper Right Button Click Event
        private void button2_Click(object sender, EventArgs e)
        {
            #region Checking for other blinker states to turn off
            if (left_blinker_state)
            {
                left_blinker_state = false;
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= left_blink_handler;
            }
            if (emergency_blinker_state)
            {
                emergency_blinker_state = false;
                button3.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/LowerLeftButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= emergency_blink_handler;
            }
            #endregion

            if (!right_blinker_state)
            {
                right_blinker_state = true;
                blinker_timer.Tick += right_blink_handler;
                blinker_timer.Start();
            }
            else
            {
                right_blinker_state = false;
                blinker_timer.Stop();
                blinker_timer.Tick -= right_blink_handler;
                button2.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperRightButton.png");

            }

        }
        #endregion
        #region Lower Left Button Click Event
        private void button3_Click(object sender, EventArgs e)
        {
            conupdate.Text = "CALLING!";
            #region Checking for other blinker states to turn off
            if (left_blinker_state)
            {
                left_blinker_state = false;
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= left_blink_handler;
            }
            if (right_blinker_state)
            {
                right_blinker_state = false;
                button2.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperRightButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= right_blink_handler;
            }
            #endregion

            if (!emergency_blinker_state)
            {
                emergency_blinker_state = true;
                blinker_timer.Tick += emergency_blink_handler;
                blinker_timer.Start();
            }
            else
            {
                emergency_blinker_state = false;
                blinker_timer.Stop();
                blinker_timer.Tick -= emergency_blink_handler;
                button3.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/BottomLeftButton.png");

            }

        }
        #endregion

        private void handle_new_camera_frame(object sender, NewFrameEventArgs camera_event_data)
        {
            camera_data.fetch_new_image(camera_event_data);
            if (camera_window.InvokeRequired) //These shenanigans will allow the camera frame to resize should the image be resized during runtime.
            {
                camera_image_delegate camera_image_invoke = new camera_image_delegate(handle_new_camera_frame);
                Invoke(camera_image_invoke,new Object[]{sender,camera_event_data});
            }
            else
            {
                camera_window.Image = camera_data.camera_image;
            }      
        }

        private void update_ui(object sender, EventArgs e)
        {
                conupdate.Text = body_control_data.Teststring;
                count++;
        }

        #region Code that handles the blinkers

        private void left_blink_handler(object sender, EventArgs e)
        {
            if (!left_button_image_state)
            {
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButtonDark.png");
                left_button_image_state = true;

                if (body_control_data.body_control_module_found_flag)
                    body_control_data.body_control_module_port.Write("leftblnk");

            }
            else
            {
                left_button_image_state = false;
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButton.png");
            }
        }

        private void right_blink_handler(object sender, EventArgs e)
        {
            if (!right_button_image_state)
            {
                button2.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperRightButtonDark.png");
                right_button_image_state = true;

                if (body_control_data.body_control_module_found_flag)
                    body_control_data.body_control_module_port.Write("rghtblnk");

            }
            else
            {
                right_button_image_state = false;
                button2.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperRightButton.png");
            }
        }

        private void emergency_blink_handler(object sender, EventArgs e)
        {
            if (!emergency_button_image_state)
            {
                button3.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/LowerLeftButtonDark.png");
                emergency_button_image_state = true;

                if (body_control_data.body_control_module_found_flag)
                    body_control_data.body_control_module_port.Write("emergncy");

            }
            else
            {
                emergency_button_image_state = false;
                button3.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/LowerLeftButton.png");
            }
        }

        #endregion

    }

}
