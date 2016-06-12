using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice.EngineCode
{
    public static class Vec2
    {
        public static Vector2 Up
        {
            get { return -Vector2.UnitY; }
        }

        public static Vector2 Down
        {
            get { return Vector2.UnitY; }
        }

        public static Vector2 Left
        {
            get { return -Vector2.UnitX; }
        }

        public static Vector2 Right
        {
            get { return Vector2.UnitX; }
        }
    }
}
