﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEvents;


namespace HotelSimulationTheLock
{
    public enum AreaStatus
    {
        EMPTY,
        OCCUPIED,
        NEED_CLEANING
        //Etc
    }
    
    /// <summary>
    /// A uniqe identifier for an Iarea implementor
    /// </summary>
    public interface IAreaType
    {
        string AreaType { get; }
    }
    
    public interface IArea
    {
        // Movable implementation
        List<IMovable> Movables { get; set; }


        // Properties
        Point Position { get; set; }
        Size Dimension { get; set; }
        int Capacity { get; set; }
        Bitmap Art { get; set; }
        AreaStatus AreaStatus { get; set; }

        // Properties for dijkstra search
        double? BackTrackCost { get; set; }
        IArea NearestToStart { get; set; }
        bool Visited { get; set; }

        /// <summary>
        /// IArea: Conected to, Int: Time to treverse in HTE
        /// </summary>
        Dictionary<IArea, int> Edge { get; set; }
        

        // Functions
        IArea CreateArea();

        void SetJsonValues(Point position, int capacity, Size dimension, int classification);

        bool AddMovable(IMovable movable);

    }
}
