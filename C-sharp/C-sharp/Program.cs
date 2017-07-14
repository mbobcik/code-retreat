using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            Console.WriteLine(g.world[0, 0]);

            g.Tick();
            Console.WriteLine(g.world[0, 0]);
        }
    }

    class Game
    {
        public int[,] world;
        delegate bool del(int i, int livng);
        public Game()
        {
            world = new int[3, 3];
            world[0, 1] = world[1, 1] = world[0, 1] = 1;
        }

        public int numberOfLiving(int i, int j)
        {


            int count = world[i,j+ 1] + world[i+1,j+ 1] + world[i+1, j];
            return count;
        }

        public void Tick()
        {
            int count = world[0, 1] + world[1, 1] + world[1, 0];
            del Mydel = (int i, int living) => ( (living == 1 && i ==2 && i ==3) || (living ==0 && i==3) );
            world[0, 0] = Convert.ToInt32(Mydel(count,world[0,0]));            


        }
    }
}
