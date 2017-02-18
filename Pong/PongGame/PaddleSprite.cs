using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    public class PaddleSprite : DrawableGameComponent
    {
        private Paddle paddle;
        private SpriteBatch spriteBatch;
        private Texture2D imagePaddle;
        private Game1 game;
        private BallSprite ball;
        private bool isLeft;
        private bool isCPU;

        //keyboard input
        private KeyboardState oldState;
        private int counter;
        private int threshold;
         
        public Paddle Paddle
        {
            get
            {
                return paddle;
            }
        }
        public BallSprite Ball
        {
            set
            {
                ball = value;
            }
        }




        public PaddleSprite(Game1 game,BallSprite ball,bool isLeft,bool isCPU) : base(game)
        {
            this.game = game;
            this.Ball = ball;
            this.isLeft = isLeft;
            this.isCPU = isCPU;
        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 3;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            paddle.MoveCPU();
            paddle.ballBounce();
            checkInput();
            base.Update(gameTime);

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imagePaddle = game.Content.Load<Texture2D>("paddle");
            paddle = new Paddle(imagePaddle.Width, imagePaddle.Height, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 5, ball.Ball,isLeft,isCPU);
            
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imagePaddle, new Vector2(paddle.PaddleBox.X, paddle.PaddleBox.Y), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void checkInput()
        {
            if (!isCPU)
            {
                KeyboardState newState = Keyboard.GetState();
                oldState = newState;
                if (newState.IsKeyDown(Keys.Up))
                {
                    if (!oldState.IsKeyDown(Keys.Up))
                    {
                        paddle.MoveUp();
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            paddle.MoveUp();
                    }
                }
                if (newState.IsKeyDown(Keys.Down))
                {
                    if (!oldState.IsKeyDown(Keys.Down))
                    {
                        paddle.MoveDown();
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            paddle.MoveDown();
                    }
                }
                if (newState.IsKeyDown(Keys.Space))
                {
                    if (!oldState.IsKeyDown(Keys.Space))
                    {
                        paddle.autoMove();
                        counter = 0;
                    }
                    else
                    {
                        counter++;


                    }
                }
                oldState = newState;
            }
        }
        
    }
}
