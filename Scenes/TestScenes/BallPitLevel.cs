using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;
using QuincyGameEnginePractice.Scenes.PhysicsGame;

namespace QuincyGameEnginePractice.Scenes
{
	public class BallPitLevel : Scene
	{
		InputHandler input;

		/// <summary>
		/// this shit doesnt work properly
		/// </summary>
		TileMap tileMap;

		List<Block> blocks;

		Wall[] walls;

		Floor floor;

		World world;

		/// <summary>
		/// 0.033333 = 30 times per second
		/// 0.016666 = 60 times per second
		/// 0.008888 = 120 times per second
		/// </summary>
		float fixedUpdate = 0.01666f;

		float toUpdate;

		public override void LoadContent()
		{
			spriteBatch = new SpriteBatch(Global.Ref.GraphicsDevice);
			componentManager = new ComponentManager();
			BackgroundColor = Color.CornflowerBlue;
			ScreenArea = new Rectangle(0, 0, Global.Ref.GraphicsDevice.Viewport.Width, Global.Ref.GraphicsDevice.Viewport.Height);
		}

		public override void Start()
		{
			world = new World(new Vector2(0f, 10f));
			blocks = new List<Block>();
			walls = new Wall[2];
			floor = new Floor(world, ScreenArea);
			walls[0] = new Wall(world, ScreenArea, 0);
			walls[1] = new Wall(world, ScreenArea, 2);
			for(int i = 0; i < 10; i++)
				blocks.Add(new Block(world));
			input = new InputHandler();
			componentManager.Add(input);
			//tileMap = new TileMap(80, 45);
			//componentManager.Add(tileMap);
			foreach(var b in blocks)
				componentManager.Add(b);
			foreach(var w in walls)
				componentManager.Add(w);
			componentManager.Add(floor);
			StartStuff();
		}

		public override void Update(GameTime gameTime)
		{
			if(Global.Ref.IsActive)
			{
				var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
				if(toUpdate > fixedUpdate)
				{
					world.Step(fixedUpdate);
					toUpdate = 0;
				}
				toUpdate += delta;
				if(InputHandler.KeyPressed(Keys.Escape))
					Global.Ref.Exit();
				if(InputHandler.KeyPressed(Keys.D2))
					SceneManager.ChangeScene("MainMenu");
				if(InputHandler.KeyPressed(Keys.R))
					SceneManager.ResetScene();
				if(InputHandler.CurrentMouse.LeftButton == ButtonState.Pressed)
				{
					var b = new Block(world);
					blocks.Add(b);
					componentManager.Insert(b);
				}
				UpdateStuff(gameTime);
			}
		}

		public override void Draw()
		{
			Global.Ref.GraphicsDevice.Clear(BackgroundColor);
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
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
			UnloadStuff();
		}
	}
}
