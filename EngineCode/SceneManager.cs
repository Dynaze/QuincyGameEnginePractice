using Microsoft.Xna.Framework;
using QuincyGameEnginePractice.Scenes;
using QuincyGameEnginePractice.Scenes.PhysicsGame;

namespace QuincyGameEnginePractice.EngineCode
{
	/// <summary>
	/// static class that handles all the scenes in the game, right now you have to statically add everything in here for it to be seen as a gamescreen outside of here,
	///  but I want to make this a lot better in the future
	/// </summary>
	static class SceneManager
	{
		static QDictionary Scenes;

		static IScene CurrentScene;

		public static void init()
		{
			Scenes = new QDictionary();
			QDictionary.Add("MainMenu", new PhizzleLevelOne());
			//QDictionary.Add("LevelOne", new PhizzleLevelTwo());
			QDictionary.Add("Test", new BallPitLevel());
			CurrentScene = QDictionary.ChangeScene("MainMenu");
			LoadContent();
			Start();
		}

		public static IScene GetScene()
		{
			return CurrentScene;
		}

		public static void ChangeScene(string scene)
		{
			if(GetScene().SceneName != scene)
			{
				CurrentScene.UnloadContent();
				//Reload the scene
				//http://stackoverflow.com/questions/840261/passing-arguments-to-c-sharp-generic-new-of-templated-type
				//REEEEEFLECTION
				CurrentScene = QDictionary.ChangeScene(scene);// = (T)Activator.CreateInstance(typeof(T));
				LoadContent();
				Start();
			}
		}

		public static void ResetScene()
		{
			UnloadContent();
			LoadContent();
			Start();
		}

		static void LoadContent()
		{
			CurrentScene.LoadContent();
		}

		public static void Update(GameTime gameTime)
		{
			CurrentScene.Update(gameTime);
		}

		static void Start()
		{
			CurrentScene.Start();
		}

		public static void Draw()
		{
			CurrentScene.Draw();
			CurrentScene.DrawUi();
		}

		static void UnloadContent()
		{
			CurrentScene.UnloadContent();
		}

		public static void GlobalUnloadContent()
		{
			UnloadContent();
			Global.Ref.Content.Dispose();
		}
	}
}
