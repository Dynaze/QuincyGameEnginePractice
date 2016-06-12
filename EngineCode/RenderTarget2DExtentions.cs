using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.EngineCode
{
    public static class RenderTarget2DExtentions
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
    }
}
