using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
    class PhysicsBlock : GameObject
    {
        Texture2D block;
        Body body;
        World world;

        public PhysicsBlock(World world)
        {
            this.world = world;
        }

        public override void Initialize()
        {
            base.Initialize();
            Color[] toBlock = new Color[100*100];
            for (int i = 0; i < toBlock.Length; i++)
                toBlock[i] = Color.GreenYellow;
            block = new Texture2D(Global.Ref.GraphicsDevice, 100,100);
            block.SetData(toBlock);
            body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(block.Width), ConvertUnits.ToSimUnits(block.Height), 1.0f);
            body.Mass = 1f;
            body.BodyType = BodyType.Dynamic;
            body.Restitution = 0.2f;
            body.Position = ConvertUnits.ToSimUnits(new Vector2(Transform.X + 500, Transform.Y));
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(block, new Rectangle((int)ConvertUnits.ToDisplayUnits(body.Position.X), (int)ConvertUnits.ToDisplayUnits(body.Position.Y), block.Width, block.Height), Color.White);
        }
    }
}
