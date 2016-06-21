using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
	public class TileMap : GameObject
	{
		Texture2D tileSheet;
		RenderTarget2D renderTarget;
		Vector2 scale;
		int gridx, gridy;

		public TileMap(int gridx, int gridy) : base(true)
		{
			this.gridx = gridx;
			this.gridy = gridy;
		}

		public override void Start()
		{
			Position = Vector2.Zero;
			scale = new Vector2(1f);
			tileSheet = Global.Ref.Content.Load<Texture2D>(Global.pipeline + "Sprites/TileSheet");
			CreateGrid();
		}

		void CreateGrid()
		{
			var tileList = new List<Tile>();
			for(int y = 0; y < gridy; y++)
			{
				for(int x = 0; x < gridx; x++)
				{
					var position = Vector2.Zero;
					position.X = x * 16 * scale.X;
					position.Y = y * 16 * scale.Y;
					var Rect = Rectangle.Empty;
					Rect.X = Global.random.Next(4) * 16;
					Rect.Y = Global.random.Next(4) * 16;
					Rect.Height = 16;
					Rect.Width = 16;
					var tile = Tile.Empty();
					tile.Transform = position;
					tile.renderRectangle = Rect;
					tileList.Add(tile);
				}
			}
			renderTarget = Texture2DExtentions.CreateOneTextureFromMany(Global.Ref.GraphicsDevice, tileSheet, SceneManager.GetScene(),
				tileList, new Vector2(gridx * 16 * scale.X, gridy * 16 * scale.Y), scale);
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(texture: renderTarget, position: Position, scale: scale, color: Color.White);
		}

		public override void Dispose()
		{
			tileSheet.Dispose();
			renderTarget.Dispose();
		}
	}
}
