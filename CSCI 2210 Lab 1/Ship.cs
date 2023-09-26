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
using System.Threading.Channels;
using System.Threading.Tasks;

namespace battleship
{
   /// <summary>
   /// abstract class for the ships
   /// </summary>
    public abstract class Ship : IHealth, IInfomatic
    {
        private Coord2D coord2D;
        private DirectionType bigOrientation;
        private int v;

        protected List<Coord2D> points {get; set;}
        public  List<Coord2D> DamagedPoints {get; set;}
        public Coord2D position {get; set;}
        public  DirectionType direction {get; set;}
        public byte length {get;}

        /// <summary>
        /// constructor for the ship class
        /// </summary>
        /// <param name="points">points the ship takes up on the grid</param>
        /// <param name="damagedPoints">points that have been hit</param>
        /// <param name="position">point of the initial position of the ship</param>
        /// <param name="direction">way the ship is facing(horizontal or vertical</param>
        /// <param name="length">number of points the ships have</param>
        public Ship(List<Coord2D> points, List<Coord2D> damagedPoints, Coord2D position, DirectionType direction, byte length)
        {
            this.points = points;
            DamagedPoints = damagedPoints;
            this.position = position;
            this.direction = direction;
            this.length = length;
        }

        protected Ship(Coord2D coord2D, DirectionType bigOrientation, int v)
        {
            this.coord2D = coord2D;
            this.bigOrientation = bigOrientation;
            this.v = v;
        }

        /// <summary>
        /// gets max health of the ship
        /// </summary>
        /// <returns>length of the ship (same thing as health)</returns>
        public int MaxHealth()
        {
            return length;
        }

       /// <summary>
       /// gets current health of the ship
       /// </summary>
       /// <returns>how much health the ship currently has</returns>
        public int CurrentHealth()
        {
            return MaxHealth() - DamagedPoints.Count;
        }

       /// <summary>
       /// determines if the ship is sunk
       /// </summary>
       /// <returns>1 if alive, 0 if dead</returns>
        public bool IsDead()
        {
            return CurrentHealth() <= 0;

        }



        public abstract string GetName();
        public abstract int GetMaxHealth();
        public abstract int GetCurrentHealth();
        public abstract void TakeDamage(Coord2D point);

        /// <summary>
        /// patrol boat class for different classifications
        /// </summary>
        internal class PatrolBoat : Ship
        {
            public PatrolBoat(Coord2D coord2D, DirectionType bigOrientation) : base(coord2D, bigOrientation, 2)
            {
            }

            public override int GetCurrentHealth()
            {
                throw new NotImplementedException();
            }

            public override int GetMaxHealth()
            {
                throw new NotImplementedException();
            }

            public override string GetName()
            {
                return "Patrol Boat";
            }

            public override void TakeDamage(Coord2D point)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// submarine class for different classifications
        /// </summary>
        internal class Submarine : Ship
        {
            public Submarine(Coord2D coord2D, DirectionType bigOrientation) : base(coord2D, bigOrientation, 3)
            {
            }

            public override int GetCurrentHealth()
            {
                throw new NotImplementedException();
            }

            public override int GetMaxHealth()
            {
                throw new NotImplementedException();
            }

            public override string GetName()
            {
                return "Submarine";
            }

            public override void TakeDamage(Coord2D point)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// destroyer class for different classifications
        /// </summary>
        internal class Destroyer : Ship
        {
            public Destroyer(Coord2D coord2D, DirectionType bigOrientation) : base(coord2D, bigOrientation, 3)
            {
            }

            public override int GetCurrentHealth()
            {
                throw new NotImplementedException();
            }

            public override int GetMaxHealth()
            {
                throw new NotImplementedException();
            }

            public override string GetName()
            {
                return "Destroyer";
            }

            public override void TakeDamage(Coord2D point)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// battleship class for differnt classifications
        /// </summary>
        internal class Battleship : Ship
        {
            public Battleship(Coord2D coord2D, DirectionType bigOrientation) : base(coord2D, bigOrientation, 4)
            {
            }

            public override int GetCurrentHealth()
            {
                throw new NotImplementedException();
            }

            public override int GetMaxHealth()
            {
                throw new NotImplementedException();
            }

            public override string GetName()
            {
                return "Battleship";
            }

            public override void TakeDamage(Coord2D point)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// carrier class for different classifications
        /// </summary>
        internal class Carrier : Ship
        {
            public Carrier(Coord2D coord2D, DirectionType bigOrientation) : base(coord2D, bigOrientation, 5)
            {
            }

            public override int GetCurrentHealth()
            {
                throw new NotImplementedException();
            }

            public override int GetMaxHealth()
            {
                throw new NotImplementedException();
            }

            public override string GetName()
            {
                return "Carrier";
            }

            public override void TakeDamage(Coord2D point)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// class for taking damage
        /// </summary>
        /// <param name="point">location of the hit in Coord2D struct</param>
        public void Damage(Coord2D point)
        {
            if(!DamagedPoints.Contains(point))
            {
                DamagedPoints.Add(point);
            }
        }

        /// <summary>
        /// general information of the ships
        /// </summary>
        /// <returns>name, current health, death, position, length, orientation of the ship at that moment</returns>
        public string GetInfo()
        {
            return $"Name: {GetName}\nHealth: {GetCurrentHealth}\nSank: {IsDead}\nPosition: ({position.x}, {position.y})\nLength: {length}\nOrientation: {direction} ";
        }

       /// <summary>
       /// checks if ship contains a point
       /// </summary>
       /// <param name="point">point in question</param>
       /// <returns>1 if yes, 0 if no</returns>
        public bool Check(Coord2D point)
        {
            return points.Contains(point);
        }
       /// <summary>
       /// used for adding points to the ship's initial starting point to get the total length 
       /// </summary>
        private void GeneratePoints()
        {
            points = new List<Coord2D>();
            int x = position.x;
            int y = position.y;

            for(int i = 0; i > 0; i++) 
            {
                if (direction == DirectionType.Horizontal)
                {
                    x++;
                }
                else
                    y++;
            }

        }
    }
}
