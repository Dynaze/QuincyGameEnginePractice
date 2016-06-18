using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
	/// <summary>
	/// All components of the game have to inherit this class and the stuff will all be handled automatically
	/// </summary>
	public class GameObject : IQomponent2D
	{
		bool enabled;
		public bool Enabled
		{
			get { return enabled; }
			set { enabled = value; }
		}

		bool visible;
		public bool Visible
		{
			get { return visible; }
			set { visible = value; }
		}

		bool uiVisible;
		public bool UiVisible
		{
			get { return uiVisible; }
			set { uiVisible = value; }
		}

		int drawOrder;
		public int DrawOrder
		{
			get { return drawOrder; }
			set { drawOrder = value; }
		}

		int uiLayer;
		public int UiLayer
		{
			get { return uiLayer; }
			set { uiLayer = value; }
		}

		Vector2 transform;
		public Vector2 Transform
		{
			get { return transform; }
			set { transform = value; }
		}

		public virtual void Initialize()
		{
			Transform = Vector2.Zero;
			DrawOrder = 0;
			UiLayer = 0;
			Enabled = true;
			Visible = true;
			UiVisible = true;
		}

		public virtual void LoadContent()
		{

		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(SpriteBatch sb)
		{

		}

		public virtual void DrawUi(SpriteBatch sb)
		{

		}

		public virtual void UnloadContent()
		{

		}
	}
}
