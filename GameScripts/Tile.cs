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
                toMove += Vector2.Zero.Up();
            }
            if(InputHandler.KeyDown(Keys.A))
            {
                toMove += Vector2.Zero.Left();
            }
            if(InputHandler.KeyDown(Keys.S))
            {
                toMove += Vector2.Zero.Down();
            }
            if(InputHandler.KeyDown(Keys.D))
            {
                toMove += Vector2.Zero.Right();
            }
            Vector2.Normalize(toMove);
            Transform += toMove * SPEED * delta;
        }

        public override void UnloadContent()
        {

        }
    }
}
