using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	public class Options : Scene
	{
		Button resUp;
		Button resDown;
		Button resolution;
		Button back;
		Button Apply;
		Button toggleFullscreen;

		SpriteFont PrimeCode;

		List<string> resolutions;
		 
		int resOptions = 1;

		int w = 640;
		int h = 480;

		void ResDown()
		{
			resOptions = MathHelper.Clamp(--resOptions, 0, resolutions.Count - 1);
			string[] temp = resolutions[resOptions].Split('x');
			w = int.Parse(temp[0]);
			h = int.Parse(temp[1]);
		}

		void ResUp()
		{
			resOptions = MathHelper.Clamp(++resOptions, 0, resolutions.Count - 1);
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
			resolutions = new List<string>();
			var g = Global.Ref.GraphicsDevice.Adapter.SupportedDisplayModes;
			foreach(var d in g)
			{
				resolutions.Add($"{d.Width}x{d.Height}");
			}
			resDown = Button.NewButton(message: "Resolution down", position: new Vector2(-.8f, .8f), width: 200, height: 80);
			resDown.Clicked += () =>
			{
				ResDown();
				resolution.text.text = $"{w}x{h}";
			};
			resUp = Button.NewButton(message: "Resolution up", position: new Vector2(0, .8f), width: 200, height: 80);
			resUp.Clicked += () =>
			{
				ResUp();
				resolution.text.text = $"{w}x{h}";
			};
			resolution = Button.NewButton(position: new Vector2(-.4f, .8f), width: 200, height: 80);
			resolution.text.text = $"{w}x{h}";
			toggleFullscreen = Button.NewButton(message: "Fullscreen?", position: new Vector2(0, 0), width: 200, height: 80);
			toggleFullscreen.Clicked += () =>
			{
				Global.Ref.graphicsDeviceManager.PreferredBackBufferWidth = w;
				Global.Ref.graphicsDeviceManager.PreferredBackBufferHeight = h;
				Global.Ref.graphicsDeviceManager.ToggleFullScreen();
				Global.Ref.graphicsDeviceManager.ApplyChanges();
			};
			back = Button.NewButton(message: "Back to menu", position: new Vector2(-1f, -.8f), width: 200, height: 80);
			back.Clicked += () => SceneManager.ChangeScene("MainMenu");
			Apply = Button.NewButton(message: "Apply settings\n(Don't apply settings\nthat are higher\nthan your native\nscreen res :[ )", 
				width: 240, height: 120, position: new Vector2(-1, 0));
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
