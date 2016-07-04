using System;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{
	/// <summary>
	/// static class that handles all the scenes in the game, right now you have to statically add everything in here for it to be seen as a gamescreen outside of here,
	///  but I want to make this a lot better in the future
	///  FIXED: kinda basically all you need to do is add a new ISCENE to the dictionary like in NewSceneManager
	///  and then you can easily swap between scenes
	///  BUG: if you swap really fucking fast between scenes it like crashes sometimes ;w;
	/// </summary>
	static class SceneManager
	{
		static IScene CurrentScene;

		/// <summary>
		/// call this once to setup a new scenemanager for your instance of the game
		/// </summary>
		/// <returns>The scene manager.</returns>
		public static void NewSceneManager()
		{
			QDictionary.Add("MainMenu", new PhizzleLevelOne());
			QDictionary.Add("Options", new Options());
			QDictionary.Add("Test", new BallPitLevel());
			//QDictionary.Add("Snake", new SnakeScene());\
			QDictionary.Add("Space", new SpaceScene());
			ChangeScene("Space");
		}

		/// <summary>
		/// get the current scene from anywhere
		/// </summary>
		/// <returns>The scene.</returns>
		public static IScene GetScene()
		{
			return CurrentScene;
		}

		/// <summary>
		/// change the current scene to another scene that you have for you levels
		/// resets scene if changing scene to same scene
		/// </summary>
		/// <returns>The scene.</returns>
		/// <param name="scene">Scene.</param>
		public static void ChangeScene(string scene)
		{
			try
			{
				if(CurrentScene == null)
				{
					//dont call unload content because there is nothing to unload
					CurrentScene = QDictionary.ChangeScene(scene);
					LoadContent();
					Start();
				}
				else
				{
					if(GetScene().SceneName != scene)
					{
						CurrentScene.UnloadContent();
						CurrentScene = null;
						//Reload the scene
						//http://stackoverflow.com/questions/840261/passing-arguments-to-c-sharp-generic-new-of-templated-type
						//REEEEEFLECTION
						CurrentScene = QDictionary.ChangeScene(scene);// = (T)Activator.CreateInstance(typeof(T));
						LoadContent();
						Start();
					}
					else
						ResetScene();
				}
			}
			catch(Exception e)
			{
				Console.WriteLine($"Crash at ChangeScene? {e}");
			}
		}

		/// <summary>
		/// resets the current scene
		/// </summary>
		/// <returns>The scene.</returns>
		public static void ResetScene()
		{
			try
			{
				UnloadContent();
				LoadContent();
				Start();
			}
			catch(Exception e)
			{
				Console.WriteLine($"Crash at ResetScene? {e}");
			}
		}

		/// <summary>
		/// calls the scenes loadcontent method that inits componentManager and a spriteBatch
		/// calls the scenes loadcontent class in the base scene Scene.cs
		/// </summary>
		/// <returns>The content.</returns>
		static void LoadContent()
		{
			CurrentScene.OnLoadContent();
		}

		/// <summary>
		/// calls the start function in the scene that starts all the objects in the scene
		/// calls scene start method then calls all the objects Start()
		/// </summary>
		static void Start()
		{
			CurrentScene.OnStart();
		}

		/// <summary>
		/// gets called by xna so you dont need to call this
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public static void Update(GameTime gameTime)
		{
			CurrentScene.OnUpdate(gameTime);
		}

		/// <summary>
		/// gets called by xna so you also dont need to call this
		/// </summary>
		public static void Draw()
		{
			CurrentScene.OnDraw();
			CurrentScene.OnDrawUi();
		}

		/// <summary>
		/// unload all the content in the scene and then can load a new scene into memory
		/// </summary>
		/// <returns>The content.</returns>
		static void UnloadContent()
		{
			CurrentScene.OnUnloadContent();
		}

		/// <summary>
		/// this gets called automatically by xna after everything else is disposed then the game closes
		/// </summary>
		/// <returns>The unload content.</returns>
		public static void GlobalUnloadContent()
		{
			UnloadContent();
			Global.Ref.Content.Dispose();
		}
	}
}
