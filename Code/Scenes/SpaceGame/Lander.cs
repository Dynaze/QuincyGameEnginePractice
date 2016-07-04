using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics;

namespace QuincyGameEnginePractice
{
	public sealed class Lander : GameObject
	{

		/// <summary>
		/// Current Fuel of the Lander
		/// </summary>
		public float Fuel
		{
			get { return _fuel; }
			set { _fuel = MathHelper.Clamp(value, 0f, 100f); }
		}
		float _fuel;

		Body body;

		Vector2 force;

		const float SPEED = 1000;

		Vector2 origin;

		/// <summary>
		/// Can the Lander still fly
		/// </summary>
		public bool CanFly { get { return Fuel > 0f; } }

		Texture2D landerTexture;

		public Lander(World world) : base(true)
		{
			landerTexture = Global.Ref.Content.Load<Texture2D>("Sprites/Lander");
			body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(landerTexture.Width), ConvertUnits.ToSimUnits(landerTexture.Height), 1f);
			body.BodyType = BodyType.Dynamic;
			body.FixedRotation = true;
			origin = new Vector2(landerTexture.Width, landerTexture.Height)/2;
		}

		public override void Start()
		{
			Fuel = 100f;
		}

		public override void Update(GameTime gameTime)
		{
			if(CanFly)
			{
				if(ControlHandle.KeyPressed(Keys.W))
				{
					force += Vector2.Zero.Up();
				}
				if(ControlHandle.KeyPressed(Keys.A))
				{
					force += Vector2.Zero.Left();
				}
				if(ControlHandle.KeyPressed(Keys.S))
				{
					force += Vector2.Zero.Down();
				}
				if(ControlHandle.KeyPressed(Keys.D))
				{
					force += Vector2.Zero.Right();
				}
				Vector2.Normalize(force);
			}
		}

		public override void FixedUpdate(float fixedUpdate)
		{
			if(force != Vector2.Zero)
				body.ApplyForce(force * SPEED * fixedUpdate);
		}

		public override void Draw(SpriteBatch sb)
		{
			sb.Draw(landerTexture, body.Position.DisUnits(), origin: origin, color: Color.White);
		}

		public override void DrawUi(SpriteBatch sb)
		{
		}
	}
}
