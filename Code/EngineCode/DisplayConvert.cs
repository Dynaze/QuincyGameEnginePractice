using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace QuincyGameEnginePractice
{
	public static class DisplayConvert
	{
		static Viewport _vp;

		static bool isGdInit = false;

		public static void ChangeViewport(Viewport v)
		{
			_vp = v;
			isGdInit = true;
		}

		static void throwIfNoVp()
		{
			if(!isGdInit)
			{
				throw new NullReferenceException("DisplayConvert graphics device is null...");
			}
		}

		public static Vector2 GetMiddle()
		{
			return new Vector2(_vp.Width / 2, _vp.Height / 2);
		}

		public static Vector2 ToPercent(Vector2 percentLocation)
		{
			throwIfNoVp();
			Vector2 temp = GetMiddle();
			Vector2 newVec;
			if(percentLocation.X == 0 && percentLocation.Y == 0)
			{
				return temp;
			}
			newVec.X = temp.X += (temp.X * percentLocation.X);
			newVec.Y = temp.Y -= (temp.Y * percentLocation.Y);
			return newVec;
		}

		public static float ToPercentW(float percentLocation)
		{
			throwIfNoVp();
			Vector2 temp = GetMiddle();
			float newFloat;

			newFloat = temp.X += (temp.X * percentLocation);

			return newFloat;
		}

		public static float ToPercentH(float percentLocation)
		{
			throwIfNoVp();
			Vector2 temp = GetMiddle();
			float newFloat;

			newFloat = temp.Y -= (temp.Y * percentLocation);

			return newFloat;
		}
	}
}
