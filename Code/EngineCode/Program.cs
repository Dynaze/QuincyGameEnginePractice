using System;
using Microsoft.Xna.Framework;

namespace QEngine
{
	public class Program : Game
	{
		[STAThread]
		static void Main(string[] args)
		{
			using(var quincy = new Program())
				quincy.Run();
		}

		public GraphicsDeviceManager graphicsDeviceManager;

		public Program()
		{
			graphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width
				//GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
				PreferredBackBufferWidth = 1280,
				PreferredBackBufferHeight = 720,
				HardwareModeSwitch = true,
				SynchronizeWithVerticalRetrace = false,
				IsFullScreen = false,
				PreferMultiSampling = true,
			};
			graphicsDeviceManager.ApplyChanges();
		}

		protected override void LoadContent()
		{
			Content.RootDirectory = Global.pipeline;
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
