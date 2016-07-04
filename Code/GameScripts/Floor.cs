using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	class Floor : GameObject
	{
		Texture2D texture;
		Body floor;
		World world;
		Rectangle ScreenArea;
		public int? width, height;

		public Floor(World world) : base(true)
		{
			this.world = world;
			ScreenArea = SceneManager.GetScene().ScreenArea;
		}

		public override void Start()
		{
			if(width == null && height == null)
			{
				width = 2000;
				height = 100;
			}
			texture = Texture2DExtentions.ColorTexture2D(width.Value, height.Value, Color.Red);
			floor = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(texture.Bounds.Width), ConvertUnits.ToSimUnits(texture.Bounds.Height), 1f);
			floor.BodyType = BodyType.Static;
			floor.SetTransform(new Vector2(ScreenArea.Width / 2, ScreenArea.Height - texture.Height / 2).SimUnits(), 0f);
			floor.FixedRotation = true;
			floor.Friction = 10f;
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(texture, floor.Position.DisUnits(), origin: new Vector2(texture.Width, texture.Height) / 2, color: Color.White);
		}

		public override void Dispose()
		{
			floor.Dispose();
			texture.Dispose();
		}
	}
}
