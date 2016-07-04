using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	class SpaceScene : Scene
	{
		int remainingPixels;

        FuelBar bar;

		public override void LoadContent()
		{
            bar = new FuelBar();
            bar.Range = new Vector2(0, 100);
            bar.Value = 0f;
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

		}

		public override void FixedUpdate(float fixedDelta)
		{

		}

		public override void UnloadContent()
		{

		}
	}
}
