using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
/// <summary>
/// 
/// </summary>
namespace PongLibrary
{
    public delegate void scoreIncreaseHandler(Paddle p);
    public delegate void BounceHandler();

    public class Paddle
    { 

        //fields
        private int speed;
        private int screenWidth;
        private int screenHeight;
        private Rectangle boundingBox;
        private Ball ball;
        private int score;
        private bool isCPU;
        //properties
        public Rectangle PaddleBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }
        public int Speed
        {
            get;
            set;
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        //events
        public event BounceHandler bounce;
        public event scoreIncreaseHandler scoreUp;

        /// <summary>
        /// handles the bounce event
        /// </summary>
        protected virtual void onBounce()
        {
            bounce?.Invoke();
        }
        /// <summary>
        /// handles the score increase event
        /// </summary>
        protected virtual void OnScoreUp(Paddle p)
        {
            scoreUp?.Invoke(p);
        }

      


        /// <summary>
        /// constructor to instantiate the paddles
        /// </summary>
        /// <param name="paddleWidth">width of the paddle</param>
        /// <param name="paddleHeight">height of the paddle</param>
        /// <param name="screenWidth">width of the screen</param>
        /// <param name="screenHeight">height of the screen</param>
        /// <param name="speed">speed of the paddle</param>
        /// <param name="ball">ball that will bounce off the paddle</param>
        /// <param name="leftSide">if true paddle will be created on the left side of the screen. if false, ball will be created on the right side of the screen</param>
        public Paddle(int paddleWidth, int paddleHeight, int screenWidth, int screenHeight, int speed, Ball ball, bool leftSide,bool isCPU)
        {
            this.speed = speed;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            if (leftSide)
            this.boundingBox = new Rectangle(0, screenHeight / 2 - paddleHeight / 2, paddleWidth, paddleHeight);
            if(!leftSide)
            this.boundingBox = new Rectangle(screenWidth - paddleWidth, screenHeight / 2 - paddleHeight / 2, paddleWidth, paddleHeight);
            this.ball = ball;
            this.isCPU = isCPU;
        }
        public Paddle(int pw, int ph, int sw, int sh, int speed, Ball b,Rectangle padBox)
        {
            this.speed = speed;
            this.screenHeight = sh;
            this.screenWidth = sw;
            this.boundingBox = padBox;
            this.ball = b;
        }

        /// <summary>
        /// moves the paddle up
        /// </summary>
        public void MoveUp()
        {
       
            boundingBox.Y = MathHelper.Clamp(boundingBox.Y -= speed, 0, screenHeight - boundingBox.Height);
            
        }
        public void MoveCPU()
        {
            if (isCPU)
            {
                autoMove();
            }
        }

        /// <summary>
        /// moves the paddle down
        /// </summary>
        public void MoveDown()
        {

            boundingBox.Y = MathHelper.Clamp(boundingBox.Y += speed, 0, screenHeight - boundingBox.Height);
        }
        
        /// <summary>
        /// automatically moves the paddle towards the ball
        /// </summary>
        public void autoMove()
        {       
            if(this.boundingBox.Y > ball.boundingBall.Y)
            {
                MoveUp();
            }
            if(this.boundingBox.Y < ball.boundingBall.Y)
            {
                MoveDown();
            }
        }

        /// <summary>
        /// makes the ball bounce off the paddle
        /// </summary>
        public void ballBounce()
        {
            if (this.boundingBox.Intersects(ball.boundingBall))
            {
                onBounce();
            }
        }


    }//end of paddle Class

    
    

}
