using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	public class SnakeScene : Scene
	{
		SnakeHead snake;

		Fruit fruit;

		public List<Rectangle> grid; 

		public override void LoadContent()
		{
			snake = new SnakeHead();
			fruit = new Fruit();
		}
		
		public override void Start()
		{
			Global.Ref.IsMouseVisible = true;
			SetGrid();
			BackgroundColor = Color.Black;
			fruit.SetSnake(snake);
		}

		public override void Update(GameTime gameTime)
		{
			if(ControlHandle.KeyPressed(Keys.Escape))
			{
				Global.Ref.Exit();
			}
		}

		void SetGrid()
		{
			grid = new List<Rectangle>();
			var x = 0;
			var y = 0;
			const int xx = 64;
			const int yy = 64;
			for (var i = 0; i < 15; ++i)
			{
				for (var ii = 0; ii < 15; ++ii)
				{
					grid.Add(new Rectangle(x, y, xx, yy));
					x += 64;
				}
				x = 0;
				y += 64;
			}
		}
	}
}
