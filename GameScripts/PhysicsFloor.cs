using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
    class PhysicsFloor : GameObject
    {
        Texture2D floorTexture;
        Body floor;
        World world;

        public PhysicsFloor(World world)
        {
            this.world = world;
        }

        public override void Initialize()
        {
            base.Initialize();
            floorTexture = new Texture2D(Global.Ref.GraphicsDevice, 300, 100);
            Color[] toTexture = new Color[300*100];
            for (int i = 0; i < toTexture.Length; i++)
                toTexture[i] = Color.Red;
            floorTexture.SetData(toTexture);
            floor = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(floorTexture.Width), ConvertUnits.ToSimUnits(floorTexture.Height),1f);
            floor.BodyType = BodyType.Static;
            floor.Mass = 1.0f;
            floor.Position = ConvertUnits.ToSimUnits(new Vector2(500, 625));
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(floorTexture, new Rectangle((int)ConvertUnits.ToDisplayUnits(floor.Position.X), (int)ConvertUnits.ToDisplayUnits(floor.Position.Y), floorTexture.Width, floorTexture.Height),Color.White);
        }
    }
}
