﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace BodyCM
{
    class BodyControlModuleclass
    {
            
            public string Teststring { get; set; }
            
            public bool body_control_module_found_flag = false;
            public static SerialPort body_control_module_port;

            public BodyControlModuleclass()
            {
                init_body_control_port();
                if (!body_control_module_found_flag)
                    ;//Do something.
            }

            private void init_body_control_port()
            {
                string[] valid_ports = SerialPort.GetPortNames();
                foreach (string port in valid_ports)
                {
                    body_control_module_port = new SerialPort(port, 9600);
                    body_control_module_port.ReadTimeout = 50;
                    body_control_module_port.Open();
                    body_control_module_port.Write("initport");
                    System.Threading.Thread.Sleep(100);
                    
                        read_port();

                        if (Teststring.Contains("arduinos")) //For some reason == or .Equals do not return true. I'm assuming there's an issue with a string terminator.
                        {
                            body_control_module_found_flag = true;
                            return;
                        }

                    body_control_module_port.Close();
                }
                    return;
            }

            public void read_port()
            {
                try
                {
                    Teststring = body_control_module_port.ReadLine();
                }
                catch(TimeoutException)
                { 
                    //We can add code in here to indicate to the driver that communication with the Body Control Module has been lost.
                }

            }

    }
}
