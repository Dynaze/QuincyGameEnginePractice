using Microsoft.Xna.Framework;
using QEngine.EngineCode;
using QEngine.EngineCode.Ui;
using Microsoft.Xna.Framework.Graphics;
using QEngine.GameScripts;
using Microsoft.Xna.Framework.Input;

namespace QEngine.Scenes.PhysicsGame
{
	public class Options : Scene
	{
		Button resUp;
		Button resDown;
		Button resolution;

		Button toggleFullscreen;

		SpriteFont PrimeCode;

		static string[] resolutions =
		{
			"640x480", "1024x768", "1280x720", "1920x1080"
		};
		 
		void ResDown()
		{
			if(resOptions > 0)
			{
				resOptions--;
				string[] temp = resolutions[resOptions].Split('x');
				w = int.Parse(temp[0]);
				h = int.Parse(temp[1]);
			}
		}

		int resOptions;

		int w;
		int h;

		void ResUp()
		{
			if(resOptions < resolutions.Length)
			{
				string[] temp = resolutions[resOptions].Split('x');
				w = int.Parse(temp[0]);
				h = int.Parse(temp[1]);
				resOptions++;
			}
		}

		public override void LoadContent()
		{
			PrimeCode = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");
			w = Global.Ref.GraphicsDevice.Viewport.Width;
			h = Global.Ref.GraphicsDevice.Viewport.Height;
		}

		public override void Start()
		{
			resDown = Button.NewButton(message: "Resolution down", position: new Vector2(50,50), width: 200, height: 80);
			resDown.Clicked += () =>
			{
				ResDown();
				resolution.text.text = $"{w}x{h}";
			};
			resUp = Button.NewButton(message: "Resolution up", position: new Vector2(650, 50), width: 200, height: 80);
			resUp.Clicked += () =>
			{
				ResUp();
				resolution.text.text = $"{w}x{h}";
			};
			resolution = Button.NewButton(message: "Resolution", position: new Vector2(350, 50), width: 200, height: 80);
			toggleFullscreen = Button.NewButton(message: "Fullscreen?", position: new Vector2(500, 500), width: 200, height: 80);
			toggleFullscreen.Clicked += () =>
			{
				Global.Ref.graphicsDeviceManager.PreferredBackBufferWidth = 1920;
				Global.Ref.graphicsDeviceManager.PreferredBackBufferHeight = 1080;
				Global.Ref.graphicsDeviceManager.ToggleFullScreen();
				//Global.Ref.graphicsDeviceManager.ApplyChanges();
			};
			var back = Button.NewButton(message: "Back to menu", position: new Vector2(0, ScreenArea.Bottom - 80), width: 200, height: 80);
			back.Clicked += () => SceneManager.ChangeScene("MainMenu");
		}

		public override void Update(GameTime gameTime)
		{
			if(ControlHandle.KeyPressed(Keys.Escape))
				SceneManager.ChangeScene("MainMenu");

		}
	}
}
