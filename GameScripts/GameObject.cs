using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
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

        Vector2 transform;
        public Vector2 Transform
        {
            get { return transform; }

            set { transform = value; }
        }

        public virtual void Initialize()
        {
            enabled = true;
            visible = true;
        }

        public virtual void LoadContent()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch sb,GameTime gameTime)
        {
            
        }

        public virtual void UnloadContent()
        {
            
        }
    }
}
