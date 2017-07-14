using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_sharp;

namespace C_sharp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Game g = new Game();
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Game g = new Game();
            Assert.AreEqual(3, g.world.GetLength(0));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Game g = new Game();
            foreach(bool cell in g.world)
            Assert.AreEqual(false, cell);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Game g = new Game();
            g.world[0, 0] = true;
            g.world[1, 1] = true;
            g.Tick();
            foreach (bool cell in g.world)
                Assert.AreEqual(false, cell);

        }

    }
}
