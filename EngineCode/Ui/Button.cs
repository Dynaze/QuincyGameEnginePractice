﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.EngineCode.Ui
{
	class Button : GameObject
	{
		public Texture2D buttonTexture;
		public Text text;
		public Color color;
		public Rectangle bounds;
		public Vector2 scale;
		public Vector2 origin;
		public int width;
		public int height;
		public float rotation;

		//https://www.youtube.com/watch?v=jQgwEsJISy0
		public delegate void ClickEventHandler();
		public event ClickEventHandler Clicked;

		public Button() : base(true) { }

		public override void Start()
		{
			text.font = Global.Ref.Content.Load<SpriteFont>(Global.pipeline + "Fonts/orangeKid");
			text.color = Color.Black;
		}

		public override void Update(GameTime gameTime)
		{
			if(InputHandler.MouseLeftClicked() && bounds.Contains(InputHandler.CurrentMouse.Position))
			{
				Clicked?.Invoke();
			}
		}

		public override void DrawUi(SpriteBatch sb)
		{
			sb.Draw(texture: buttonTexture, position: bounds.Location.ToVector2(), color: color, scale: scale, rotation: rotation, origin: origin);
			sb.DrawString(text.font, text.text, bounds.Location.ToVector2(), text.color, rotation, text.origin, scale, SpriteEffects.None, 0);
		}

		public override void Dispose()
		{
			buttonTexture.Dispose();
		}


		public static Button NewButton(Texture2D texture = null, string message = null, Color? color = null,
										Vector2? position = null, Vector2? scale = null, Vector2? origin = null,
										int? width = null, int? height = null, float? rotation = null)
		{
			var button = new Button();
			if(width != null && height != null && position != null)
			{
				button.bounds = new Rectangle((int)position.Value.X, (int)position.Value.Y, width.Value, height.Value);
			}
			else
			{
				if(width != null)
				{
					button.width = width.Value;
				}
				else
				{
					button.width = 100;
				}
				if(height != null)
				{
					button.height = height.Value;
				}
				else
				{
					button.height = 100;
				}
				if(position != null)
				{
					button.Position = position.Value;
				}
				else
				{
					button.Position = Vector2.Zero;
				}
			}
			if(rotation != null)
			{
				button.rotation = rotation.Value;
			}
			else
			{
				button.rotation = 0f;
			}
			if(!string.IsNullOrEmpty(message))
			{
				button.text.text = message;
			}
			else
			{
				button.text.text = string.Empty;
			}
			if(color != null)
			{
				button.color = color.Value;
			}
			else
			{
				button.color = Color.White;
			}
			if(scale != null)
			{
				button.scale = scale.Value;
			}
			else
			{
				button.scale = Vector2.One;
			}
			if(texture != null)
			{
				button.buttonTexture = texture;
			}
			else
			{
				if(width != null && height != null && color != null)
				{
					button.buttonTexture = Texture2DExtentions.ColorTexture2D(Global.Ref.GraphicsDevice, width.Value, height.Value, color.Value);
				}
				else
					button.buttonTexture = Texture2DExtentions.ColorTexture2D(Global.Ref.GraphicsDevice, 100, 100, Color.White);
			}
			if(origin != null)
			{
				button.origin = origin.Value;
			}
			else
			{
				button.origin = Vector2.Zero;
			}
			return button;
		}
	}
}