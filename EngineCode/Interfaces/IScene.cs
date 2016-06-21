using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
	public interface IScene
	{
		ComponentManager componentManager { get; set; }
		SpriteBatch spriteBatch { get; }
		Color BackgroundColor { get; set; }
		Rectangle ScreenArea { get; set; }
		string SceneName { get; set; }
		void LoadContent();
		void Start();
		void Draw();
		void DrawUi();
		void Update(GameTime gameTime);
		void UnloadContent();
	}
}
