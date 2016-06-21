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
		Button Options;
		Button Quit;

		SpriteFont orangeKid;

		public override void LoadContent()
		{
			if(!Global.Ref.IsMouseVisible) Global.Ref.IsMouseVisible = true;
			BackgroundColor = Color.CornflowerBlue;
			orangeKid = Global.Ref.Content.Load<SpriteFont>(Global.pipeline + "Fonts/orangeKid");
		}

		public override void Start()
		{
			input = new InputHandler();
			MAINMENU = Button.NewButton(font: orangeKid, message: "WELCOME TO PHIZZLE", width: 400, height: 100, color: Color.Red, position: new Vector2(ScreenArea.Width / 2 - 200, ScreenArea.Height / 2 - 200));
			StartGame = Button.NewButton(font: orangeKid, message: "Start Game!", width: 150, height: 50, color: Color.White, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2));
			Options = Button.NewButton(font: orangeKid, message: "Options", width: 150, height: 50, color: Color.White, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2 + 100));
			Quit = Button.NewButton(font: orangeKid, message: "Quit", width: 150, height: 50, color: Color.White, position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2 + 200));
			Options.Clicked += () =>
			{
				SceneManager.ChangeScene("Options");
			};
			StartGame.Clicked += () =>
			{
				SceneManager.ChangeScene("Test");
			};
			Quit.Clicked += () =>
			{
				Global.Ref.Exit();
			};
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
