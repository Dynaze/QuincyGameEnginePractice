using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	class SpaceScene : Scene
	{
		int remainingPixels;

		public override void LoadContent()
		{
			remainingPixels = graphics.Viewport.Width;
			BackgroundColor = Color.SaddleBrown;
			Global.Ref.IsMouseVisible = true;
		}

		public override void Start()
		{
			while(remainingPixels > 0)
			{
				new Mountain(world, ref remainingPixels);
			}
		}

		public override void Update(GameTime gameTime)
		{
			if(ControlHandle.KeyPressed(Keys.R))
				SceneManager.ResetScene();
		}

		public override void FixedUpdate(float fixedDelta)
		{

		}

		public override void UnloadContent()
		{

		}
	}
}
