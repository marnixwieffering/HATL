﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEvents;

namespace HotelSimulationTheLock.Caracters
{
    class Receptionist : HotelEventListener
    {
        public void Notify(HotelEvent evt)
        {
            if (evt.EventType.Equals(HotelEventType.EVACUATE))
            {

            }
        }
    }
}
