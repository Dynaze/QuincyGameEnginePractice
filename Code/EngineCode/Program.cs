using System;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{
	public class Program : Game
	{
		[STAThread]
		static void Main(string[] args)
		{
			using(var quincy = new Program())
				quincy.Run();
		}

		public GraphicsDeviceManager graphicsDeviceManager { get; private set; }

		public Program()
		{
			graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = 1280,
				PreferredBackBufferHeight = 720,
				HardwareModeSwitch = true,
				SynchronizeWithVerticalRetrace = true,
				IsFullScreen = false,
				PreferMultiSampling = true,
			};
			IsFixedTimeStep = false;
			Content.RootDirectory = Global.pipeline;
			Global.Ref = this;
		}

		protected override void LoadContent()
		{
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
