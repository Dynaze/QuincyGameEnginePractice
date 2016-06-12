using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice.EngineCode
{
    public interface IScene
    {
        ComponentManager componentManager { get; set; }
        string SceneName { get; set; }
        void Initialize();
        void LoadContent();
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
        void UnloadContent();
    }
}
