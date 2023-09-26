/////////////////////////////////////////////////
//
// Author: Luke Berry, berrylp@etsu.edu
// Course: CSCI-2210-001 - Data Structures
//Assignment: Battleship Project/ Lab 1
//Description: Create the game battleship using concepts in previous classes
//
////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    /// <summary>
    /// structure for the coordinate grid map
    /// </summary>
    public struct Coord2D
    {
        public int x {get;}
        public int y {get;}
        
        public Coord2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
