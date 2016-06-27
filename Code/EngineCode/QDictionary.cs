using System.Collections.Generic;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice
{
	public class QDictionary
	{
		readonly static Dictionary<string, IScene> Scenes = new Dictionary<string, IScene>();

		/// <summary>
		/// adds the scene to the dictionary and also names the scene the same string
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="scene">Scene.</param>
		public static void Add(string name, IScene scene)
		{
			scene.SceneName = name;
			Scenes.Add(name, scene);
		}

		public static IScene ChangeScene(string name)
		{
			return Scenes[name];
		}
	}
}

