using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice.Code.Scenes.SpaceGame
{
	class SpawnLocation : GameObject
	{
		public SpawnLocation() : base(true){}

		public Vector2 spawnLocation { get; set; }

		public override void Start()
		{
			int w = ((SpaceScene)SceneManager.GetScene()).graphics.Viewport.Width;
			spawnLocation = new Vector2(Global.random.Next(100, w - 100), 100);
		}
	}
}
