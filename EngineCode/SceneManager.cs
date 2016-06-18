using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using QuincyGameEnginePractice.Scenes;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.Scenes.PhysicsGame;

namespace QuincyGameEnginePractice.EngineCode
{
	static class SceneManager
	{
		static Dictionary<string, IScene> Scenes;

		static IScene CurrentScene;

		static PhizzleLevelOne Menu;

		static LevelOne levelOne;

		public static void init()
		{
			Scenes = new Dictionary<string, IScene>();
			Menu = new PhizzleLevelOne("MainMenu");
			levelOne = new LevelOne("LevelOne");
			Scenes.Add(Menu.SceneName, Menu);
			Scenes.Add(levelOne.SceneName, levelOne);
			CurrentScene = Scenes[Menu.SceneName];
			Initialize();
			LoadContent();
		}

		public static IScene GetScene()
		{
			return CurrentScene;
		}

		public static void ChangeScene<T>(string scene) where T : IScene
		{
			if(GetScene().SceneName != scene)
			{
				CurrentScene.UnloadContent();
				//Reload the scene
				//http://stackoverflow.com/questions/840261/passing-arguments-to-c-sharp-generic-new-of-templated-type
				//REEEEEFLECTION
				Scenes[scene] = (T)Activator.CreateInstance(typeof(T), scene);
				CurrentScene = Scenes[scene];
				Initialize();
				LoadContent();
			}
		}

		static void Initialize()
		{
			CurrentScene.Initialize();
		}

		static void LoadContent()
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

		static void UnloadContent()
		{
			CurrentScene.UnloadContent();
		}

		public static void GlobalUnloadContent()
		{
			Global.Ref.Content.Dispose();
		}
	}
}
