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
    class BallSprite : DrawableGameComponent
    {
        private Ball ball;
        private PaddleSprite pad;

        private SpriteBatch spriteBatch;
        private Texture2D imageBall;
        private Game1 game;

        private int threshold;

        public BallSprite(Game1 game,PaddleSprite pad) : base(game)
        {
            this.game = game;
            this.pad = pad;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imageBall, new Vector2(ball.boundingBall.X, ball.boundingBall.Y), Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public override void Initialize()
        {
            threshold = 3;
            
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imageBall = game.Content.Load<Texture2D>("ball");
            ball = new Ball(threshold, threshold, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, imageBall.Width, pad.paddle);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            ball.moveBall();
            
            base.Update(gameTime);
        }

    }
}
