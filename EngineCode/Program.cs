using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
	public class Program : Game
	{
		[STAThread]
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
				PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
				PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height,
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
