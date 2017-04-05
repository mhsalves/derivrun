using System;

namespace Utilitarios
{
	public class RandomUtils
	{

		public static T RandomEnumValue<T> ()
		{
			var v = Enum.GetValues (typeof (T));
			return (T) v.GetValue (new System.Random ().Next(v.Length));
		}

		public static int RandomInt( int min, int max ) {
			Random r = new Random();
			return r.Next (min, max);
		}

	}
}

