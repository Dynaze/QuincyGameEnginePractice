using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using QEngine.GameScripts;
using QEngine.EngineCode.Interfaces;

namespace QEngine.EngineCode
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

		ControlHandle _input;
		public ControlHandle Input
		{
			get { return _input;}
			set { _input = value;}
		}

		public Coroutines coroutine;

		/// <summary>
		/// 0.033333 = 30 times per second
		/// 0.016666 = 60 times per second
		/// *wrong* 0.008888 = 120 times per second *actualy* equals 112 :/
		/// 0.00833333 = 120 times per second
		/// </summary>
		const float fixedUpdate = 0.01666666f;

		float accumlator;

		public virtual void LoadContent()
		{
			
		}

		public void OnLoadContent()
		{
			coroutine = new Coroutines();
			componentManager = new ComponentManager();
			GetComponents.components = _componentManager;
			spriteBatch = new SpriteBatch(Global.Ref.GraphicsDevice);
			ScreenArea = new Rectangle(0, 0, Global.Ref.GraphicsDevice.Viewport.Width, Global.Ref.GraphicsDevice.Viewport.Height);
			BackgroundColor = Color.CornflowerBlue;
			Input = new ControlHandle();
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

		public virtual void Update(GameTime gameTime)
		{
			
		}

		public void OnUpdate(GameTime gameTime)
		{
			var delta = MathHelper.Clamp((float)gameTime.ElapsedGameTime.TotalSeconds, 0f, 0.25f);
			accumlator += delta;
			while(accumlator > fixedUpdate)
			{
				FixedUpdate(fixedUpdate);
				FixedUpdateStuff(fixedUpdate);
				coroutine?.Update();
				world?.Step(fixedUpdate);
				accumlator -= fixedUpdate;
			}
			Update(gameTime);
			UpdateStuff(gameTime);
		}

		protected void FixedUpdateStuff(float FixedDelta)
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsEnabled)
					componentManager.gameObjects[i].FixedUpdate(FixedDelta);
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
