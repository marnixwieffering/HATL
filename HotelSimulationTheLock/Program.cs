﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelEvents;

namespace HotelSimulationTheLock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ExtendedRoomsModel a = new ExtendedRoomsModel();

            //string[] typa = { "Room", "Pool", "Fitness", "Cinema" };

            //List<IArea> temp = new List<IArea>();

            //for (int i = 0; i < typa.Length; i++)
            //{
            //    temp.Add(a.AreaFactory.GetArea(typa[i]));
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupScreen());          
        }
    }
}
