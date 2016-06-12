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

        int drawOrder;
        public int DrawOrder
        {
            get { return drawOrder; }
            set { drawOrder = value; }
        }

        Vector2 transform;
        public Vector2 Transform
        {
            get { return transform; }

            set { transform = value; }
        }

        public virtual void Initialize()
        {
            drawOrder = 0;
            enabled = true;
            visible = true;
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
