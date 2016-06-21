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
		public double CurrentFramesPerSecond;

		const int MAXIMUM_SAMPLES = 100;

		Queue<float> sampleBuffer;

		public FPSCounter() : base(true)
		{
			sampleBuffer = new Queue<float>();
		}

		public override void Update(GameTime gameTime)
		{
			var deltaTime = gameTime.ElapsedGameTime.TotalSeconds;

			CurrentFramesPerSecond = 1.0 / deltaTime;

			sampleBuffer.Enqueue((float)CurrentFramesPerSecond);

			if(sampleBuffer.Count > MAXIMUM_SAMPLES)
			{
				sampleBuffer.Dequeue();
				AverageFramesPerSecond = sampleBuffer.Average(i => i);
			}
			else
			{
				AverageFramesPerSecond = (float)CurrentFramesPerSecond;
			}

			TotalFrames++;
			TotalSeconds += (float)deltaTime;
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