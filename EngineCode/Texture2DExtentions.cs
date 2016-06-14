using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.EngineCode
{
    public static class Texture2DExtentions
    {
        public static RenderTarget2D CreateOneTextureFromMany(GraphicsDevice gd,Texture2D texture,IScene scene,List<Tile> tiles,Vector2 vec, Vector2 scale)
        {
            var render = new RenderTarget2D(gd,(int)vec.X,(int)vec.Y);
            gd.SetRenderTarget(render);
            gd.Clear(Color.Transparent);
            ((BaseScene)scene).spriteBatch.Begin();
            foreach(var t in tiles)
            {
                ((BaseScene)scene).spriteBatch.Draw(texture: texture, position: t.Transform, sourceRectangle: t.renderRectangle, origin: Vector2.Zero, scale: scale);
            }
            ((BaseScene)scene).spriteBatch.End();
            gd.SetRenderTarget(null);
            return render;
        }

        public static Texture2D ColorTexture2D(GraphicsDevice gd, int w, int h, Color color)
        {
            var texture = new Texture2D(gd, w, h);
            Color[] toTexture = new Color[w * h];
            for (int i = 0; i < toTexture.Length; i++)
                toTexture[i] = color;
            texture.SetData(toTexture);
            return texture;
        }
    }
}
