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
// and have been added through Project --> Add Reference. We need these in here to be able to access the .NewFrame event.
using AForge.Video;
using AForge.Video.DirectShow;


namespace main
{
    public partial class mainForm : Form
    {
        private Timer ui_update_timer = new Timer(); //This timer will update the UI at 100 ms intervals.
        private Timer sql_update_timer = new Timer();

        #region Variables for Blinkers
        /*
         * Every timer has 2 variables: blinker_states tells us if the timer has been activated and
         * blinker_image_state helps us switch the blinker button on and off.
         */
        private Timer blinker_timer = new Timer(); //This timer will have the blinker change every 700 ms.

        bool left_blinker_state = false;
        bool left_button_image_state = false;
        bool right_blinker_state = false;
        bool right_button_image_state = false;
        bool emergency_blinker_state = false;
        bool emergency_button_image_state = false;

        #endregion

        //Delegates can be used to call functions of equal return type and arguments. This delegate is used to handle the new_camera_frame envent.
        private delegate void camera_image_delegate(object sender, NewFrameEventArgs NewCameraInformation);

        int count = 0; //This variable doesn't serve a particular purpose.

        //This block initializes all the different modules of the car. Have a look at the corresponding class definitions to see the constructor.
        GPS.GPSclass gps_data = new GPS.GPSclass();
        BodyCM.BodyControlModuleclass body_control_data = new BodyCM.BodyControlModuleclass();
        USBcam.USBcamclass camera_data = new USBcam.USBcamclass();
        SQL.SQLclass sql_interface = new SQL.SQLclass();

        public mainForm() //Constructor for main form. In here I set timers and assign functions to events.
        {
            InitializeComponent();

            ui_update_timer.Tick += new EventHandler(update_ui); //This has the update_ui function called with every tick of the timer.
            ui_update_timer.Interval = 100;                      //ui_update_timer will 'tick' every 100 ms.
            ui_update_timer.Start();

            sql_update_timer.Tick += new EventHandler(update_sql_database);
            sql_update_timer.Interval = 1000;
            sql_update_timer.Start();

            blinker_timer.Interval = 700;                        //The reason I only initialize the timer interval here is because
                                                                 //I will call separate functions using this blinker_timer 
                                                                 //(depending on which blinker we decide to turn on).

            camera_data.camera_stream.NewFrame += handle_new_camera_frame; //Connects the handle_new_camera_frame function to the NewFrame event of the camera stream.

        }

        #region Upper Left Button Click Event
        private void button1_Click(object sender, EventArgs e) //This event is called when the upper left button on the form is pushed.
        {
            #region Checking for other blinker states to turn off
            if (right_blinker_state) //If the right blinker is turned on we need to turn it off and reset the button.
            {
                right_blinker_state = false; //Set right blinker to off.
                button2.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperRightButton.png"); //Turn image back to normal
                blinker_timer.Stop();
                blinker_timer.Tick -= right_blink_handler; //Unhook the right_blink_handler function from the timer_tick event.
            }
            if (emergency_blinker_state) //Same as with right_blinker_state
            {
                emergency_blinker_state = false;
                button3.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/LowerLeftButton.png");
                blinker_timer.Stop();
                blinker_timer.Tick -= emergency_blink_handler;
            }
            #endregion

            if (!left_blinker_state) //If blinker is off
            {
                left_blinker_state = true; //Turn blinker on
                blinker_timer.Tick += left_blink_handler; //Connect left_blink_handler to timer.Tick event.
                blinker_timer.Start(); //Start timer.
            }
            else 
            {
                left_blinker_state = false; //Turn blinker off
                blinker_timer.Stop();
                blinker_timer.Tick -= left_blink_handler; //Unhook left_blink_handler from timer.Tick event
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButton.png"); //Reset image.

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
        #region Code that handles the blinkers

        private void left_blink_handler(object sender, EventArgs e) //These handlers will switch the buttons between an on and off state to create a blinking effect.
        {
            if (!left_button_image_state)
            {
                button1.Image = System.Drawing.Image.FromFile("C:/Users/Student/Documents/GitHub/OSUSVT/images/UpperLeftButtonDark.png");
                left_button_image_state = true;

                if (body_control_data.body_control_module_found_flag) //Making sure that we only write to the port if it is actually open.
                    body_control_data.body_control_module_port.Write("leftblnk"); //Write an eventspecific string to the Arduino

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

        private void handle_new_camera_frame(object sender, NewFrameEventArgs camera_event_data) //This will update the camera_window whenever there is a new image available.
        {
            camera_data.fetch_new_image(camera_event_data); //Updates the image bitmap in the camera_data class.
            if (camera_window.InvokeRequired) //These shenanigans will allow the camera frame to resize should the image be resized during runtime.
            {
                camera_image_delegate camera_image_invoke = new camera_image_delegate(handle_new_camera_frame); //Watch my youtube video on Invokes for explanation.
                Invoke(camera_image_invoke,new Object[]{sender,camera_event_data});
            }
            else
            {
                camera_window.Image = camera_data.camera_image;
            }      
        }

        private void update_ui(object sender, EventArgs e) //Obviously this will need some more code for every ui_element that we want to update.
        {
                conupdate.Text = Convert.ToString((Convert.ToInt16(sql_interface.get_average("velocity",5))));
                portbox.Text = gps_data.Latitude;
                count++;
        }

        private void update_sql_database(object sender, EventArgs e)
        {
            sql_interface.update_database(gps_data.Longitude, gps_data.Latitude,gps_data.Velocity,gps_data.Altitude);
            label1.Text = Convert.ToString(count);
        }

    }

}
