using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace QuincyGameEnginePractice
{
	public class Coroutines
	{
		List<IEnumerator> routines;

		public Coroutines()
		{
			routines = new List<IEnumerator>();
		}

		public void Start(IEnumerator routine)
		{
			routines.Add(routine);
		}

		public void StopAll()
		{
			routines.Clear();
		}

		public void Update()
		{
			for(int i = 0; i < routines.Count; i++)
			{
				if(routines[i].Current is IEnumerator)
					if(MoveNext((IEnumerator)routines[i].Current))
						continue;
				if(!routines[i].MoveNext())
					routines.RemoveAt(i--);
			}
		}

		bool MoveNext(IEnumerator routine)
		{
			if(routine.Current is IEnumerator)
				if(MoveNext((IEnumerator)routine.Current))
					return true;
			return routine.MoveNext();
		}

		public int Count
		{
			get { return routines.Count; }
		}

		public bool Running
		{
			get { return routines.Count > 0; }
		}

		public static IEnumerator Pause(float time)
		{
			var watch = Stopwatch.StartNew();
			while(watch.Elapsed.TotalSeconds < time)
				yield return 0;
		}
	}
}

