//
//  RectangleExtensions.cs
//
//  Author:
//       Tristan <tristan@shortcord.com>
//
//  Copyright (c) 2016 Tristan Smith
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{

	public static class RectangleExtensions
	{

		public static Vector2 AbsoluteCenter(this Rectangle rec)
		{
			return new Vector2(rec.X + (rec.Width / 2), rec.Y + (rec.Height / 2));
		}

		public static Vector2 RelativeCenter(this Rectangle rec)
		{
			return new Vector2((rec.Width / 2), (rec.Height / 2));
		}

		public static Vector2 TopRight(this Rectangle rec)
		{
			return new Vector2(rec.Right, rec.Y);
		}

		public static Vector2 TopLeft(this Rectangle rec)
		{
			return new Vector2(rec.X, rec.Y);
		}

		public static Vector2 BottomLeft(this Rectangle rec)
		{
			return new Vector2(rec.X, rec.Bottom);
		}

		public static Vector2 BottomRight(this Rectangle rec)
		{
			return new Vector2(rec.Right, rec.Bottom);
		}
	}
}
