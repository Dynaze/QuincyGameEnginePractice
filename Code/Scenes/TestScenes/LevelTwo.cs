using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.Scenes
{
	class LevelTwo : Scene
	{
		InputHandler input;

		Text text;

		public override void LoadContent()
		{

		}

		public override void Start()
		{
			Global.Ref.IsMouseVisible = true;
			BackgroundColor = Color.Turquoise;
			input = new InputHandler();
			componentManager.Add(input);
		}

		public override void FixedUpdate(GameTime gameTime)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			if(InputHandler.KeyPressed(Keys.D1))
				SceneManager.ChangeScene("LevelOne");
		}

		public override void Draw()
		{
			Global.Ref.GraphicsDevice.Clear(BackgroundColor);
			spriteBatch.Begin();
			spriteBatch.End();
			spriteBatch.Begin();
			spriteBatch.End();
		}

		public override void DrawUi()
		{

		}

		public override void UnloadContent()
		{

		}
	}
}
