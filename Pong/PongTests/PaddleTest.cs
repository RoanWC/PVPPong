using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PongLibrary;

namespace PongTests
{
    [TestClass]
    public class PaddleTest
    {
        [TestMethod]
        public void MoveUpEnoughSpace()
        {
            Ball ball = new Ball()
            Paddle p1 = new Paddle(5, 20, 100, 100, 5, ball);
            
        }
        [TestMethod]
        public void MoveUpNoSpace()
        {

        }
        [TestMethod]
        public void MoveDownEnoughSpace()
        {

        }
        [TestMethod]
        public void MoveDownNoSpace()
        {

        }
        [TestMethod]
        public void BallBounce()
        {

        }
        [TestMethod]
        public void AutoMoveUp()
        {

        }

        [TestMethod]
        public void AutoMoveDown()
        {

        }

        [TestMethod]
        public void ConstructorValid()
        {

        }

        [TestMethod]
        public void ConstructorInvalid()
        {

        }


    }
}
