using System.Collections.Generic;
using QEngine.EngineCode.Interfaces;
namespace QEngine.EngineCode
{
	public class ComponentManager
	{
		public List<IQomponent2D> gameObjects { get; }

		public ComponentManager()
		{
			gameObjects = new List<IQomponent2D>();
		}

		public int Count()
		{
			return gameObjects.Count;
		}

		public void Insert(IQomponent2D o)
		{
			o.Start();
			gameObjects.Add(o);
		}

		public void Add(IQomponent2D component)
		{
			gameObjects.Add(component);
		}

		public void Clear()
		{
			gameObjects.Clear();
		}

		public void Remove(IQomponent2D component)
		{
			gameObjects.Remove(component);
			component.Dispose();
		}
	}
}
