using System.Collections.Generic;

namespace QuincyGameEnginePractice.EngineCode
{
    public class ComponentManager
    {
        public List<IQomponent2D> gameComponents { get; }

        public ComponentManager()
        {
            gameComponents = new List<IQomponent2D>();
        }

        public void Add(IQomponent2D component)
        {
            gameComponents.Add(component);
        }

        public void Remove(IQomponent2D component)
        {
            gameComponents.Remove(component);
        }
    }
}
