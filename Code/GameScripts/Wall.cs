using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	class Wall : GameObject
	{
		Texture2D texture;
		Body floor;
		World world;
		Rectangle ScreenArea;
		int side;

		public Wall(World world, int side) : base(true)
		{
			ScreenArea = SceneManager.GetScene().ScreenArea;
			this.world = world;
			this.side = side;
		}

		public override void Start()
		{
			texture = Texture2DExtentions.ColorTexture2D(100, ScreenArea.Height, Color.Red);
			floor = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(texture.Bounds.Width), ConvertUnits.ToSimUnits(texture.Bounds.Height), 1f);
			floor.BodyType = BodyType.Static;
			if(side < 1)
				floor.SetTransform(new Vector2(ScreenArea.X + texture.Width / 2, texture.Height / 2).SimUnits(), 0f);
			if(side > 1)
				floor.SetTransform(new Vector2(ScreenArea.Width - texture.Width / 2, texture.Height / 2).SimUnits(), 0f);
			floor.FixedRotation = true;
			floor.Mass = 1.0f;
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(texture, floor.Position.DisUnits(), origin: new Vector2(texture.Width, texture.Height) / 2, color: Color.White);
		}

		public override void Dispose()
		{
			texture.Dispose();
			floor.Dispose();
		}
	}
}
