using System;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice.EngineCode
{
	public static class Global
	{
		public static string pipeline = "Content/Output/Assets/";
		public static Program ReferenceToGame;
		public static Program Ref
		{
			get
			{
				return ReferenceToGame;
			}
			set
			{
				if(ReferenceToGame == null)
					ReferenceToGame = value;
				else
					throw new InvalidOperationException();
			}
		}
	}
}
