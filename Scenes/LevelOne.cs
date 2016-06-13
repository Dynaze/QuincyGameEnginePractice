using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuincyGameEnginePractice.EngineCode;
using QuincyGameEnginePractice.GameScripts;

namespace QuincyGameEnginePractice.Scenes
{
    class LevelOne : BaseScene
    {
        InputHandler input;
        TileMap tileMap;
        Text fps;
        public Rectangle ScreenArea;

        List<PhysicsBlock> blocks;

        PhysicsFloor floor;

        World world;

        public LevelOne() : base("LevelOne")
        {
            
        }

        public override void Initialize()
        {
            ScreenArea = new Rectangle(0,0, Global.Ref.GraphicsDevice.Viewport.X, Global.Ref.GraphicsDevice.Viewport.Y);
            SceneBackgroundColor = Color.CornflowerBlue;
            world = new World(new Vector2(0f, 10f));
            blocks = new List<PhysicsBlock>();
            floor = new PhysicsFloor(world);
            for(int i = 0; i<100; i++)
                blocks.Add(new PhysicsBlock(world));
            fps = new Text();
            input = new InputHandler();
            tileMap = new TileMap(80,45);
            //componentManager.Add(tileMap);
            foreach(var b in blocks)
                componentManager.Add(b);
            componentManager.Add(floor);
            componentManager.Add(fps);
            componentManager.Add(input);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            if(InputHandler.KeyPressed(Keys.Escape))
                Global.Ref.Exit();
            base.Update(gameTime);
        }

        public override void Draw()
        {
            Global.Ref.GraphicsDevice.Clear(SceneBackgroundColor);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawObjects();
            spriteBatch.End();
            spriteBatch.Begin();
            DrawUi();
            spriteBatch.End();
        }
    }
}
