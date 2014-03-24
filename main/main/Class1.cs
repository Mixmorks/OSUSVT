using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace BodyCM
{
    class BodyControlModuleclass
    {

        public
            
            static SerialPort body_control_module_port;
            public string teststring;

            public BodyControlModuleclass(string body_control_port_name, int body_control_port_baud)
            {

                body_control_module_port = new SerialPort(body_control_port_name, body_control_port_baud);
                body_control_module_port.Open();

            }

            public void read_port()
            {
                teststring = body_control_module_port.ReadLine();
            }




    }
}
