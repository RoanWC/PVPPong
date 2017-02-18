using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PongLibrary;
using Microsoft.Xna.Framework;


namespace PongTests
{
    [TestClass]
    public class PaddleTest
    {
        [TestMethod]
        public void MoveUpEnoughSpace()
        {
            //arrange
            Ball ball = new Ball(new Vector2(3), 100, 100, 5);
            Paddle p1 = new Paddle(5, 20, 100, 100, 5, ball, true,false);
            
            
            //act
            p1.MoveUp();
            //assert
            Assert.AreEqual(35, p1.PaddleBox.Y);



        }
        [TestMethod]
        public void MoveUpNoSpace()
        {
            //arrange
            Ball ball = new Ball(new Vector2(3), 100, 100, 5);
            Paddle p1 = new Paddle(5, 20, 100, 100, 80, ball, true,false);


            //act
            p1.MoveUp();
            //assert
            Assert.AreEqual(0, p1.PaddleBox.Y);

        }
        [TestMethod]
        public void MoveDownEnoughSpace()
        {
            //arrange
            Ball ball = new Ball(new Vector2(3), 100, 100, 5);
            Paddle p1 = new Paddle(5, 20, 100, 100, 5, ball, true,false);


            //act
            p1.MoveDown();
            //assert
            Assert.AreEqual(45, p1.PaddleBox.Y);

        }
        [TestMethod]
        public void MoveDownNoSpace()
        {
            //arrange
            int screenHeight = 100;
            Ball ball = new Ball(new Vector2(3), 100, screenHeight, 5);
            Paddle p1 = new Paddle(5, 20, 100, screenHeight, 80, ball, true,false);


            //act
            p1.MoveDown();
            //assert
            Assert.AreEqual(screenHeight - p1.PaddleBox.Height, p1.PaddleBox.Y);
        }

        [TestMethod]
        
        public void BallBounce()
        {
            //arrange
                Vector2 ballSpeed = new Vector2(3);
                int screenW = 100;
                int screenH = 100;
                int ballW = 10;
                int paddleW = 5;
                int paddleH = 20;
                int padSpeed = 5;
                Rectangle pPos = new Rectangle(0, 10, 10, 20); 

                Ball ball = new Ball(ballSpeed, screenW, screenH, ballW,new Point(0,10));
                Paddle p1 = new Paddle(paddleW, paddleH, screenW, screenH, padSpeed, ball,pPos);


            //act
                

        }
        [TestMethod]
        public void AutoMoveUp()
        {
            //arrange
            Vector2 ballSpeed = new Vector2(3);
            int screenW = 100;
            int screenH = 100;
            int ballW = 10;
            int paddleW = 5;
            int paddleH = 20;
            int padSpeed = 5;

            Ball ball = new Ball(ballSpeed, screenW, screenH, ballW);
            Paddle p1 = new Paddle(paddleW, paddleH, screenW, screenH, padSpeed, ball, true,false);


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
