﻿using System;
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
            return;
            



        }
    }
}
