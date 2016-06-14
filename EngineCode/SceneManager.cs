using System;
using QuincyGameEnginePractice.Scenes;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice.EngineCode
{
    class SceneManager
    {
        static Dictionary<string,IScene> Scenes;

        static IScene CurrentScene;

        static LevelOne levelOne;

        static LevelTwo levelTwo;

        public static void init()
        {
            Scenes = new Dictionary<string, IScene>();
            levelOne = new LevelOne("LevelOne");
            levelTwo = new LevelTwo("LevelTwo");
            Scenes.Add(levelOne.SceneName, levelOne);
            Scenes.Add(levelTwo.SceneName, levelTwo);
            CurrentScene = Scenes[levelOne.SceneName];
            Initialize();
            LoadContent();
        }

        public static IScene GetScene()
        {
            return CurrentScene;
        }

        public static void ChangeScene<T>(string scene ) where T : IScene
        {
            if (GetScene().SceneName != scene)
            {
                CurrentScene.UnloadContent();
                //Reload the scene
                //http://stackoverflow.com/questions/840261/passing-arguments-to-c-sharp-generic-new-of-templated-type
                //REEEEEFLECTION
                Scenes[scene] = (T) Activator.CreateInstance(typeof(T), scene);
                CurrentScene = Scenes[scene];
                Initialize();
                LoadContent();
            }
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
