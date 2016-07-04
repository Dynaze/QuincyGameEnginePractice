using System;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	class Mountain : GameObject
	{
		Body body;

		Texture2D texture;

		int remainingWidth;

		int width;

		int height;

		static bool isFinishSpot = false;

		static bool isFinishSpotThere = false;

		Color color;

		public Mountain(World world, ref int pixelsLeft) : base(true)
		{
			if(isFinishSpot == false)
			{
				int i = Global.random.Next(100);
				if(i > 90)
					isFinishSpot = true;
			}
			height = Global.random.Next(50, 400);
			if(pixelsLeft > 100)
				width = Global.random.Next(50, 100);
			else
			{
				if(isFinishSpot != true)
				{
					isFinishSpot = true;
				}
				width = pixelsLeft;
			}
			pixelsLeft -= width;
			remainingWidth = pixelsLeft;
			body = BodyFactory.CreateRectangle(world, width, height, 10f);
			if(isFinishSpot && !isFinishSpotThere)
			{
				color = Color.DimGray;
				isFinishSpotThere = true;
			}
			else
				color = Color.SandyBrown;
			texture = Texture2DExtentions.ColorTexture2D(width, height, color);
		}

		public override void Start()
		{
			body.BodyType = BodyType.Static;
			body.Position = new Vector2(remainingWidth, Global.Ref.GraphicsDevice.Viewport.Height - height);
		}

		public override void FixedUpdate(float fixedUpdate)
		{

		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(texture, body.Position, Color.White);
		}

		public override void Dispose()
		{
			body.Dispose();
			isFinishSpotThere = false;
			isFinishSpot = false;
		}
	}
}
