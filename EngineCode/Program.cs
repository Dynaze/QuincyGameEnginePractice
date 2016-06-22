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

		public Program()
		{
			graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width
				//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
				PreferredBackBufferWidth = 1920,
				PreferredBackBufferHeight = 1080,
				SynchronizeWithVerticalRetrace = false,
				IsFullScreen = true,
				PreferMultiSampling = true,
			};
		}

		protected override void LoadContent()
		{
			IsFixedTimeStep = false;
			Global.Ref = this;
			SceneManager.NewSceneManager();
		}

		protected override void Update(GameTime gameTime)
		{
			SceneManager.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			SceneManager.Draw();
		}

		protected override void UnloadContent()
		{
			SceneManager.GlobalUnloadContent();
		}
	}
}
