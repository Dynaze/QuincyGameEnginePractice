using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
	class Block : GameObject
	{
		public static Texture2D texture;
		Body body;
		World world;

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
				texture = Texture2DExtentions.ColorTexture2D(Global.Ref.GraphicsDevice, 25, 25, Color.GreenYellow);
			body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(texture.Width), ConvertUnits.ToSimUnits(texture.Height), 10f);
			body.BodyType = BodyType.Dynamic;
			body.Restitution = 0.2f;
			body.SetTransform(new Vector2(ScreenArea.Width / 2, 50).SimUnits(), 0.9f);
			body.SleepingAllowed = true;
			body.Friction = 1.0f;
		}

		public override void Update(GameTime gameTime)
		{
			var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
			var toMove = Vector2.Zero;
			float speed = texture.Width * texture.Height;
			if(InputHandler.KeyDown(Keys.W))
			{
				toMove += Vector2.Zero.Up();
			}
			if(InputHandler.KeyDown(Keys.A))
			{
				toMove += Vector2.Zero.Left();
			}
			if(InputHandler.KeyDown(Keys.S))
			{
				toMove += Vector2.Zero.Down();
			}
			if(InputHandler.KeyDown(Keys.D))
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
			sb.Draw(texture: texture, position: body.Position.DisUnits(), origin: new Vector2(texture.Width, texture.Height) / 2, color: Color.White, rotation: body.Rotation, layerDepth: DrawOrder);
		}

		public override void Dispose()
		{
			//texture.Dispose();
			body.Dispose();
		}
	}
}
