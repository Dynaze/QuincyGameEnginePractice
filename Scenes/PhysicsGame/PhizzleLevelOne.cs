using Microsoft.Xna.Framework;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.EngineCode.Ui;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.Scenes.PhysicsGame
{
	/// <summary>
	/// This is like going to be the main menu for the game, learn how to click on ui elements like buttons
	/// </summary>
	class PhizzleLevelOne : BaseScene
	{
		InputHandler input;

		Button MAINMENU;
		Button StartGame;
		Button Quit;

		Rectangle ScreenArea;

		public PhizzleLevelOne(string scene) : base(scene)
		{

		}

		public override void Initialize()
		{
			//Make sure mous is visible
			if(!Global.Ref.IsMouseVisible)
				Global.Ref.IsMouseVisible = true;
			ScreenArea = new Rectangle(0, 0, Global.Ref.GraphicsDevice.Viewport.Width, Global.Ref.GraphicsDevice.Viewport.Height);
			SceneBackgroundColor = Color.CornflowerBlue;
			input = new InputHandler();
			MAINMENU = Button.NewButton(message: "WELCOME TO PHIZZLE", width: 400, height: 100, color: Color.Red,
				scale: new Vector2(2), position: new Vector2(ScreenArea.Width / 2 - 400, ScreenArea.Height / 2 - 300));
			StartGame = Button.NewButton(message: "Start Game!", width: 150, height: 50, color: Color.White, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2));
			Quit = Button.NewButton(message: "Quit", color: Color.White, width: 150, height: 50, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2 + 200));
			componentManager.Add(input);
			componentManager.Add(MAINMENU);
			componentManager.Add(StartGame);
			componentManager.Add(Quit);
			base.Initialize();
		}

		public override void LoadContent()
		{
			base.LoadContent();
			StartGame.Clicked += () =>
			{
				SceneManager.ChangeScene<LevelOne>("LevelOne");
			};
			Quit.Clicked += () =>
			{
				Global.Ref.Exit();
			};
		}

		public override void Draw()
		{
			Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
			spriteBatch.Begin();
			DrawObjects();
			spriteBatch.End();
			spriteBatch.Begin();
			DrawUi();
			spriteBatch.End();
		}
	}
}
