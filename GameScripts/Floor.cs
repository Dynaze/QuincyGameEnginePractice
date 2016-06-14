using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
    class Floor : GameObject
    {
        Texture2D texture;
        Body floor;
        World world;
        Rectangle ScreenArea;

        public Floor(World world, Rectangle screen)
        {
            ScreenArea = screen;
            this.world = world;
        }

        public override void Initialize()
        {
            base.Initialize();
            texture = Texture2DExtentions.ColorTexture2D(Global.Ref.GraphicsDevice, ScreenArea.Width,100, Color.Red);
            floor = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(texture.Bounds.Width), ConvertUnits.ToSimUnits(texture.Bounds.Height),1f);
            floor.BodyType = BodyType.Static;
            floor.SetTransform(new Vector2(ScreenArea.Width/2,ScreenArea.Height-texture.Height/2).SimUnits(), 0f);
            floor.FixedRotation = true;
            floor.Friction = 10f;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture: texture, position: floor.Position.DisUnits(), origin: new Vector2(texture.Width,texture.Height)/2,color:Color.White);
        }

        public override void UnloadContent()
        {
            texture.Dispose();
            floor.Dispose();
        }
    }
}
