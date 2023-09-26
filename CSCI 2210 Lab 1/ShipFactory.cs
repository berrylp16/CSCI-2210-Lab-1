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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace battleship
{
    /// <summary>
    /// class for making the ships from a file
    /// </summary>
    public class ShipFactory
    {
        private static int xPostionInt;
        private static string Bigorientation;
        private static string yPosition;

        /// <summary>
        /// makes sure the file is ok to be read
        /// </summary>
        /// <param name="description">the entire file that needs to be read</param>
        /// <returns>true if file is valid, false if file is invalid</returns>
        /// <exception cref="Exception">if something can't be read or understood, exception is thrown</exception>
        static bool VerifyShipString(string description)
        {
            Regex regex =  new Regex(@"(Carrier|Battleship|Destroyer|Submarine|Patrol Boat),\\s[2-5]+,\\s(h|v|H|V),\\s[0-9],\\s[0-9]\\s*\");

            if (regex.IsMatch(description))
            {
                string[] boatClass = description.Split(',');
                if (boatClass.Length != 5)
                {
                    throw new Exception("Invalid boat names.");
                    return false;
                }

                string size = boatClass[0].Trim();
                int length;
                if (!int.TryParse(boatClass[1].Trim(), out length) || length < 2 && length > 6)
                {
                    throw new Exception("Invalid size of ships.");
                    return false;
                }

                string BigOrientation = boatClass[2].Trim();
                string orientation = BigOrientation.ToLower();
                if (orientation != "h" && orientation != "v")
                {
                    throw new Exception("Invalid orientation.");
                    return false;
                }

                string xPosition = boatClass[3].Trim();
                int xPositionInt = Int32.Parse(xPosition);
                if(!string.IsNullOrEmpty(xPosition) || xPositionInt < 0 || xPostionInt + (orientation == "h" ? length - 1 : 0) > 9) 
                {
                    throw new Exception("Invalid x postion.");
                    return false;
                }
                string yPostion = boatClass[4].Trim();
                int yPositionInt = Int32.Parse(yPostion);
                if(!string.IsNullOrEmpty(yPosition) || yPositionInt < 0 || yPositionInt + (orientation == "v" ? length - 1 : 0) > 9)
                {
                    throw new Exception("Invalid y position.");
                    return false;
                }

                return true;

            } else
            {
                return false;
            }
        }

        /// <summary>
        /// parses and returns a new ship
        /// </summary>
        /// <param name="description">the text that was verified in the VerifyShipString method</param>
        /// <returns>new ships</returns>
        static Ship ParseShipString(string description)
        {
            string[] boatClass = description.Split(',');
            string size = boatClass[0].Trim();
            byte length = byte.Parse(boatClass[1].Trim());
            DirectionType BigOrientation = boatClass[2].Trim().ToLower() == "h" ? DirectionType.Horizontal : DirectionType.Vertical;
            int xPositionInt = Int32.Parse(boatClass[3].Trim());
            int yPostionInt = Int32.Parse(boatClass[4].Trim());

            switch(size.ToUpper())
            {
                case "CARRIER":
                    return new Ship.Carrier(new Coord2D(xPositionInt, yPostionInt), BigOrientation);
                case "BATTLESHIP":
                    return new Ship.Battleship(new Coord2D(xPositionInt, yPostionInt), BigOrientation);
                case "DESTORYER":
                    return new Ship.Destroyer(new Coord2D(xPositionInt, yPostionInt), BigOrientation);
                case "SUBMARINE":
                    return new Ship.Submarine(new Coord2D(xPositionInt, yPostionInt), BigOrientation);
                case "PATROL BOAT":
                    return new Ship.PatrolBoat(new Coord2D(xPositionInt, yPostionInt), BigOrientation);
                default: throw new Exception();

            }
        }

        public static Ship[] ParseShipFile(string filePath)
        {
           
            List<Ship> list = new List<Ship>();
            File.ReadAllLines(@"C:\Users\lukey\Downloads\Battleship-TestData (1)");
            StreamReader sr = new StreamReader(filePath);

            while(sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if(line == null)
                {
                    continue;
                }

                if(!line.TrimStart().StartsWith('#'))
                {
                    if(VerifyShipString(line))
                    {
                        Ship ship = ParseShipString(line);
                        list.Add(ship);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid ship data in line: {line}");
                    }
                }
            }
            return list.ToArray();
        }
    }
}
