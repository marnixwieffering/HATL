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
    public class Receptionist : IMovable, IListner
    {
        public Point Position { get; set; }
        public Bitmap Art { get; set; } = Properties.Resources.receptionist;
        public MovableStatus Status { get; set; }
        public IArea Area { get; set; }
        
        public Dictionary<MovableStatus, Action> Actions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Hotel Hotel { get; set; }

        public Receptionist(Point position, Hotel hotel)
        {
            Position = position;
            Hotel = hotel;
            

        }

        public void Notify(HotelEvent evt)
        {
            if (evt.EventType.Equals(HotelEventType.EVACUATE))
            {

            }
        }
        
        public void RemoveGuest(Guest guest)
        {
            Hotel.RemoveGuest(guest);
        }

        public void PerformAction()
        {
        }

        public void SetPath(IArea destination)
        {
        }
    }
}
