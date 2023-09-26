/////////////////////////////////////////////////
//
// Author: Luke Berry, berrylp@etsu.edu
// Course: CSCI-2210-001 - Data Structures
//Assignment: Battleship Project/ Lab 1
//Description: Create the game battleship using concepts in previous classes
//
////////////////////////////////////////////////

using System.Security.Cryptography.X509Certificates;

namespace battleship
{
    class Program
    {
        static List<Ship> Ships = new List<Ship>();
        static void Main(string[] args)
        {
            bool allDead = false;
            while (!allDead)
            {
                Console.WriteLine("Would you like to attack (attack), show information (info), or exit the program (exit)?");
                string answer = Console.ReadLine();
                switch (answer.ToUpper())
                {
                    case "INFO":
                        ShowInfo();
                        break;
                    case "EXIT":
                        Console.WriteLine("Ok fine I guess just say you hate this game.");
                        break;
                    case "ATTACK":
                        Console.WriteLine("Where do you want to attack (in x, y format)?");
                        string BS = Console.ReadLine();
                        GameTime(BS);
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Try again.");
                        break;
                }

                allDead = Ships.TrueForAll(ship => ship.IsDead());
            }
            Console.WriteLine("Game over! All ships have been sunk!");
        }


        /// <summary>
        /// the logic of the game
        /// </summary>
        /// <param name="BS">the point that the player put in</param>
        static void GameTime(string BS)
        {
            string[] attack = BS.Split(',');
            string Xint = attack[0];
            int x = int.Parse(attack[0]);
            string Yint = attack[1];
            int y = int.Parse(attack[1]);
            Coord2D target = new Coord2D(x, y);

            foreach (var ships in Ships)
            {
                if (ships.Check(target))
                {
                    ships.Damage(target);
                    Console.WriteLine($"The {ships.GetName} is hit at ({x}, {y})!");

                    if (ships.IsDead())
                    {
                        Console.WriteLine($"You sunk my battleship! {ships.GetName} is sunk!");
                    }
                    return;
                }

                Console.WriteLine($"You missed! No ships are at ({x}, {y})");
            }
        }

       /// <summary>
       /// shows information for every ship
       /// </summary>
        static void ShowInfo()
        {
            foreach (var ship in Ships) 
            {
                Console.WriteLine(ship.GetInfo());
            }
        }
    }
}