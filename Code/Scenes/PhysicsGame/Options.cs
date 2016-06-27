using Microsoft.Xna.Framework;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.EngineCode.Ui;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice
{
	public class Options : Scene
	{
		InputHandler input;

		Button resUp;
		Button resDown;
		Button resolution;

		Button toggleFullscreen;

		SpriteFont orangeKid;

		public override void LoadContent()
		{
			spriteBatch = new SpriteBatch(Global.Ref.GraphicsDevice);
			componentManager = new ComponentManager();
			BackgroundColor = Color.Snow;
			orangeKid = Global.Ref.Content.Load<SpriteFont>("Fonts/orangeKid");
			ScreenArea = new Rectangle(0, 0, Global.Ref.GraphicsDevice.Viewport.Width, Global.Ref.GraphicsDevice.Viewport.Height);
		}

		public override void Start()
		{
			input = new InputHandler();
			resDown = Button.NewButton();
			resUp = Button.NewButton();
			resolution = Button.NewButton();
			toggleFullscreen = Button.NewButton();
			componentManager.Add(resDown);
			componentManager.Add(resUp);
			componentManager.Add(resolution);
			componentManager.Add(toggleFullscreen);
		}

		public override void FixedUpdate(GameTime gameTime)
		{
			
		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw()
		{
			Clear();
			spriteBatch.Begin();
			DrawStuff();
			spriteBatch.End();
		}

		public override void DrawUi()
		{
			spriteBatch.Begin();
			DrawUiStuff();
			spriteBatch.End();
		}

		public override void UnloadContent()
		{
			UnloadStuff();
		}
	}
}

