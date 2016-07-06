using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	public sealed class WidgetFrame : GameObject
	{
		List<IWidget> widgets;

		public WidgetFrame() : base(true)
		{
			widgets = new List<IWidget>();
			Global.Ref.Window.ClientSizeChanged += OnResize;
		}

		public void Add(IWidget widget)
		{
			widgets.Add(widget);
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
				}
			}
		}
	}
}
