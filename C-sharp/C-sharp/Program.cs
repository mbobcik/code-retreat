using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            if (g != null)
            {
                Console.WriteLine("not null: passed");
            }

            if(g.world.GetLength(0) == 10)
            {
                Console.WriteLine("world size: passed");
            }






            Console.ReadLine();
        }
    }

    public class Game
    {
        private int numOfNeighbours;
        public bool[,] world;
        public bool[,] world2;
        public Game()
        {

            world = new bool[3, 3];
            world2 = new bool[3, 3];
            numOfNeighbours = 0;
        }

        public void Tick()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    runOver(i, j);
                    //if()
                }
            }
        }

        private void runOver(int i, int j)
        {
            numOfNeighbours = 0;
            for (int o = i - 1; o < i + 1; o++)
            {
                for (int p = j - 1; p < j + 1; p++)
                {
                    if (world[o, p] == true)
                        numOfNeighbours++;
                }
            }

            if (numOfNeighbours < 2)
            {
                world2[i, j] = false;
            }
        }
    }
}
