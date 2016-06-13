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

        public virtual void Update(GameTime gameTime)
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
        public virtual void Draw()
        {
            Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
            if (spriteBatch != null)
            {
                spriteBatch.Begin();
                foreach (var o in componentManager.gameComponents)
                {
                    if (o.Visible)
                        o.Draw(spriteBatch);
                }
                spriteBatch.End();
            }
        }

        /// <summary>
        /// alternative draw methods that you can use to draw ui elements to the screen that you wish to follow the camera constantly 
        /// Note: You cant call this by itself because it doesnt have a spritebatch in it
        /// Must call from scene 
        /// </summary>
        public virtual void DrawUi()
        {
            foreach (var o in componentManager.gameComponents)
            {
                o.DrawUi(spriteBatch);
            }
        }

        /// <summary>
        /// if you override the draw method you can use this to just quickly draw all the objects in order,
        /// if you already have another spritebatch working with a camera or something
        /// </summary>
        protected virtual void DrawObjects()
        {
            foreach(var o in componentManager.gameComponents)
            {
                if(o.Visible)
                    o.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// unloads all the memory in the scene if you need to restore memory
        /// </summary>
        public void UnloadContent()
        {
            foreach (var o in componentManager.gameComponents)
            {
                o.UnloadContent();
            }
        }
    }
}
