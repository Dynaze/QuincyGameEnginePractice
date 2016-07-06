using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using DC = QuincyGameEnginePractice.DisplayConvert;

namespace QuincyGameEnginePractice
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

		SpriteFont primeCode;

		public override void LoadContent()
		{
			if(!Global.Ref.IsMouseVisible)
				Global.Ref.IsMouseVisible = true;
			BackgroundColor = Color.CornflowerBlue;
			primeCode = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");
		}

		public override void Start()
		{
			MAINMENU = Button.NewButton(
				font: primeCode,
				message: "WELCOME TO PHIZZLE",
				width: 400,
				height: 100,
				color: Color.Blue,
				position: new Vector2(-.30f, .8f));
			StartGame = Button.NewButton(
				font: primeCode,
				message: "Start Game!",
				width: 150,
				height: 50,
				color: Color.White,
				position: new Vector2(-.1f, .2f));
			Options = Button.NewButton(
				font: primeCode,
				message: "Options",
				width: 150,
				height: 50,
				color: Color.White,
				position: new Vector2(-.1f, -.2f));
			Quit = Button.NewButton(
				font: primeCode,
				message: "Quit",
				width: 150,
				height: 50,
				color: Color.White,
				position: new Vector2(-.1f, -.6f));
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
			s = new Slime()
			{
				Position = DC.PercentToPixel(new Vector2(-1.04f, 1.1f))
			};
		}
	}
}
