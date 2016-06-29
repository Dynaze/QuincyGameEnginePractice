using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QEngine
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
			"1024x768", "1280x720", "1366x768", "1600x900", "1680x1050","1920x1080", "1920x1200", "2560x1600", "2560x1080", "3840x2160", "4096x2160"
		};
		 
		void ResDown()
		{
			resOptions = MathHelper.Clamp(--resOptions, 0, resolutions.Length - 1);
			string[] temp = resolutions[resOptions].Split('x');
			w = int.Parse(temp[0]);
			h = int.Parse(temp[1]);
		}

		int resOptions = 1;

		int w = 640;
		int h = 480;

		void ResUp()
		{
			resOptions = MathHelper.Clamp(++resOptions, 0, resolutions.Length - 1);
			string[] temp = resolutions[resOptions].Split('x');
			w = int.Parse(temp[0]);
			h = int.Parse(temp[1]);
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
			resolution = Button.NewButton(position: new Vector2(350, 50), width: 200, height: 80);
			resolution.text.text = $"{w}x{h}";
			toggleFullscreen = Button.NewButton(message: "Fullscreen?", position: new Vector2(500, 500), width: 200, height: 80);
			toggleFullscreen.Clicked += () =>
			{
				Global.Ref.graphicsDeviceManager.PreferredBackBufferWidth = w;
				Global.Ref.graphicsDeviceManager.PreferredBackBufferHeight = h;
				Global.Ref.graphicsDeviceManager.ToggleFullScreen();
				Global.Ref.graphicsDeviceManager.ApplyChanges();
			};
			var back = Button.NewButton(message: "Back to menu", position: new Vector2(0, ScreenArea.Bottom - 80), width: 200, height: 80);
			back.Clicked += () => SceneManager.ChangeScene("MainMenu");
			var Apply = Button.NewButton(message: "Apply settings\n(Don't apply settings\nthat are higher\nthan your native\nscreen res :[ )", width: 240, height: 120, position: new Vector2(0, 400));
			Apply.Clicked += () =>
			{
				if(Global.Ref.graphicsDeviceManager.IsFullScreen)
				{
					Global.Ref.graphicsDeviceManager.ToggleFullScreen();
					Global.Ref.graphicsDeviceManager.PreferredBackBufferWidth = w;
					Global.Ref.graphicsDeviceManager.PreferredBackBufferHeight = h;
					Global.Ref.graphicsDeviceManager.ToggleFullScreen();
					Global.Ref.graphicsDeviceManager.ApplyChanges();
				}
				else
				{
					Global.Ref.graphicsDeviceManager.PreferredBackBufferWidth = w;
					Global.Ref.graphicsDeviceManager.PreferredBackBufferHeight = h;
					Global.Ref.graphicsDeviceManager.ApplyChanges();
				}
			};
		}

		public override void Update(GameTime gameTime)
		{
			if(ControlHandle.KeyPressed(Keys.Escape))
				SceneManager.ChangeScene("MainMenu");
		}
	}
}
