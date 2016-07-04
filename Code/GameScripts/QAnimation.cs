using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice
{
	class QAnimation
	{
		List<AnimationFrame> frames = new List<AnimationFrame>();

		float accumulator = 0f;

		float currentFrameDelay = 0f;

		int currentFrame = 0;

		/// <summary>
		/// Add all the frames for the animation in the order that they go in
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="time"></param>
		public void AddFrame(Rectangle rect, float time)
		{
			AnimationFrame f;
			f.DurationF = time;
			f.SourceRectangle = rect;
			frames.Add(f);
		}

		/// <summary>
		/// call this to loop the animation
		/// </summary>
		/// <param name="delta"></param>
		public void Update(float delta)
		{
			accumulator += delta;
			if(accumulator > currentFrameDelay)
			{
				if(currentFrame < frames.Count)
				{
					currentRectangle = frames[currentFrame].SourceRectangle;
					currentFrameDelay = frames[currentFrame].DurationF;
					if(currentFrame == frames.Count - 1)
						currentFrame = 0;
				}
				currentFrame++;
				accumulator = 0;
			}
		}

		public Rectangle currentRectangle { get; private set; }
	}
}
