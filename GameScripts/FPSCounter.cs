using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace QuincyGameEnginePractice.GameScripts
{
	/// <summary>
	/// FPS Counter Class
	/// </summary>
	public class FPSCounter : GameObject
	{
		/// <summary>
		/// Total Frames since start
		/// </summary>
		public long TotalFrames;

		/// <summary>
		/// Total Seconds since start
		/// </summary>
		public float TotalSeconds;

		/// <summary>
		/// Average FPS
		/// </summary>
		public float AverageFramesPerSecond;

		/// <summary>
		/// Current FPS
		/// </summary>
		public float CurrentFramesPerSecond;

		const int MAXIMUM_SAMPLES = 100;

		Queue<float> sampleBuffer;

		public FPSCounter(Game game)
		{
			Enabled = true;
			Visible = false;
		}

		public override void Initialize()
		{
			sampleBuffer = new Queue<float>();
		}

		public override void Update(GameTime gameTime)
		{
			var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			CurrentFramesPerSecond = 1.0f / deltaTime;

			sampleBuffer.Enqueue(CurrentFramesPerSecond);

			if(sampleBuffer.Count > MAXIMUM_SAMPLES)
			{
				sampleBuffer.Dequeue();
				AverageFramesPerSecond = sampleBuffer.Average(i => i);
			}
			else
			{
				AverageFramesPerSecond = CurrentFramesPerSecond;
			}

			TotalFrames++;
			TotalSeconds += deltaTime;
		}

		/// <summary>
		/// Get current FPS rounded up to the nearest 10th
		/// </summary>
		public string GetCurrentFPS()
		{
			return CurrentFramesPerSecond.ToString("0.00");
		}

		/// <summary>
		/// Get Average FPS rounded up to the nearest 10th
		/// </summary>
		public string GetAverageFPS()
		{
			return AverageFramesPerSecond.ToString("0.00");
		}

	}
}