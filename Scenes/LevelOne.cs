using Microsoft.Xna.Framework;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.Scenes
{
    class LevelOne : BaseScene
    {
        InputHandler input;
        Tile oneTile;

        public LevelOne() : base("LevelOne")
        {
            init();
        }

        void init()
        {
            SceneBackgroundColor = Color.Brown;
            input = new InputHandler();
            oneTile = new Tile();
            componentManager.Add(input);
            componentManager.Add(oneTile);
        }

        public override void Draw(GameTime gameTime)
        {
            Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
            spriteBatch.Begin();
            DrawObjects(gameTime);
            spriteBatch.End();
        }
    }
}
