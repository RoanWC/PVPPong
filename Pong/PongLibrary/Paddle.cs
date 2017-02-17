using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PongLibrary
{
    public class Paddle
    { 
        private int speed;
        private int screenWidth;
        private Rectangle boundingBox;
        private Ball ball;
        
        

       public Paddle(int paddleWidth, int paddleHeight, int screenWidth, int screenHeight, int speed, Ball ball)
        {
            this.speed = speed;
            this.screenWidth = screenWidth;
            this.boundingBox = new Rectangle(screenWidth / 2 - paddleWidth / 2, screenHeight - paddleHeight, paddleWidth, paddleHeight);
            this.ball = ball;
        }

        public Rectangle paddleBox
        {
            get { return boundingBox; }
        }
        public void MoveLeft()
        {
            if(this.boundingBox.X >= 0)
                this.boundingBox.X -= speed;
           if(this.boundingBox.X < 0)
                this.boundingBox.X = 0;
        }
        public void MoveRight()
        {   

            if(this.boundingBox.X + this.boundingBox.Width < screenWidth)
                this.boundingBox.X += speed;
            if (this.boundingBox.X + this.boundingBox.Width > screenWidth)
                this.boundingBox.X = this.boundingBox.X + this.boundingBox.Width;
        }

        public void autoMove()
        {
           
             
            if(this.boundingBox.X > ball.boundingBall.X)
            {
                MoveLeft();
            }
            if(this.boundingBox.X < ball.boundingBall.X)
            {
                MoveRight();
            }
        }


    }//end of paddle Class

    
    

}
