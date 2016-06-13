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

        public static LevelOne levelTwo;

        public static void init()
        {
            Scenes = new Dictionary<string, IScene>();
            levelOne = new LevelOne("LevelOne");
            levelTwo = new LevelOne("LevelTwo");
            Scenes.Add(levelOne.SceneName, levelOne);
            Scenes.Add(levelTwo.SceneName, levelTwo);
            CurrentScene = Scenes[levelOne.SceneName];
        }

        public static IScene GetScene()
        {
            return CurrentScene;
        }

        public static void ChangeScene(string scene)
        {
            CurrentScene.UnloadContent();
            //Reload the scene
            Scenes[scene] = new LevelOne(scene);
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

        public static void Draw()
        {
            CurrentScene.Draw();
        }

        public static void DrawUi()
        {
            CurrentScene.DrawUi();
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
