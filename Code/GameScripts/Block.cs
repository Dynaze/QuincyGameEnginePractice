using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace QuincyGameEnginePractice
{
	class Block : GameObject
	{
		static Texture2D texture;
		Body body;
		World world;

		const float speed = 1000;

		Rectangle ScreenArea;

		public Block(World world) : base(true)
		{
			this.world = world;
		}

		public override void Start()
		{
			ScreenArea = SceneManager.GetScene().ScreenArea;
			DrawOrder = 1;
			if(texture == null)
				texture = Texture2DExtentions.ColorTexture2D(15, 15, Color.GreenYellow);
			body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(texture.Width), ConvertUnits.ToSimUnits(texture.Height), 150f);
			body.IgnoreCCD = true;			
			body.BodyType = BodyType.Dynamic;
			body.Restitution = 0.1f;
			body.SetTransform(new Vector2(ScreenArea.Width / 2, 50).SimUnits(), 0f);
			body.SleepingAllowed = true;
			body.Friction = 2.0f;
		}

		public override void FixedUpdate(float fixedUpdate)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
			var toMove = Vector2.Zero;
			if(ControlHandle.KeyDown(Keys.W))
			{
				toMove += Vector2.Zero.Up();
			}
			if(ControlHandle.KeyDown(Keys.A))
			{
				toMove += Vector2.Zero.Left();
			}
			if(ControlHandle.KeyDown(Keys.S))
			{
				toMove += Vector2.Zero.Down();
			}
			if(ControlHandle.KeyDown(Keys.D))
			{
				toMove += Vector2.Zero.Right();
			}
			Vector2.Normalize(toMove);
			if(toMove != Vector2.Zero)
				body.ApplyForce(toMove * speed * delta);
			if(!ScreenArea.Contains(body.Position.DisUnits()))
			{
				world.RemoveBody(body);
				GetComponents.components.Remove(this);
			}
		}

		public override void Draw(SpriteBatch sb)
		{
			//have to use position of body and the origin needs to be half the texture width and height
			sb.Draw(texture, body.Position.DisUnits(), origin: new Vector2(texture.Width, texture.Height) / 2, color: Color.White, rotation: body.Rotation, layerDepth: DrawOrder);
		}

		public override void Dispose()
		{
			body.Dispose();
		}
	}
}
