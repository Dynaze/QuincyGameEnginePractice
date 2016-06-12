using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
    /// <summary>
    /// This like like a gameobject in unity that you place in the scene that can be anything from like a player to like ui or something
    /// </summary>
    public interface IQomponent2D
    {
        /// <summary>
        /// all component have a transform in the scene so that we can move them around
        /// </summary>
        Vector2 Transform { get; set; }
        /// <summary>
        /// if true it will be rendered in the object manager
        /// </summary>
        bool Visible { get; set; }
        /// <summary>
        /// if true the update func will be updated in the object manager
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// Where you set up all the variables in the class for the game component
        /// </summary>
        void Initialize();
        /// <summary>
        /// This is where you can load all the textures and stuff for the scene that you will need and then can remove all of them after you are done
        /// </summary>
        void LoadContent();
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
        /// This is where you remove all the textures and stuff to restore memory for other scenes
        /// </summary>
        void UnloadContent();
    }
}
