using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;
using QuincyGameEnginePractice.EngineCode.Ui;

namespace QuincyGameEnginePractice.Scenes
{
	public class BallPitLevel : Scene
	{
		InputHandler input;

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
			PrimeCode = Global.Ref.Content.Load<SpriteFont>(Global.pipeline + "Fonts/PrimeCode");
		}

		public override void Start()
		{
			input = new InputHandler();
			tileMap = new TileMap(ScreenArea);
			world = new World(new Vector2(0f, 9.8f));
			walls = new Wall[2];
			floor = new Floor(world, ScreenArea);
			walls[0] = new Wall(world, ScreenArea, 0);
			walls[1] = new Wall(world, ScreenArea, 2);
			fps = new FPSCounter();
			debugFps = Button.NewButton(font: PrimeCode, width: 200, height: 40, position: Vector2.Zero);
			Block.texture = blockTexture;
			for(int i = 0; i < 10; i++)
				new Block(world);
		}

		public override void Update(GameTime gameTime)
		{
			if(Global.Ref.IsActive)
			{
				debugFps.text.text = ($"FPS: {fps.GetCurrentFPS()}\nGameObjects: {GetComponents.components.Count()}");
				if(InputHandler.KeyPressed(Keys.Escape))
					SceneManager.ChangeScene("MainMenu");
				if(InputHandler.KeyPressed(Keys.R))
					SceneManager.ResetScene();
				if(InputHandler.KeyDown(Keys.Space))
					new Block(world).Start();
				if(InputHandler.MouseLeftClicked())
					new Block(world).Start();
			}
		}

		public override void Draw()
		{
			Clear();
			spriteBatch.Begin(samplerState: SamplerState.PointWrap);
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
			blockTexture.Dispose();
			UnloadStuff();
		}
	}
}
