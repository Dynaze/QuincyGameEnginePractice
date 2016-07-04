using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	public enum SnakeDir
	{
		Up, Down, Left, Right
	}
	class SnakeHead : GameObject
	{
		public int Points;

		static Texture2D snakeHead;

		Rectangle snakeRect;

		public Rectangle snakeCollision;

		public TimeSpan snakeSpeed = TimeSpan.FromMilliseconds(400);

		TimeSpan lastInterval = TimeSpan.Zero;

		public Vector2 snakeHeadPosition;

		SnakeDir lastSnakeDir;

		SnakeDir currentSnakeDir = SnakeDir.Down;

		Color SnakeColor;

		float SnakeSpeed;

		float SnakeScale;

		int windowX;

		int windowY;

		List<Vector2> snakeHistory;

		public SnakeHead() : base(true){}

		public override void Start()
		{
			windowX = ((SnakeScene)SceneManager.GetScene()).graphics.Viewport.Width;
			windowY = ((SnakeScene)SceneManager.GetScene()).graphics.Viewport.Height;
			snakeHead = Texture2DExtentions.ColorTexture2D(32, 32, Color.White);
			SnakeColor = Color.White;
			SnakeScale = 2f;
			snakeRect = new Rectangle(0, 0, 32, 32);
			SnakeSpeed = snakeRect.Width * SnakeScale;
			snakeHeadPosition = new Vector2(snakeRect.Width * SnakeScale / 2, snakeRect.Height * SnakeScale / 2);
			Points = 0;
			snakeHistory = new List<Vector2>();
		}

		public override void Update(GameTime time)
		{
			snakeCollision = new Rectangle(
				(int)(snakeHeadPosition.X - snakeRect.Width), (int)(snakeHeadPosition.Y - snakeRect.Height), 
				(int)(snakeRect.Width * SnakeScale), (int)(snakeRect.Height * SnakeScale));
			if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				currentSnakeDir = SnakeDir.Up;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				currentSnakeDir = SnakeDir.Down;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				currentSnakeDir = SnakeDir.Left;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				currentSnakeDir = SnakeDir.Right;
			}
			if (lastInterval + snakeSpeed < time.TotalGameTime)
			{
				snakeHistory.Insert(0, snakeHeadPosition);
				switch (currentSnakeDir)
				{
					case SnakeDir.Up:
					{
						if (snakeHeadPosition.Y < 32)
						{
							SnakeDed();
						}
						else
						{
							snakeHeadPosition += new Vector2(0, -SnakeSpeed);
						}
						break;
					}
					case SnakeDir.Down:
					{
						if (snakeHeadPosition.Y > windowY)
						{
							SnakeDed();
						}
						else
						{
							snakeHeadPosition += new Vector2(0, SnakeSpeed);
						}
						break;
					}
					case SnakeDir.Left:
					{
						if (snakeHeadPosition.X < 0)
						{
							SnakeDed();
						}
						else
						{
							snakeHeadPosition += new Vector2(-SnakeSpeed, 0);
						}
						break;
					}
					case SnakeDir.Right:
					{
						if (snakeHeadPosition.X  > windowX)
						{
							SnakeDed();
						}
						else
						{
							snakeHeadPosition += new Vector2(SnakeSpeed, 0);
						}
						break;
					}
				}
				lastSnakeDir = currentSnakeDir;
				lastInterval = time.TotalGameTime;
			}
		}

		public override void Draw(SpriteBatch sb)
		{
			for (var i = 0; i < Points; i++)
			{
				sb.Draw(snakeHead, snakeHistory[i], snakeRect, Color.Gray, 0f, snakeRect.Center.ToVector2(), SnakeScale,
					SpriteEffects.None, 0);
			}
			sb.Draw(snakeHead, snakeHeadPosition, snakeRect, SnakeColor, 0f, snakeRect.Center.ToVector2(), SnakeScale, SpriteEffects.None, 0);
		}

		public void SnakeDed()
		{
			snakeSpeed = TimeSpan.FromMilliseconds(400);
			snakeHeadPosition = new Vector2(snakeRect.Width * SnakeScale / 2, snakeRect.Height * SnakeScale / 2);
			Points = 0;
			snakeHistory = new List<Vector2>();
			currentSnakeDir = SnakeDir.Down;
		}

		public override void Dispose()
		{
			snakeHead.Dispose();
		}
	}
}
