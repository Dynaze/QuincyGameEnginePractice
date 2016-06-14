using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.Scenes
{
	class LevelTwo : BaseScene
	{
		InputHandler input;

		Text fps;

		public LevelTwo(string scene) : base(scene)
		{

		}

		public override void Initialize()
		{
			Global.Ref.IsMouseVisible = true;
			SceneBackgroundColor = Color.Turquoise;
			input = new InputHandler();
			fps = new Text();
			componentManager.Add(fps);
			componentManager.Add(input);
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			if(InputHandler.KeyPressed(Keys.D1))
				SceneManager.ChangeScene<LevelOne>("LevelOne");
			base.Update(gameTime);
		}

		public override void Draw()
		{
			Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
			spriteBatch.Begin();
			base.DrawObjects();
			spriteBatch.End();
			spriteBatch.Begin();
			base.DrawUi();
			spriteBatch.End();
		}

	}
}
