using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	class ButtonWidget : IWidget
	{
		public string Message { get; set; }

		public Rectangle Bounds
		{
			get { return _bounds; }
		}
		Rectangle _bounds;

		/*
		 * http://stackoverflow.com/questions/5363019/defining-c-sharp-events-without-an-external-delegate-definition
		 */
		public event Action OnMouseClicked;

		public Texture2D Texture { get { return texture; } }
		Texture2D texture;

		public ButtonWidget(Vector2 percentLocation, int width, int height, string msg = "", bool visible = true, Action onClick = null)
		{
			_percentLocation = percentLocation;
			_bounds = new Rectangle(DisplayConvert.PercentToPixel(percentLocation).ToPoint(), new Point(width, height));
			Message = msg;
			ControlHandle.OnMouseClicked += MouseClick;
			texture = Texture2DExtentions.ColorTexture2D(width, height, Color.White);
			IsVisible = visible;
			if(onClick != null)
			{
				OnMouseClicked += onClick;
			}
		}

		/// <summary>
		/// Returns a Vector2 between X: -1, 1 and Y: -1, 1
		/// Setting this converts it to pixel coordinates
		/// </summary>
		public Vector2 PercentLocation
		{
			get{return _percentLocation;}
			set
			{
				_percentLocation = value;
				_bounds.Location = DisplayConvert.PercentToPixel(_percentLocation).ToPoint();
			}
		}
		Vector2 _percentLocation;

		public bool IsVisible { get; set; }

		public void OnResize()
		{
			//gets the new graphics viewport from the WidgetFrame and then uses the percent coordinates to put it in the same spot scaled
			_bounds.Location = DisplayConvert.PercentToPixel(PercentLocation).ToPoint();
		}

		void MouseClick()
		{
			if(Bounds.Contains(ControlHandle.CurrentMouse.Position))
				OnMouseClicked?.Invoke();
		}
	}
}
