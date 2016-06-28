using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QEngine.GameScripts;
using QEngine.EngineCode.Interfaces;

namespace QEngine.EngineCode
{
	public static class Texture2DExtentions
	{
		public static RenderTarget2D CreateOneTextureFromMany(GraphicsDevice gd, Texture2D texture, IScene scene, List<Tile> tiles, Vector2 vec, Vector2 scale)
		{
			var render = new RenderTarget2D(gd, (int)vec.X, (int)vec.Y);
			gd.SetRenderTarget(render);
			((Scene)scene).spriteBatch.Begin();
			foreach(var t in tiles)
			{
				((Scene)scene).spriteBatch.Draw(texture: texture, position: t.Transform, sourceRectangle: t.renderRectangle, origin: Vector2.Zero, scale: scale);
			}
			((Scene)scene).spriteBatch.End();
			gd.SetRenderTarget(null);
			//gd.Clear(Color.Transparent);
			return render;
		}

		public static Texture2D ColorTexture2D(int w, int h, Color color)
		{
			var texture = new Texture2D(Global.Ref.GraphicsDevice, w, h);
			Color[] toTexture = new Color[w * h];
			for(int i = 0; i < toTexture.Length; i++)
				toTexture[i] = color;
			texture.SetData(toTexture);
			return texture;
		}

		public static Texture2D createCircleText(int radius)
		{
			Texture2D texture = new Texture2D(Global.Ref.GraphicsDevice, radius, radius);
			Color[] colorData = new Color[radius * radius];

			float diam = radius / 2f;
			float diamsq = diam * diam;

			for(int x = 0; x < radius; x++)
			{
				for(int y = 0; y < radius; y++)
				{
					int index = x * radius + y;
					Vector2 pos = new Vector2(x - diam, y - diam);
					if(pos.LengthSquared() <= diamsq)
					{
						colorData[index] = Color.White;
					}
					else
					{
						colorData[index] = Color.Transparent;
					}
				}
			}

			texture.SetData(colorData);
			return texture;
		}
	}
}
