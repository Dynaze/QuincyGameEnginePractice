using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{
	public interface IWidget
	{
		void OnResize();
		Vector2 PercentLocation { get; set; }
		bool IsVisible { get; set; }
	}
}
