using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	public class Slime : GameObject
	{
		public Slime() : base(true) { }

		Texture2D slime;

		CQAnimation slimeIdle;

		public override void Start()
		{
			if(slime == null)
				slime = Global.Ref.Content.Load<Texture2D>("Sprites/slime");
			slimeIdle = new CQAnimation();
			var time = 0.1f;
			for(int i = 0; i < 9; i++)
				slimeIdle.Add(new Rectangle(i * 256, 0, 256, 256), time);
		}

		public override void FixedUpdate(float fixedUpdate)
		{
			slimeIdle.PlayAnimation();
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(slime, position: Position, sourceRectangle: slimeIdle.CurrentFrame, color: Color.White);
		}

		public override void Dispose()
		{
			slime.Dispose();
		}
	}
}

