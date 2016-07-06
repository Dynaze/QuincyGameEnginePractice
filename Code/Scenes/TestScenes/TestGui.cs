using System;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{
	public class TestGui : Scene
	{
		WidgetFrame frame;

		public override void Start()
		{
			Global.Ref.IsMouseVisible = true;
			frame = new WidgetFrame();
			frame.Add(new ButtonWidget(new Vector2(-1, 0), 100, 50, "Hi!", onClick: () =>
			{
				Console.WriteLine("Hello World!");
			}));
		}

		public override void Update(GameTime gameTime)
		{
			//I dont know how much I like this but its the only way to check if the mouse was clicked
			//each frame to invoke the new gui system with events
			ControlHandle.MouseLeftClicked();
		}
	}
}
