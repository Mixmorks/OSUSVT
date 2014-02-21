using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace main
{
    static class OSUSVT
    {

        [STAThread]
        static void Main()
        {

            GPS.GPSclass GPS_class = new GPS.GPSclass();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            return;
            



        }
    }
}
