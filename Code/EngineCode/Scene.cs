using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

using DC = QuincyGameEnginePractice.DisplayConvert;

namespace QuincyGameEnginePractice
{
	public abstract class Scene : IScene
	{
		public string SceneName { get; set; }

		public World world { get; set; }

		public Color BackgroundColor { get; set; }

		public ComponentManager componentManager { get; set; }

		public Rectangle ScreenArea { get; set; }

		public SpriteBatch spriteBatch { get; set; }

		public ControlHandle Input { get; set; }

		public GraphicsDevice graphics { get; set; }

		public Coroutines coroutine { get; set; }

		/// <summary>
		/// 0.033333 = 30 times per second
		/// 0.016666 = 60 times per second
		/// *wrong* 0.008888 = 120 times per second *actualy* equals 112 :/
		/// 0.00833333 = 120 times per second
		/// </summary>
		const float fixedUpdate = 1/60f;

		float accumlator;

		public virtual void LoadContent()
		{
			
		}

		public void OnLoadContent()
		{
			world = new World(new Vector2(0,9.8f));
			graphics = Global.Ref.GraphicsDevice;
			componentManager = new ComponentManager();
			GetComponents.components = componentManager;
			coroutine = new Coroutines();
			spriteBatch = new SpriteBatch(graphics);
			ScreenArea = new Rectangle(0, 0, graphics.Viewport.Width, graphics.Viewport.Height);
			BackgroundColor = Color.CornflowerBlue;
			Input = new ControlHandle();
			DC.ChangeViewport(graphics.Viewport);
			LoadContent();
		}

		public virtual void Start()
		{
			
		}

		public void OnStart()
		{
			Start();
			StartStuff();
		}

		protected void StartStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsStart)
					componentManager.gameObjects[i].Start();
			}
		}

		public virtual void FixedUpdate(float fixedDelta)
		{
			
		}

		protected void FixedUpdateStuff(float FixedDelta)
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsEnabled)
					componentManager.gameObjects[i].FixedUpdate(FixedDelta);
			}
		}

		public virtual void Update(GameTime gameTime)
		{
			
		}

		public void OnUpdate(GameTime gameTime)
		{
			//var delta = MathHelper.Clamp((float)gameTime.ElapsedGameTime.TotalSeconds, 0f, 0.25f);
			accumlator += MathHelper.Clamp((float)gameTime.ElapsedGameTime.TotalSeconds, 0f, 0.25f);//(float)gameTime.ElapsedGameTime.TotalSeconds;
			Update(gameTime);
			UpdateStuff(gameTime);
			while(accumlator >= fixedUpdate)
			{
				FixedUpdate(fixedUpdate);
				FixedUpdateStuff(fixedUpdate);
				if(coroutine.Running)
					coroutine?.Update();
				world?.Step(fixedUpdate);
				accumlator -= fixedUpdate;
			}
		}

		protected void UpdateStuff(GameTime gameTime)
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsEnabled)
					componentManager.gameObjects[i].Update(gameTime);
			}
		}

		public virtual void Draw()
		{
			Clear();
			spriteBatch.Begin();
			DrawStuff();
			spriteBatch.End();
		}

		public void OnDraw()
		{
			Draw();
		}

		protected void DrawStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsVisible)
					componentManager.gameObjects[i].Draw(spriteBatch);
			}
		}

		public virtual void DrawUi()
		{
			spriteBatch.Begin();
			DrawUiStuff();
			spriteBatch.End();
		}

		public void OnDrawUi()
		{
			DrawUi();
		}

		protected void DrawUiStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsUiVisible)
					componentManager.gameObjects[i].DrawUi(spriteBatch);
			}
		}

		public virtual void UnloadContent()
		{
			
		}

		public void OnUnloadContent()
		{
			UnloadContent();
			UnloadStuff();
			Global.Ref.Content.Dispose();
			Global.Ref.Content = new Microsoft.Xna.Framework.Content.ContentManager(Global.Ref.Services, Global.pipeline);
		}

		protected void UnloadStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				componentManager.gameObjects[i].Dispose();
			}
		}

		public void Clear()
		{
			graphics.Clear(BackgroundColor);
		}
	}
}
