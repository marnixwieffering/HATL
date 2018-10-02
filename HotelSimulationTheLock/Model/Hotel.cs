﻿using HotelEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace HotelSimulationTheLock
{
    public class Hotel : HotelEventListener
    {
        //this list will be filled with IAreas objects
        public List<IArea> HotelAreaList = new List<IArea>();

        //a hotel needs to have a list of current guests 
        private List<Guest> _guestsList = new List<Guest>();

        //a hotel needs to have maids to cleanup stuff
        private List<Maid> _maidList = new List<Maid>();

        //a hotel has only 1 elavator
        //private Elevator _elavator = new Elevator();

        //a hotel has only 1 staircase
        //private Staircase _starcase = new Staircase();

        //amount of events per second
        public int HtePerSecond { get; set; }

        //an hotel has a background image
        public PictureBox Background { get; set; }

        public Hotel()
        {
            HotelEventManager.Register(this);
        }

        public Hotel(List<JsonModel> layout, float HTESeconds)
        {
            HotelEventManager.HTE_Factor = HTESeconds;

            AreaFactory tijdelijk = new AreaFactory();

            foreach (JsonModel i in layout)
            {
                int temp = 0;

                if (i.Classification != null)
                {
                    temp = int.Parse(Regex.Match(i.Classification, @"\d+").Value);
                }


                HotelAreaList.Add(tijdelijk.GetArea(i.AreaType, i.Position, i.Capacity, i.Dimension, temp));
            }

            SetNieghbors();

        }

        private void SetNieghbors()
        {
            int MaxX = HotelAreaList.OrderBy(X => X.Position.X).Last().Position.X + 1;

            foreach (IArea area in HotelAreaList)
            {

                bool rightSet = false;
                bool leftSet = false;

                for (int i = 1; i < MaxX; i++)
                {
                    // right edge
                    if (!rightSet && AddNiehgbor(area, i, 0, i))
                    {
                        rightSet = true;
                        continue;
                    }
                    //left edge
                    if (!leftSet && AddNiehgbor(area, -i, 0, i))
                    {
                        leftSet = true;
                        continue;
                    }
                }
                if (area.Position.X == 0 || area.Position.X == MaxX)
                {
                    // add top neighbor
                    AddNiehgbor(area, 0, 1, 1);
                    // add bothem neighbor
                    AddNiehgbor(area, 0, -1, 1);
                }
            }
        }

        private bool AddNiehgbor(IArea area, int xOffset, int yOffset, int wieght)
        {
            if (!(HotelAreaList.Find(X => X.Position == new Point(area.Position.X + xOffset, area.Position.Y + yOffset)) is null))
            {
                area.Edge.Add(HotelAreaList.Find(X => X.Position == new Point(area.Position.X + xOffset, area.Position.Y + yOffset)), wieght);
                return true;
            }
            return false;
        }

        public void Notify(HotelEvent evt)
        {
            if (evt.EventType.Equals(HotelEventType.CHECK_IN))
            {
                string name = "";
                string request = "";

                if (!(evt.Data is null))
                {
                    name = evt.Data.FirstOrDefault().Key;
                    request = evt.Data.FirstOrDefault().Value;
                }
                else
                {
                    name = "test guest";
                    request = "no request";
                }

                Guest guest = new Guest(name, request);

                Debug.WriteLine($"new guest = name: {name}, request: {request} ");
            }
        }


    }
}
