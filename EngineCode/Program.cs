using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
    public class Program : Game
    {
        static void Main(string[] args)
        {
            using(var quincy = new Program())
                quincy.Run();
        }

        GraphicsDeviceManager graphicsDeviceManager;
        public Random random;

        public Program()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720
            };
            Init();
        }

        void Init()
        {
            Global.Ref = this;
            random = new Random();
            SceneManager.init();
        }

        protected override void LoadContent()
        {
            SceneManager.ChangeScene(SceneManager.CurrentScene.SceneName);
        }

        protected override void Update(GameTime gameTime)
        {
            SceneManager.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            SceneManager.GlobalUnloadContent();
        }
    }
}
