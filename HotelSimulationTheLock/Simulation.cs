﻿using HotelEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HotelSimulationTheLock
{
    public partial class Simulation : Form
    {
        public Hotel Hotel { get; set; }
        public int UnitTestvalue { get; set; }
    //    public List<JsonModel> HotelLayout { get; set; }

        private Timer t { get; set; }

        private bool _pauseResume { get; set; }

        // Drawing properties
        private PictureBox HotelBackground { get; set; }
        private Bitmap HotelImage { get; set; }
        public static int RoomArtSize { get; } = 96;

        List<string> listBoxGuest = new List<string>();
        List<string> listBoxMaid = new List<string>();

        public Simulation(List<JsonModel> layout, SettingsModel Settings)
        {
            // 0.5f should be a varible in the settings data set
            Hotel = new Hotel(layout, Settings);
         //   HotelLayout = layout;
            HotelEventManager.HTE_Factor = 0.5f;

            // Does this timer work corectly with the HTE factor? -marnix
            t = new Timer
            {
                Interval = 650 // specify interval time as you want
            };
            t.Tick += new EventHandler(Timer_Tick);
            t.Start();

            HotelImage = Hotel.HotelDrawer.DrawHotel(Hotel.HotelAreas, Hotel.HotelMovables);

            HotelBackground = new PictureBox
            {
                Location = new Point(50, 100),
                Width = Hotel.HotelWidth * RoomArtSize,
                Height = Hotel.HotelHeight * RoomArtSize,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = HotelImage
            };

            Controls.Add(HotelBackground);

            // Last methods for setup
            InitializeComponent();

            _pauseResume = false;
            button1.Text = "Pause";
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Hotel.PerformAllActions();

            // fix frequent GC calls

            //every timer tick we refresh the facillity layout
            _fillFacillityTB();

            //every timer tick we refresh the moveable layout
            _fillMoveAbleTB();

            // Disposing the movable bitmap to prevent memory leaking
            // https://blogs.msdn.microsoft.com/davidklinems/2005/11/16/three-common-causes-of-memory-leaks-in-managed-applications/
            HotelImage.Dispose();
            HotelImage = Hotel.HotelDrawer.DrawHotel(Hotel.HotelAreas, Hotel.HotelMovables);
            HotelBackground.Image = HotelImage;
        }


        //Overview of hotel facilities
        private void _fillFacillityTB()
        {
            //room overview
            roomTB.Clear();
            //fintess overview
            fitnessTB.Clear();
            //restaurant
            restaurantTB.Clear();

            try
            {
                foreach (IArea i in Hotel.HotelAreas)
                {
                    string type = i.GetType().ToString().Replace("HotelSimulationTheLock.", "");

                    switch (type)
                    {

                        case "Room":
                            roomTB.Text += ((Room)i).Classification + " Star " + type + "\t" + i.AreaStatus + "\t" + ((Room)i).Position;
                            roomTB.Text += Environment.NewLine;
                            break;
                        case "Fitness":
                            fitnessTB.Text += i.GetType().ToString().Replace("HotelSimulationTheLock.", "") + ": " + i.AreaStatus;
                            fitnessTB.Text += Environment.NewLine;
                            break;
                        case "Restaurant":
                            restaurantTB.Text += i.GetType().ToString().Replace("HotelSimulationTheLock.", "") + ": " + i.AreaStatus;
                            restaurantTB.Text += Environment.NewLine;
                            break;
                        default:
                            break;
                    }

                }
            }
            catch
            {
                Debug.WriteLine("jasper fix je stats shit");
            }
        }

        private void _fillMoveAbleTB()
        {
            //guest overview
            listBoxGuest.Clear();

            //maid overview
            listBoxMaid.Clear();

            // Causes errors with current version
            // list is not lockeable 
            // status handle should not be done here


            foreach (IMovable g in Hotel.HotelMovables)
            {
                try
                {
                    if (g is Guest t)
                    {
                        listBoxGuest.Add(t.Name + "\t" + g.Status + "\t" + t.RoomRequest + "\t" + t.Position + "\n");

                        // guestTB.Text += t.Name + "\t" + g.Status + "\t" + t.RoomRequest + "\t" + t.Position;
                        //  guestTB.Text += Environment.NewLine;
                    }
                    if (g is Maid m)
                    {
                        listBoxMaid.Add("Maid \t" + m.Status + "\t" + m.Position + "\n");
                        // maidTB.Text += "Maid \t" + m.Status + "\t" + m.Position;
                        // maidTB.Text += Environment.NewLine;
                    }
                }
                catch (Exception)
                {

                    Debug.WriteLine("Jasper fix je stats shit");
                }
            }


            fillTextBoxPlease();
        }

        void fillTextBoxPlease()
        {
            guestTB.Text = "";
            maidTB.Text = "";

            foreach (string value in listBoxGuest)
            {
                guestTB.AppendText(value);
            }

            foreach (string v in listBoxMaid)
            {
                maidTB.AppendText(v);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_pauseResume)
            {
                _pauseResume = true;
                button1.Text = "Resume";
                t.Stop();
                HotelEventManager.Stop();
            }
            else
            {
                _pauseResume = false;
                button1.Text = "Pause";
                t.Start();
                HotelEventManager.Start();
            }

        }


    }
}