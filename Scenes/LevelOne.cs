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
        Text fps;

        public LevelOne() : base("LevelOne")
        {
            
        }

        public override void Initialize()
        {
            SceneBackgroundColor = Color.CornflowerBlue;
            fps = new Text();
            input = new InputHandler();
            tileMap = new TileMap(80,45);
            componentManager.Add(fps);
            componentManager.Add(input);
            componentManager.Add(tileMap);
            base.Initialize();
        }

        public override void Draw()
        {
            Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawObjects();
            spriteBatch.End();
            spriteBatch.Begin();
            DrawUi();
            spriteBatch.End();
        }
    }
}
