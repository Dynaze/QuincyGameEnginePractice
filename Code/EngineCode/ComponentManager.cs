using System.Collections.Generic;

namespace QuincyGameEnginePractice
{
	public class ComponentManager
	{
		public List<IComponent2D> gameObjects { get; }

		public ComponentManager()
		{
			gameObjects = new List<IComponent2D>();
		}

		public int Count()
		{
			return gameObjects.Count;
		}

		public void Insert(IComponent2D o)
		{
			o.Start();
			gameObjects.Add(o);
		}

		public void Add(IComponent2D component)
		{
			gameObjects.Add(component);
		}

		public void Clear()
		{
			gameObjects.Clear();
		}

		public void Remove(IComponent2D component)
		{
			gameObjects.Remove(component);
			component.Dispose();
		}
	}
}
