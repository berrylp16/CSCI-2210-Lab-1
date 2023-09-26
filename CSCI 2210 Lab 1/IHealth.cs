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
   /// the interface for health
   /// </summary>
    internal interface IHealth
    {
        int GetMaxHealth();
        int GetCurrentHealth();
        bool IsDead();
        void TakeDamage(Coord2D point);
    }
}
