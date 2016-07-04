using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	class Label : GameObject
	{
		Text text;

		public Label() : base(true) { }

		public void SetText(string msg)
		{
			text.text = msg;
		}

		public override void DrawUi(SpriteBatch sb)
		{
			sb.DrawString(text.font, text.text, Position, text.color, text.rotation, text.origin, text.scale, SpriteEffects.None, DrawOrder);
		}

		public static Label CreateLabel(SpriteFont font, string message = null, Color? color = null,
										Vector2? position = null, Vector2? scale = null, Vector2? origin = null,
										float? rotation = null)
		{
			var label = new Label();
			label.text.font = font;
			if(rotation != null)
			{
				label.text.rotation = rotation.Value;
			}
			else
			{
				label.text.rotation = 0f;
			}
			if(!string.IsNullOrEmpty(message))
			{
				label.text.text = message;
			}
			else
			{
				label.text.text = string.Empty;
			}
			if(color != null)
			{
				label.text.color = color.Value;
			}
			else
			{
				label.text.color = Color.White;
			}
			if(scale != null)
			{
				label.text.scale = scale.Value;
			}
			else
			{
				label.text.scale = Vector2.One;
			}
			if(origin != null)
			{
				label.text.origin = origin.Value;
			}
			else
			{
				label.text.origin = Vector2.Zero;
			}
			return label;
		}
	}
}
