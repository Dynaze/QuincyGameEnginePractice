using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.GameScripts;
using QuincyGameEnginePractice.EngineCode;
using System;

namespace QuincyGameEnginePractice
{
	public class Slime : GameObject
	{
		public Slime() : base(true) { }

		static Texture2D slime;

		Animation slimeIdle;

		public override void Start()
		{
			if(slime == null)
				slime = Global.Ref.Content.Load<Texture2D>("Sprites/slime");
			slimeIdle = new Animation();
			var time = TimeSpan.FromSeconds(0.2f);
			for(int i = 0; i < 9; i++)
				slimeIdle.AddFrame(new Rectangle(i * 256, 0, 256, 256), time);
		}

		public override void Update(GameTime gameTime)
		{
			slimeIdle.Update(gameTime);
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(slime, sourceRectangle: slimeIdle.CurrentRectangle, scale: Vector2.One, color: Color.White, position: Vector2.Zero);
		}

		public override void DrawUi(SpriteBatch sb)
		{

		}

		public override void Dispose()
		{

		}
	}
}

