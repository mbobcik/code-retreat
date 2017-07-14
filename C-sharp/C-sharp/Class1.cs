using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace C_sharp
{
    [TestFixture]
    class Test1
    {
        [TestCase]
        public void GameOfLife_SampleTest()
        {

            Game g = new Game();
            Assert.IsNotNull(g);
        }
    }
}
