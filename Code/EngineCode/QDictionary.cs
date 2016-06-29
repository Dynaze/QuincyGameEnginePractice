using System.Collections.Generic;

namespace QEngine
{
	public static class QDictionary
	{
		readonly static Dictionary<string, IScene> Scenes = new Dictionary<string, IScene>();

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

