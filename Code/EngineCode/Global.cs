using System;

namespace QEngine
{
	public static class Global
	{
		public static string pipeline = "Content/Output/Assets/";
		public static readonly Random random = new Random();
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
