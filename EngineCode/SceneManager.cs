using QuincyGameEnginePractice.Scenes;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice.EngineCode
{
    class SceneManager
    {
        public static Dictionary<string,IScene> Scenes;

        public static IScene CurrentScene;

        public static LevelOne levelOne;

        public static void init()
        {
            Scenes = new Dictionary<string, IScene>();
            levelOne = new LevelOne();
            Scenes.Add(levelOne.SceneName, levelOne);
            CurrentScene = Scenes[levelOne.SceneName];
        }

        public static IScene GetScene()
        {
            return CurrentScene;
        }

        public static void ChangeScene(string scene)
        {
            CurrentScene.UnloadContent();
            CurrentScene = Scenes[scene];
            Initialize();
            LoadContent();
        }

        protected static void Initialize()
        {
            CurrentScene.Initialize();
        }

        protected static void LoadContent()
        {
            CurrentScene.LoadContent();
        }

        public static void Update(GameTime gameTime)
        {
            CurrentScene.Update(gameTime);
        }

        public static void Draw(GameTime gameTime)
        {
            CurrentScene.Draw(gameTime);
        }

        protected static void UnloadContent()
        {
            CurrentScene.UnloadContent();
        }

        public static void GlobalUnloadContent()
        {
            Global.Ref.Content.Dispose();
        }
    }
}
