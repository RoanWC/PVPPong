using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{



    public class Ball
    {
        //variable declarations
        private Vector2 speed;
        private int screenWidth;
        private int screenHeight;
        public Rectangle boundingBall;
        //Properties
        public Vector2 Speed
        {
            get;
            set;
        }
        //events
        public event scoreIncreaseHandler gameOverLeft;
        public event scoreIncreaseHandler gameOverRight;


        

        

        

        /// <summary>
        /// constructor
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

        public Ball(Vector2 speed, int screenW, int screenH, int ballWidth, Point position)
        {
            this.speed = speed;
            this.screenWidth = screenW;
            this.screenHeight = screenH;
            boundingBall = new Rectangle(position, new Point(ballWidth));
        }
        
        
        
        /// <summary>
        /// add to the bounce event delegate
        /// </summary>
        public void paddleBounce()
        {
            speed.X = -speed.X;
        }
        /// <summary>
        /// responsible for the balls movement
        /// </summary>
        public void moveBall()
        {
            boundingBall.X = MathHelper.Clamp(boundingBall.X += (int)speed.X, 0, screenWidth - boundingBall.Width);
            boundingBall.Y = MathHelper.Clamp(boundingBall.Y += (int)speed.Y, 0, screenHeight - boundingBall.Height);
            if (boundingBall.X == 0)
            { 
                speed.X = -speed.X;
                //boundingBall.X = MathHelper.Clamp(boundingBall.X += (int)speed.X, 0, screenWidth - boundingBall.Width);
            }
            if (boundingBall.X == screenWidth - boundingBall.Width)
            {
                speed.X = -speed.X;
                //boundingBall.X = MathHelper.Clamp(boundingBall.X += (int)speed.X, 0, screenWidth - boundingBall.Width);
            }
            if (boundingBall.Y == 0 || boundingBall.Y == screenHeight - boundingBall.Width)
            {
                //boundingBall.Y = MathHelper.Clamp(boundingBall.Y += (int)speed.Y, 0, screenHeight - boundingBall.Height);
                speed.Y = -speed.Y;
            }
        }




    }
}
