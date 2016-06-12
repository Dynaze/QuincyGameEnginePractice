using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuincyGameEnginePractice.EngineCode;

namespace QuincyGameEnginePractice.GameScripts
{
    public class Text : GameObject
    {
        FPSCounter fpsCounter;
        SpriteFont orangeKid;

        public override void Initialize()
        {
            base.Initialize();
            fpsCounter = new FPSCounter(Global.Ref);
            fpsCounter.Initialize();
        }

        public override void LoadContent()
        {
            orangeKid = Global.Ref.Content.Load<SpriteFont>(Global.pipeline + "Fonts/orangeKid");
        }

        public override void Update(GameTime gameTime)
        {
            fpsCounter.Update(gameTime);
        }

        public override void DrawUi(SpriteBatch sb)
        {
            sb.DrawString(orangeKid, $"FPS:{fpsCounter.GetCurrentFPS()}", Transform, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None,0 );
        }
    }
}
