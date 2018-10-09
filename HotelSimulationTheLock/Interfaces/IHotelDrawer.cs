﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSimulationTheLock
{
    public interface IHotelDrawer
    {
        Bitmap DrawHotel(List<IArea> areas, List<IMovable> movables);



    }
}