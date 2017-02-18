using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    class ScoreSprite : DrawableGameComponent
    {
        private int score;
        private SpriteFont font;
        private BallSprite ball;
        private PaddleSprite paddle;
        private Game1 game;
        private SpriteBatch spriteBatch;

        


        public ScoreSprite(Game1 game,BallSprite ball,PaddleSprite paddle) : base(game)
        {
            this.game = game;
            this.ball = ball;
            this.paddle = paddle;
            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Your score is: " + score, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
       

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("scoreFont");
            base.LoadContent();
           
            
        }
        private void updateScore(int points)
        {
            score += points;
        }

    }
}
