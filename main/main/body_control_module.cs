using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace BodyCM
{
    class BodyControlModuleclass
    {
            
            public string Teststring { get; set; }

            public bool ready {get; set; }
            public bool vehicle_wake { get; set; }
            public bool EPO { get; set; }
            public bool AC_charger_plugged { get; set; }
            public bool HVIL { get; set; }
            public int main_contactor_state { get; set; }
            public int charge_contactor_state { get; set; }
            public bool power_relay_command_state { get; set; }
            public bool power_relay_relay_monitor { get; set; }
            public int BCM_alarm_condition { get; set; }
            public double state_of_charge { get; set; }
            public double pack_current { get; set; }
            public double pack_voltage { get; set; }
            public double discharge_max { get; set; }
            public double charge_max { get; set; }
            public double discharge_buffer { get; set; }
            public double charge_buffer { get; set; }
            public double max_battery_air_temperature { get; set; }
            public bool BCM_cell_under_volt { get; set; }
            public bool BCM_cell_over_volt { get; set; }
            public double max_cell_voltage { get; set; }
            public double min_cell_voltage { get; set; }
            public double max_cell_temp { get; set; }
            public double min_cell_temp { get; set; }
            public double charge_enabled { get; set; }
            public double LV_battery_voltage { get; set; }
            public bool EEPROM_WIP { get; set; }
            public int main_contactor_step { get; set; }
            public bool fault_monitor { get; set; }
            public bool BCM_balancing { get; set; }
            public double FGD { get; set; }
            public double BatteryCurrent2 { get; set; }
            public double VBus_positive { get; set; }
            public double VBus_negative { get; set; }
            public double balancing_count { get; set; }
            public double kWH { get; set; }
            public bool charge_complete { get; set; }
            public bool charging_done { get; set; }
            
            public bool body_control_module_found_flag = false;
            public SerialPort body_control_module_port;

            public BodyControlModuleclass()
            {
                Thread body_control_module_initializer = new Thread(init_body_control_port); //We don't want to wait until everything is enitialized before building the UI so we'll outsource the work onto a separate thread.
                body_control_module_initializer.Start();
            }

            public void init_body_control_port()
            {
                string[] valid_ports;
                bool port_is_open = false;
                string test_for_arduino_string = "";

                while(!body_control_module_found_flag){ //Since this is running on a separate thread we don't need to worry about taking up resources.

                    valid_ports = SerialPort.GetPortNames();

                    foreach (string port in valid_ports) //Now we want to test every available port.
                    {
                        body_control_module_port = new SerialPort(port, 9600); //Create a new port-object with the port we're currently testing.
                        body_control_module_port.ReadTimeout = 50; //Set read timeout to 50 milliseconds.

                        try
                        {
                            body_control_module_port.Open();
                            port_is_open = true;
                        }
                        catch (UnauthorizedAccessException) //This can happen because both the GPS and Arduino class are trying to work through the ports at the same time. If a conflict occurs we'll just ignore this port for now and come back to it later.
                        {
                            port_is_open = false;
                        }

                        if (port_is_open)
                        {

                            body_control_module_port.Write("initport"); //Here we write the initialization message to the Arduino. The Arduino will read this message and then check back with us.

                            try
                            {
                                test_for_arduino_string = body_control_module_port.ReadLine();

                                if (test_for_arduino_string.Contains("arduinos")) //For some reason == or .Equals do not return true. I'm assuming there's an issue with a string terminator.
                                {
                                    body_control_module_found_flag = true;
                                    body_control_module_port.DataReceived += handle_body_control_module_data_available;
                                    return;
                                }
                            }
                            catch (TimeoutException) { }

                            body_control_module_port.Close();
                        }
                    }

                }

                    return;
            }

            public void handle_body_control_module_data_available(object sender, SerialDataReceivedEventArgs e)
            {
                try
                {
                    Teststring = body_control_module_port.ReadLine();
                }
                catch(TimeoutException)
                { 
                    //Not sure if we actually need this, considering that read_port is only called when we have data received.
                }

            }

            public void write_to_port(string data)
            {
                if(body_control_module_found_flag)
                    body_control_module_port.Write(data);
            }

    }
}
