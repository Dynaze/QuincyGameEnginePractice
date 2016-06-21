using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
	public abstract class Scene : IScene
	{
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

		Rectangle _ScreenArea;
		public Rectangle ScreenArea
		{
			get { return _ScreenArea; }
			set { _ScreenArea = value; }
		}

		SpriteBatch _SpriteBatch;
		public SpriteBatch spriteBatch
		{
			get { return _SpriteBatch; }
			set { _SpriteBatch = value; }
		}

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
