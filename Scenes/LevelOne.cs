using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.Scenes
{
    class LevelOne : BaseScene
    {
        InputHandler input;
        TileMap tileMap;

        public LevelOne() : base("LevelOne")
        {
            
        }

        public override void Initialize()
        {
            SceneBackgroundColor = Color.Brown;
            input = new InputHandler();
            tileMap = new TileMap(20,20);
            componentManager.Add(input);
            componentManager.Add(tileMap);
            base.Initialize();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawObjects(gameTime);
            spriteBatch.End();
        }
    }
}
