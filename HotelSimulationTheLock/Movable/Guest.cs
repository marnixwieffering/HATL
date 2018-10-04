﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelEvents;

namespace HotelSimulationTheLock
{
    public class Guest : IMovable, HotelEventListener
    {
        public Random rng = new Random();
        public Point Position { get; set; }
        public PictureBox Art { get; set; }
        public MovableStatus Status { get; set; }

        public string Name { get; set; }
        public int RoomRequest { get; set; }
        public IArea area { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Guest(string name, int roomRequest, int x, int y)
        {
            // TO BE CHANGED NO PIXTURE BOX SPAM
            Art = new PictureBox();
            RoomRequest = roomRequest;
            Name = name;
            Art.Image = Properties.Resources.customer;
            Art.SizeMode = PictureBoxSizeMode.AutoSize;
            Position = new Point(x, y);
            Art.Location = Position;
        }

        public void MoveCustomer(Guest guest)
        {
            Position = new Point(guest.Position.X + rng.Next(10,50), guest.Position.Y);
            Art.Location = Position;
        }

        public void Notify(HotelEvent evt)
        {
            switch (evt.EventType)
            {         
                
                // find requested guest

                case HotelEventType.CHECK_OUT:
                    // guest.checkout()
                    break;
                case HotelEventType.EVACUATE:
                    // guest.evacuate()
                    break;
                case HotelEventType.NEED_FOOD:
                    // guest.GoToRestaurant()
                    break;
                case HotelEventType.GOTO_CINEMA:
                    // guest.GoToCinema()
                    break;
                case HotelEventType.GOTO_FITNESS:
                    // guest.GoToFitness()
                    break;
                default:
                    break;
            }
        }
    }
}
