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
        private int ySpeed;
        private int xSpeed;
        private int screenWidth;
        private int screenHeight;
        public Rectangle boundingBall;
        

        public delegate void Handler();
       

        public event Handler GameOver;
        public event scoreIncreaseHandler WallCollision;




        public Ball(int ySpeed, int xSpeed, int screenWidth, int screenHeight, int ballWidth)
        {
            this.ySpeed = ySpeed;
            this.xSpeed = xSpeed;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            boundingBall = new Rectangle(screenWidth / 2 - ballWidth / 2, 0, ballWidth, ballWidth);
        }
        
        /// <summary>
        /// responsible for raising the game over event
        /// </summary>
        protected virtual void OnGameOver()
        {
            GameOver?.Invoke();
        }

        protected virtual void OnWallCollision(int points)
        {
            WallCollision?.Invoke(points);
        }
        
        public void paddleBounce()
        {
            ySpeed = -ySpeed;
        }

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
