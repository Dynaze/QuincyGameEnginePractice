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

		public override void LoadContent()
		{
			PrimeCode = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");
		}

		public override void Start()
		{
			resDown = Button.NewButton();
			resUp = Button.NewButton();
			resolution = Button.NewButton();
			toggleFullscreen = Button.NewButton();
		}

		public override void Update(GameTime gameTime)
		{
			if(ControlHandle.KeyPressed(Keys.Escape))
				SceneManager.ChangeScene("MainMenu");
		}
	}
}
