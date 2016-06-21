using Microsoft.Xna.Framework;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.EngineCode.Ui;
using QuincyGameEnginePractice.GameScripts;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice.Scenes.PhysicsGame
{
	/// <summary>
	/// This is like going to be the main menu for the game, learn how to click on ui elements like buttons
	/// </summary>
	class PhizzleLevelOne : Scene
	{
		InputHandler input;

		Button MAINMENU;
		Button StartGame;
		Button Quit;

		Texture2D wall;

		public override void LoadContent()
		{
			if(!Global.Ref.IsMouseVisible)
				Global.Ref.IsMouseVisible = true;
			BackgroundColor = Color.CornflowerBlue;
			componentManager = new ComponentManager();
			spriteBatch = new SpriteBatch(Global.Ref.GraphicsDevice);
			ScreenArea = new Rectangle(0, 0, Global.Ref.GraphicsDevice.Viewport.Width, Global.Ref.GraphicsDevice.Viewport.Height);
			wall = Texture2DExtentions.ColorTexture2D(Global.Ref.GraphicsDevice, 200, 100, Color.GreenYellow);
		}

		public override void Start()
		{
			input = new InputHandler();
			MAINMENU = Button.NewButton(message: "WELCOME TO PHIZZLE", width: 400, height: 100, color: Color.Red,
				scale: new Vector2(2), position: new Vector2(ScreenArea.Width / 2 - 400, ScreenArea.Height / 2 - 300));
			StartGame = Button.NewButton(message: "Start Game!", width: 150, height: 50, color: Color.White, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2));
			Quit = Button.NewButton(message: "Quit", color: Color.White, width: 150, height: 50, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2 + 200));
			componentManager.Add(input);
			componentManager.Add(MAINMENU);
			componentManager.Add(StartGame);
			componentManager.Add(Quit);
			StartGame.Clicked += () =>
			{
				SceneManager.ChangeScene("Test");
			};
			Quit.Clicked += () =>
			{
				Global.Ref.Exit();
			};
			StartStuff();
		}

		public override void Update(GameTime gameTime)
		{
			UpdateStuff(gameTime);
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
