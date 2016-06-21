using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
	public abstract class Scene : IScene
	{
		Color _BackgroundColor;
		public Color BackgroundColor
		{
			get
			{
				return _BackgroundColor;
			}

			set
			{
				_BackgroundColor = value;
			}
		}

		ComponentManager _compoentManager;
		public ComponentManager componentManager
		{
			get { return _compoentManager; }
			set { _compoentManager = value; }
		}

		string _SceneName;
		public string SceneName
		{
			get
			{
				return _SceneName;
			}

			set
			{
				_SceneName = value;
			}
		}

		Rectangle _ScreenArea;
		public Rectangle ScreenArea
		{
			get
			{
				return _ScreenArea;
			}

			set
			{
				_ScreenArea = value;
			}
		}

		SpriteBatch _SpriteBatch;
		public SpriteBatch spriteBatch
		{
			get
			{
				return _SpriteBatch;
			}
			set
			{
				_SpriteBatch = value;
			}
		}

		public abstract void LoadContent();

		public abstract void Start();

		protected void StartStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsStart)
					componentManager.gameObjects[i].Start();
			}
		}

		public abstract void Update(GameTime gameTime);

		protected void UpdateStuff(GameTime gameTime)
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsEnabled)
					componentManager.gameObjects[i].Update(gameTime);
			}
		}

		public abstract void Draw();

		protected void DrawStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsVisible)
					componentManager.gameObjects[i].Draw(spriteBatch);
			}
		}

		public abstract void DrawUi();

		protected void DrawUiStuff()
		{
			for(int i = 0; i < componentManager.Count(); i++)
			{
				if(componentManager.gameObjects[i].IsUiVisible)
					componentManager.gameObjects[i].DrawUi(spriteBatch);
			}
		}

		public abstract void UnloadContent();

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
