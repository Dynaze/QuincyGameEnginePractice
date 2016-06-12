using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
    public class Tile : GameObject
    {
        Texture2D tileSheet;

        public Tile()
        {
            Transform = Vector2.Zero;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent()
        {
            tileSheet = Global.Ref.Content.Load<Texture2D>(Global.pipeline + "Sprites/TileSheet");
        }

        public override void Draw(SpriteBatch sb,GameTime gameTime)
        {
            sb.Draw(tileSheet,Transform,Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            var SPEED = 300f;
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var toMove = Vector2.Zero;
            if(InputHandler.KeyPressed(Keys.Escape))
            {
                Global.Ref.Exit();
            }
            if(InputHandler.KeyDown(Keys.W))
            {
                toMove += Vec2.Up;
            }
            if(InputHandler.KeyDown(Keys.A))
            {
                toMove += Vec2.Left;
            }
            if(InputHandler.KeyDown(Keys.S))
            {
                toMove += Vec2.Down;
            }
            if(InputHandler.KeyDown(Keys.D))
            {
                toMove += Vec2.Right;
            }
            toMove.Normalize();
            Transform += toMove * SPEED * delta;
        }

        public override void UnloadContent()
        {

        }
    }
}
