using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QEngine.EngineCode;
using QEngine.GameScripts;
using QEngine.EngineCode.Ui;
using System.Collections;

namespace QEngine.Scenes.TestScenes
{
	public class BallPitLevel : Scene
	{
		TileMap tileMap;

		Wall[] walls;

		Floor floor;

		FPSCounter fps;

		Button debugFps;

		SpriteFont PrimeCode;

		Texture2D blockTexture;

		public override void LoadContent()
		{
			blockTexture = Texture2DExtentions.ColorTexture2D(Global.Ref.GraphicsDevice, 25, 25, Color.GreenYellow);
			BackgroundColor = Color.CornflowerBlue;
			PrimeCode = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");
		}

		public override void Start()
		{
			tileMap = new TileMap(ScreenArea);
			world = new World(new Vector2(0f, 9.8f));
			walls = new Wall[2];
			floor = new Floor(world, ScreenArea);
			walls[0] = new Wall(world, ScreenArea, 0);
			walls[1] = new Wall(world, ScreenArea, 2);
			fps = new FPSCounter();
			debugFps = Button.NewButton(font: PrimeCode, width: 200, height: 40, position: Vector2.Zero);
			for(int i = 0; i < 10; i++) 
			{ var b = new Block(world); }
		}

		public override void Update(GameTime gameTime)
		{
			if(Global.Ref.IsActive)
			{
				debugFps.text.text = ($"FPS: {fps.GetCurrentFPS()}\nGameObjects: {GetComponents.components.Count()}");
				if(ControlHandle.KeyPressed(Keys.Escape))
					SceneManager.ChangeScene("MainMenu");
				if(ControlHandle.KeyPressed(Keys.R))
					SceneManager.ResetScene();
				if(ControlHandle.KeyDown(Keys.Space))
				{
					if(!coroutine.Running)
						coroutine.Start(SpawnBlock(gameTime));
				}
				if(ControlHandle.MouseLeftClicked())
					new Block(world).Start();
			}
		}

		IEnumerator SpawnBlock(GameTime gameTime)
		{
			new Block(world).Start();
			yield return Coroutines.Pause(0.0005f);
		}

		public override void UnloadContent()
		{
			coroutine.StopAll();
			blockTexture.Dispose();
		}
	}
}
