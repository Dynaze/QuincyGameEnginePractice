using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
	/// <summary>
	/// All components of the game have to inherit this class and the stuff will all be handled automatically
	/// </summary>
	public abstract class GameObject : IQomponent2D
	{
		bool awake;
		public bool IsStart
		{
			get { return awake; }
			set { awake = value; }
		}

		bool enabled;
		public bool IsEnabled
		{
			get { return enabled; }
			set { enabled = value; }
		}

		bool visible;
		public bool IsVisible
		{
			get { return visible; }
			set { visible = value; }
		}

		bool uiVisible;
		public bool IsUiVisible
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
		public int UiOrder
		{
			get { return uiLayer; }
			set { uiLayer = value; }
		}

		Vector2 position;
		public Vector2 Position
		{
			get { return position; }
			set { position = value; }
		}

		public GameObject(bool defaultStart)
		{
			if(defaultStart)
			{
				Position = Vector2.Zero;
				DrawOrder = 0;
				UiOrder = 0;
				IsEnabled = true;
				IsVisible = true;
				IsUiVisible = true;
				IsStart = true;
				Add(this);
			}
		}

		public static void Add(IQomponent2D thing)
		{
			GetComponents.components.Add(thing);
		}

		public virtual void Start()
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

		public virtual void Dispose()
		{

		}
	}
}
