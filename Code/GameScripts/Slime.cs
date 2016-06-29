using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace QEngine
{
	public class Slime : GameObject
	{
		public Slime() : base(true) { }

		Texture2D slime;

		Animation slimeIdle;

		public override void Start()
		{
			if(slime == null)
				slime = Global.Ref.Content.Load<Texture2D>("Sprites/slime");
			slimeIdle = new Animation();
			var time = TimeSpan.FromSeconds(0.1f);
			for(int i = 0; i < 9; i++)
				slimeIdle.AddFrame(new Rectangle(i * 256, 0, 256, 256), time);
		}

		public override void FixedUpdate(float fixedUpdate)
		{
			slimeIdle.Update(fixedUpdate);
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(slime, sourceRectangle: slimeIdle.CurrentRectangle, scale: Vector2.One, color: Color.White, position: Vector2.Zero);
		}

		public override void Dispose()
		{
			slime.Dispose();
		}
	}
}

