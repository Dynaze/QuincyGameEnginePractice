using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace QuincyGameEnginePractice {
    public sealed class FuelBar : GameObject {

        /// <summary>
        /// The Range of the Bar, X == Min / Y == Max
        /// </summary>
        public Vector2 Range { get; set; }
        Texture2D _barTexture, _backBarTexture, _barValueTexture;

        SpriteFont _font;


        /// <summary>
        /// Current Value shown in Bar
        /// </summary>
        public float Value {
            get { return _value; }
            set { _value = MathHelper.Clamp(value, Range.X, Range.Y); }
        }
        float _value;

        public FuelBar() : base(true) { }

        public override void Start() {
            //_backBarTexture = Global.Ref.Content.Load<Texture2D>("Sprites/LoadingBar/backTexture");
            //_barTexture = Global.Ref.Content.Load<Texture2D>("Sprites/LoadingBar/barTexture");

            _font = Global.Ref.Content.Load<SpriteFont>("Fonts/PrimeCode");

        }   

        public override void Update(GameTime gameTime) {}
        public override void DrawUi(SpriteBatch sb) {
            sb.DrawString(_font, $"{Value.ToString("0.00")}%", Vector2.One, Color.White);
        }

    }
}
