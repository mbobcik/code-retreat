using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace C_sharp
{

    class Game
    {
        bool[,] world;
        //bool[,] newWorld;

        public Game(int size)
        {
            world = new bool[size, size];
        }

        public Game(int size, int choice)
        {
            world = new bool[size, size];
            switch (choice)
            {
                case 0:
                    RandomWorld();
                    break;
                case 1:
                    this.NewWorld1();
                    break;
                case 2:
                    this.NewWorld2();
                    break;
                case 3:
                    this.NewWorld3();
                    break;
                case 4:
                    this.NewWorld4();
                    break;
            }
        }

        public void Tick()
        {
            bool[,] newWorld = new bool[world.GetLength(0), world.GetLength(1)];

            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    newWorld[i, j] = SolveMatrix(i, j);
                }
            }
            world = (bool[,])newWorld.Clone();
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

            return Rules(lifeCount, world[i, j]);
        }

        public bool Rules(int livingCount, bool isAlive)
        {
            if (livingCount < 2)
                return false;
            else if (isAlive && (livingCount == 2 || livingCount == 3))
                return true;
            else if (!isAlive && livingCount == 3)
                return true;
            return false;
        }

        public void RandomWorld()
        {
            Random r = new Random();
            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    world[i, j] = Convert.ToBoolean(r.Next(0, 2));
                }
            }
        }


        private void NewWorld4()
        {
            throw new NotImplementedException();
        }

        private void NewWorld3()
        {
            throw new NotImplementedException();
        }

        private void NewWorld2()
        {
            throw new NotImplementedException();
        }

        // # .       . .
        // . #   =>  . .
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
                        Console.Write("# ");
                    else
                    {
                        Console.Write(". ");
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
            TextWriter stderr = Console.Error;
            Game g;

            try {
                Console.Write("select option:");
                int option = int.Parse(Console.ReadLine());
                g = new Game(10, option);
            }catch(Exception e){
                stderr.WriteLine(e);
                g = new Game(10);
            }

            g.RandomWorld();
            g.PrintWorld();

            char c = 'c';
            int runNo = 0;

            while (c != 'q')
            {
                g.Tick();
                g.PrintWorld();
                Console.WriteLine("Tick number: {0}", ++runNo);
                Thread.Sleep(300);
                try
                {
                    c = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    stderr.WriteLine(e);
                    c = 's';
                }
            }
        }
    }
}