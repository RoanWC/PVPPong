using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    public delegate void scoreIncreaseHandler(int score);
    
    public class Ball
    {

        private Vector2 speed;
        private int screenWidth;
        private int screenHeight;
        public Rectangle boundingBall;

        public delegate void Handler();
      
        public event Handler GameOver;
        public event scoreIncreaseHandler WallCollision;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="speed">vector containing an x and a y variable to determine the balls speed and direction</param>
        /// <param name="screenWidth">the width of the screen that the ball is bouncing around in</param>
        /// <param name="screenHeight">the height of the screen that the ball is bouncing around in</param>
        /// <param name="ballWidth">the size of the ball to be created</param>
        public Ball(Vector2 speed, int screenWidth, int screenHeight, int ballWidth)
        {
            this.speed = speed;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            boundingBall = new Rectangle(screenWidth / 2 - ballWidth / 2, 0, ballWidth, ballWidth);
        }

 


        /// <summary>
        /// responsoble for raising the game over event
        /// </summary>
        protected virtual void OnGameOver()
        {
            GameOver?.Invoke();
        }

        

        /// <summary>
        /// responsoble for making the ball bounce off the the paddle
        /// </summary>
        public void paddleBounce()
        {
            ySpeed = -ySpeed;
        }

        /// <summary>
        /// responsible for th eballs movement
        /// </summary>
        public void moveBall()
        {
            if (boundingBall.X > 0 && boundingBall.X + boundingBall.Width < screenWidth)
                boundingBall.X += xSpeed;
            else
            {
                OnWallCollision(50);
                xSpeed = -xSpeed;
                boundingBall.X += xSpeed;
            }

            if (!(boundingBall.Y + ySpeed > 0))
            {
                OnWallCollision(50);
                ySpeed = -ySpeed;
            }
            boundingBall.Y += ySpeed;
            if (boundingBall.Y + boundingBall.Height > screenHeight)
            {
                ySpeed = 0;
                xSpeed = 0;
                OnGameOver();
            }
        }



    }
}
