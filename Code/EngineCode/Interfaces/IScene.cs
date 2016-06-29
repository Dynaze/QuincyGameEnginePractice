using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace QEngine
{
	public interface IScene
	{
		World world { get; set; }
		ComponentManager componentManager { get; set; }
		SpriteBatch spriteBatch { get; }
		Color BackgroundColor { get; set; }
		Rectangle ScreenArea { get; set; }
		string SceneName { get; set; }
		void LoadContent();
		void OnLoadContent();
		void Start();
		void OnStart();
		void Draw();
		void OnDraw();
		void DrawUi();
		void OnDrawUi();
		void FixedUpdate(float fixedDelta);
		void Update(GameTime gameTime);
		void OnUpdate(GameTime gameTime);
		void UnloadContent();
		void OnUnloadContent();
	}
}
