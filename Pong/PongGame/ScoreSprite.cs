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
        private int player1Score;
        private int player2Score;
        private SpriteFont font;
        private BallSprite ball;
        private PaddleSprite paddle;
        private CPUPaddleSprite cpuPaddle;
        private Game1 game;
        private SpriteBatch spriteBatch;

        


        public ScoreSprite(Game1 game,BallSprite ball,PaddleSprite paddle,CPUPaddleSprite cpuPaddle) : base(game)
        {
            this.game = game;
            this.ball = ball;
            this.paddle = paddle;
            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font,"player1: " + player1Score, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font,"player2: " + player2Score, new Vector2(700,0), Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
       

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("scoreFont");
            base.LoadContent();
           
            
        }
        private void updateScore()
        {
            player1Score += 1;
        }

    }
}
