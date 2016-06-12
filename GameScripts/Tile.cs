using Microsoft.Xna.Framework;
namespace QuincyGameEnginePractice.GameScripts
{
    public struct Tile
    {
        public Vector2 Transform;
        public Rectangle renderRectangle;

        public static Tile Empty()
        {
            var tile = new Tile();
            tile.Transform = Vector2.Zero;
            tile.renderRectangle = Rectangle.Empty;
            return tile;
        }
    }
}
