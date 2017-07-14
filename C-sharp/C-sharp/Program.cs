using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_sharp
{

    class Game
    {
        bool[,] world;
        bool[,] newWorld;

        public Game(int size)
        {
            world = new bool[size, size];
        }

        public void Tick()
        {
            newWorld = new bool[world.GetLength(0), world.GetLength(1)];

            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    newWorld[i,j]= SolveMatrix(i, j);
                }
            }
            world = newWorld;
        }

        private bool SolveMatrix(int i, int j)
        {
            int lifeCount = 0;
            for (int m = i - 1; m < i + 1; m++)
            {
                for (int n = j - 1; n < j + 1; n++)
                {
                    if (m < 0 || n < 0 || m > world.GetLength(0) || n > world.GetLength(1))
                        continue;
                    if (m == i && n == j)
                        continue;
                    if (world[m, n])
                        lifeCount++;
                }
            }

            if (world[i, j])
            {
                if (lifeCount < 2)
                    return false;
                else if (lifeCount >= 2 && lifeCount <= 3)
                    return true;
                else
                    return false;
            }
            else
            {
                if (lifeCount == 3)
                    return true;
                return false;
            }
        }

        public void RandomWorld()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {

                }
            }
        }

        public void NewWorld1()
        {
            world[0, 0] = true;
            world[1, 1] = true; 
        }

        public void PrintWorld()
        {
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    if (world[i, j])
                        Console.Write("* ");
                    else
                    {
                        Console.Write("# ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("_____________________________________");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(10);
            g.NewWorld1();
            g.PrintWorld();
            g.Tick();
            g.PrintWorld();




            Console.ReadLine();
        }
    }
}
