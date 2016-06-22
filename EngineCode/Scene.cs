using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace QuincyGameEnginePractice.EngineCode
{
	public abstract class Scene : IScene
	{
		World _world;
		public World world
		{
			get { return _world; }
			set { _world = value; }
		}

		Color _BackgroundColor;
		public Color BackgroundColor
		{
			get { return _BackgroundColor; }
			set { _BackgroundColor = value; }
		}

		ComponentManager _componentManager;
		public ComponentManager componentManager
		{
			get { return _componentManager; }
			set { _componentManager = value; }
		}

		string _SceneName;
		public string SceneName
		{
			get { return _SceneName; }
			set { _SceneName = value; }
		}

		Rectangle _screenArea;
		public Rectangle ScreenArea
		{
			get { return _screenArea; }
			set { _screenArea = value; }
		}

		SpriteBatch _spriteBatch;
		public SpriteBatch spriteBatch
		{
			get { return _spriteBatch; }
			set { _spriteBatch = value; }
		}

		/// <summary>
		/// 0.033333 = 30 times per second
		/// 0.016666 = 60 times per second
		/// 0.008888 = 120 times per second
		/// </summary>
		const float fixedUpdate = 0.016666f;

		float accumlator;

		float toUpdate;

		public abstract void LoadContent();

		public void OnLoadContent()
		{
			componentManager = new ComponentManager();
			GetComponents.components = _componentManager;
			spriteBatch = new SpriteBatch(Global.Ref.GraphicsDevice);
			ScreenArea = new Rectangle(0, 0, Global.Ref.GraphicsDevice.Viewport.Width, Global.Ref.GraphicsDevice.Viewport.Height);
			BackgroundColor = Color.CornflowerBlue;
			LoadContent();
		}

		public abstract void Start();

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

		public abstract void Update(GameTime gameTime);

		public void OnUpdate(GameTime gameTime)
		{
			Update(gameTime);
			UpdateStuff(gameTime);
			if(world != null)
			{
				if(toUpdate > fixedUpdate)
				{
					world.Step(fixedUpdate);
					//accumlator -= fixedUpdate;
					toUpdate = 0;
				}
			}
			toUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
		}

		protected void UpdateStuff(GameTime gameTime)
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsEnabled)
					componentManager.gameObjects[i].Update(gameTime);
			}
		}

		public abstract void Draw();

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

		public abstract void DrawUi();

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

		public abstract void UnloadContent();

		public void OnUnloadContent()
		{
			UnloadContent();
			UnloadStuff();
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
			Global.Ref.GraphicsDevice.Clear(BackgroundColor);
		}
	}
}
