using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QEngine
{
	/// <summary>
	/// This is like going to be the main menu for the game, learn how to click on ui elements like buttons
	/// </summary>
	class PhizzleLevelOne : Scene
	{
		Button MAINMENU;
		Button StartGame;
		Button Options;
		Button Quit;

		Slime s;

		SpriteFont orangeKid;

		public override void LoadContent()
		{
			if(!Global.Ref.IsMouseVisible)
				Global.Ref.IsMouseVisible = true;
			BackgroundColor = Color.CornflowerBlue;
			orangeKid = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");
		}

		public override void Start()
		{
			MAINMENU = Button.NewButton(
				font: orangeKid,
				message: "WELCOME TO PHIZZLE",
				width: 400,
				height: 100,
				color: Color.Red,
				position: new Vector2(ScreenArea.Width / 2 - 200, ScreenArea.Height / 2 - 200));
			StartGame = Button.NewButton(
				font: orangeKid,
				message: "Start Game!",
				width: 150,
				height: 50,
				color: Color.White,
				position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2));
			Options = Button.NewButton(
				font: orangeKid,
				message: "Options",
				width: 150,
				height: 50,
				color: Color.White,
				position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2 + 100));
			Quit = Button.NewButton(
				font: orangeKid,
				message: "Quit",
				width: 150,
				height: 50,
				color: Color.White,
				position: new Vector2(ScreenArea.Width / 2 - 75, ScreenArea.Height / 2 + 200));
			StartGame.Clicked += () =>
			{
				SceneManager.ChangeScene("Test");
			};
			Options.Clicked += () =>
			{
				SceneManager.ChangeScene("Options");
			};
			Quit.Clicked += () =>
			{
				Global.Ref.Exit();
			};
			s = new Slime();
		}
	}
}
