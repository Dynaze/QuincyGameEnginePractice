using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
    class BaseScene : IScene
    {
        public ComponentManager componentManager { get; set; }
        public string SceneName { get; set; }

        public SpriteBatch spriteBatch;
        public Color SceneBackgroundColor;

        public BaseScene(string name)
        {
            SceneName = name;
            componentManager = new ComponentManager();
        }

        public virtual void Initialize()
        {
            foreach (var o in componentManager.gameComponents)
            {
                o.Initialize();
            }
        }

        public virtual void LoadContent()
        {
            spriteBatch = new SpriteBatch(Global.Ref.GraphicsDevice);
            foreach (var o in componentManager.gameComponents)
            {
                o.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var o in componentManager.gameComponents)
            {
                if(o.Enabled)
                    o.Update(gameTime);
            }
        }

        /// <summary>
        /// Be able to override this function because you will need to mess with both draw and draw ui with the camera in the scene
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Draw(GameTime gameTime)
        {
            Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
            ///TODO Make a way to fix the camera here because its not possible to get to this from the scene without overriding this part 
            if(spriteBatch != null)
                spriteBatch.Begin();
            foreach(var o in componentManager.gameComponents)
            {
                if(o.Visible)
                    o.Draw(spriteBatch);
            }
            if(spriteBatch != null)
                spriteBatch.End();
        }

        protected virtual void DrawObjects(GameTime gameTime)
        {
            foreach(var o in componentManager.gameComponents)
            {
                if(o.Visible)
                    o.Draw(spriteBatch);
            }
        }

        public void UnloadContent()
        {
            foreach (var o in componentManager.gameComponents)
            {
                o.UnloadContent();
            }
        }
    }
}
