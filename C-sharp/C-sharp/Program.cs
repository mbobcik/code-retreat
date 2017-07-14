using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_sharp
{

    class Game
    {

        public List<bool> world;

        public Game(int size)
        {
            world = new List<bool>();
        }

        public int getEnvelope(int i, int j, bool[,] world)
        {
            return;// world[i - 1, j - 1] + world[i - 1, j] + world[i - 1, j + 1] + world[i, j - 1] + world[i - 1, j - 1];
        }

        public Game Transition(Game last)
        {
            Game next = new Game();

            

            return next;
        }
    }

    class Program
    {

        

        static void Main(string[] args)
        {

        }
    }
}
