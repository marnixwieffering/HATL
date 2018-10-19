﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSimulationTheLock
{
    [Export(typeof(IArea))]
    [ExportMetadata("AreaType", "Lobby")]
    public class Lobby : IArea
    {
        public int ID { get; set; }
        public Point Position { get; set; }
        public Size Dimension { get; set; } = new Size(1, 1);
        public int Capacity { get; set; } = int.MaxValue;
        public Bitmap Art { get; set; } = Properties.Resources.lobby_window;
        public AreaStatus AreaStatus { get; set; }

        // dijkstra variables
        public double? BackTrackCost { get; set; }
        public IArea NearestToStart { get; set; }
        public bool Visited { get; set; }
        public Dictionary<IArea, int> Edge { get; set; } = new Dictionary<IArea, int>();
 

        public IArea CreateArea()
        {
            return new Lobby();

        }

        public void SetJsonValues(int id, Point position, int capacity, Size dimension, int classification)
        {
            ID = id;
            Position = position;

            if (classification % 2 == 0)
            {
                Art = Properties.Resources.lobby_couch;
            }

        }
        
    }
}