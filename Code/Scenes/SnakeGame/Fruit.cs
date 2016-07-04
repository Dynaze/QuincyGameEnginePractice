using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	class Fruit : GameObject
	{
		static Texture2D fruit;

		Vector2 fruitPosition;

		Rectangle fruitRect;

		public Rectangle fruitCollision;

		float fruitScale;

		Color color;

		public bool IsEaten;

		SnakeHead snake;

		int w, h;

		public Fruit() : base(true) { }

		public override void Start()
		{
			w = ((SnakeScene)SceneManager.GetScene()).graphics.Viewport.Width;
			h = ((SnakeScene)SceneManager.GetScene()).graphics.Viewport.Height;
			fruitScale = 2f;
			fruit = Texture2DExtentions.ColorTexture2D(32, 32, Color.Red);
			fruitRect = new Rectangle(0, 0, 32, 32);
			color = Color.White;
			IsEaten = true;
		}

		public void SetSnake(SnakeHead snake)
		{
			this.snake = snake;
		}

		public override void Update(GameTime gameTime)
		{
			if (IsEaten)
			{
				var x = Global.random.Next((w / 64) * (h / 64));
				var y = Global.random.Next((w / 64) * (h / 64));
				fruitPosition = new Vector2(x,y);
				fruitCollision.Location = new Point(x, y);
				IsEaten = false;
			}
			if (fruitCollision.Intersects(snake.snakeCollision))
			{
				snake.snakeSpeed -= TimeSpan.FromMilliseconds(10);
				snake.Points++;
				IsEaten = true;
			}
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(fruit, fruitPosition, fruitRect, color, 0f, fruitPosition, fruitScale, SpriteEffects.None, 0);
		}
	}
}
