using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{
	public class CQAnimation
	{
		List<AnimationFrame> frames = new List<AnimationFrame>();

		Coroutines coroutine = new Coroutines();

		int currentFrame;

		public void Add(Rectangle rect, float time)
		{
			AnimationFrame f;
			f.SourceRectangle = rect;
			f.DurationF = time;
			frames.Add(f);
		}

		public void PlayAnimation()
		{
			if(!coroutine.Running)
			{
				coroutine.Start(animation());
			}
			if(coroutine.Running)
			coroutine.Update();
		}

		IEnumerator animation()
		{
			foreach(var f in frames)
			{
				if(currentFrame > frames.Count - 1)
					currentFrame = 0;
				CurrentFrame = frames[currentFrame].SourceRectangle;
				var delay = frames[currentFrame].DurationF;
				currentFrame++;
				yield return Coroutines.Pause(delay);
			}
			yield break;
		}

		public Rectangle CurrentFrame { get; private set; }
	}
}
