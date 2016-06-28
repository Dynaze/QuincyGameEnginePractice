using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QEngine.EngineCode.Interfaces
{
	/// <summary>
	/// This like like a gameobject in unity that you place in the scene that can be anything from like a player to like ui or something
	/// </summary>
	public interface IQomponent2D
	{
		/// <summary>
		/// every object in the game will have a position that does not have to be
		/// </summary>
		/// <value>The transform.</value>
		Vector2 Position { get; set; }
		/// <summary>
		/// will this object get called on the start of the game?
		/// </summary>
		/// <value>The on awake.</value>
		bool IsStart { get; set; }
		/// <summary>
		/// if true it will be rendered in the object manager
		/// </summary>
		bool IsVisible { get; set; }
		/// <summary>
		/// if true the ui gets drawn
		/// </summary>
		bool IsUiVisible { get; set; }
		/// <summary>
		/// sets the order of render for the draw layer
		/// </summary>
		int UiOrder { get; set; }
		/// <summary>
		/// if true the update func will be updated in the object manager
		/// </summary>
		bool IsEnabled { get; set; }
		/// <summary>
		/// the order in which the layers will be rendered to the screen
		/// </summary>
		int DrawOrder { get; set; }
		/// <summary>
		/// Start is where everysingle gameobject will start doing all the logic based stuff after init and load content
		/// so that you dont need to worry about textures not being there for variables needed before textures
		/// </summary>
		void Start();
		/// <summary>
		/// this is where you do animation and physics
		/// </summary>
		/// <returns>The update.</returns>
		void FixedUpdate(float fixedDelta);
		/// <summary>
		/// THis is where you will do all the logic for the object on the scenes
		/// </summary>
		/// <param name="gameTime"></param>
		void Update(GameTime gameTime);
		/// <summary>
		/// This is where you will make all the draw calls for the object in the scene
		/// </summary>
		/// <param name="gameTime"></param>
		void Draw(SpriteBatch sb);
		/// <summary>
		/// Alternative draw method to draw elements that you want to be the user interface and be seen at all times
		/// </summary>
		/// <param name="sb"></param>
		void DrawUi(SpriteBatch sb);
		/// <summary>
		/// This is where you remove all the textures and stuff to restore memory for other scenes
		/// </summary>
		void Dispose();
	}
}
