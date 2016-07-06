using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	public sealed class WidgetFrame : GameObject
	{
		List<IWidget> widgets;

		SpriteFont primeCode;

		public WidgetFrame() : base(true)
		{
			widgets = new List<IWidget>();
			Global.Ref.Window.ClientSizeChanged += OnResize;
			primeCode = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");
		}

		public void Add(IWidget widget)
		{
			widgets.Add(widget);
		}

		public void MoveAll(Vector2 position)
		{
			Position += position;
			foreach(var widget in widgets)
			{
				if(widget is ButtonWidget)
				{
					var w = ((ButtonWidget)widget);
					w.Bounds = new Rectangle(w.Bounds.Location + position.ToPoint(), new Point(w.Bounds.Width, w.Bounds.Height));
				}
			}
		}

		void OnResize(object o, EventArgs e)
		{
			DisplayConvert.ChangeViewport(Global.Ref.GraphicsDevice.Viewport);
			foreach(var widget in widgets)
			{
				widget.OnResize();
			}
		}

		public override void Draw(SpriteBatch sb)
		{
			foreach(var widget in widgets)
			{
				if(widget.IsVisible && widget is ButtonWidget)
				{
					var w = ((ButtonWidget)widget);
					sb.Draw(w.Texture, w.Bounds, Color.White);
					sb.DrawString(primeCode, w.Message, w.Bounds.Location.ToVector2(), Color.Black);
				}
			}
		}

		public override void Dispose()
		{
			Global.Ref.Window.ClientSizeChanged -= OnResize;
			foreach(var widget in widgets)
			{
				widget.OnDestroy();
			}
		}
	}
}
