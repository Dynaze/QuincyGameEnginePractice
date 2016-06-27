using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;
using System;

namespace QuincyGameEnginePractice.GameScripts
{
	public class TileMap : GameObject
	{
		Texture2D tileSheet;
		static RenderTarget2D renderTarget;
		Vector2 scale;
		int gridx, gridy;
		Rectangle ScreenArea;

		public TileMap(Rectangle area) : base(true)
		{
			ScreenArea = area;
			gridx = (int)Math.Ceiling((double)ScreenArea.Width / 16);
			gridy = (int)Math.Ceiling((double)ScreenArea.Height / 16);
		}

		public override void Start()
		{
			scale = Vector2.One;
			tileSheet = Global.Ref.Content.Load<Texture2D>("Sprites/TileSheet");
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
			if(renderTarget == null)
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
			//renderTarget.Dispose();
		}
	}
}
