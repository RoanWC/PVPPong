using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongLibrary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class CPUPaddleSprite : DrawableGameComponent
    {
        private CPUPaddle cpuPaddle;
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

        public CPUPaddle CPUPaddle
        {
            get
            {
                return cpuPaddle;
            }
        }
        public BallSprite Ball
        {
            set
            {
                ball = value;
            }
        }




        public CPUPaddleSprite(Game1 game, BallSprite ball, bool isLeft) : base(game)
        {
            this.game = game;
            this.Ball = ball;
            this.isLeft = isLeft;

        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 3;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            cpuPaddle.ballBounce();
            cpuPaddle.MoveCPU();
            checkInput();
            base.Update(gameTime);

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imagePaddle = game.Content.Load<Texture2D>("paddle");
            cpuPaddle = new CPUPaddle(imagePaddle.Width, imagePaddle.Height, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 5, ball.Ball, isLeft);

            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imagePaddle, new Vector2(cpuPaddle.PaddleBox.X, cpuPaddle.PaddleBox.Y), Color.White);
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
                        cpuPaddle.MoveUp();
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            cpuPaddle.MoveUp();
                    }
                }
                if (newState.IsKeyDown(Keys.Down))
                {
                    if (!oldState.IsKeyDown(Keys.Down))
                    {
                        cpuPaddle.MoveDown();
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                        if (counter > threshold)
                            cpuPaddle.MoveDown();
                    }
                }
                if (newState.IsKeyDown(Keys.Space))
                {
                    if (!oldState.IsKeyDown(Keys.Space))
                    {
                        cpuPaddle.autoMove();
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
