using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice {
    public sealed class Lander : GameObject {

        /// <summary>
        /// Current Fuel of the Lander
        /// </summary>
        public float Fuel {
            get { return _fuel; }
            set { _fuel = MathHelper.Clamp(value, 0f, 1f); }
        }
        float _fuel;

        /// <summary>
        /// Can the Lander still fly
        /// </summary>
        public bool CanFly { get { return Fuel > 0f; } }

        static Texture2D landerTexture;

        public Lander() : base(true) {}

        public override void Start() {
            //landerTexture = Global.Ref.Content.Load<Texture2D>("Sprites/MoonLander");
            Fuel = 1f;
        }

        public override void FixedUpdate(float fixedUpdate) {
        }

        public override void Update(GameTime gameTime) {
            if (CanFly) {
                if (ControlHandle.KeyPressed(Keys.W)) {

                }
            }
        }
        
        public override void Draw(SpriteBatch sb) {
        }

        public override void DrawUi(SpriteBatch sb) {
        }
    }
}
