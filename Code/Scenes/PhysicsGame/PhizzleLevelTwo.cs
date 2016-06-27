using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;
using QuincyGameEnginePractice.EngineCode.Ui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.Scenes.PhysicsGame
{
	class PhizzleLevelTwo : Scene
	{
		World world;

		InputHandler input;

		List<Block> blocks;

		Floor floor;

		Label label;

		FPSCounter fpsCounter;

		SpriteFont orangeKid;

		public override void LoadContent()
		{
			orangeKid = Global.Ref.Content.Load<SpriteFont>("Fonts/orangeKid");
		}

		public override void Start()
		{
			BackgroundColor = Color.Turquoise;
			input = new InputHandler();
			world = new World(new Vector2(0f, 10f));
			blocks = new List<Block>();
			floor = new Floor(world, ScreenArea);
			floor.width = 500;
			floor.height = 100;
			fpsCounter = new FPSCounter();
			label = Label.CreateLabel(orangeKid, scale: new Vector2(2), color: Color.Black);
			componentManager.Add(input);
			componentManager.Add(floor);
			componentManager.Add(fpsCounter);
			componentManager.Add(label);
			StartStuff();
		}

		public override void FixedUpdate(GameTime gameTime)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			if(InputHandler.KeyPressed(Keys.Escape))
				Global.Ref.Exit();
			UpdateStuff(gameTime);
		}

		public override void Draw()
		{
			Clear();
			spriteBatch.Begin();
			DrawStuff();
			spriteBatch.End();
		}

		public override void DrawUi()
		{
			spriteBatch.Begin();
			DrawUiStuff();
			spriteBatch.End();
		}

		public override void UnloadContent()
		{

		}
	}
}
