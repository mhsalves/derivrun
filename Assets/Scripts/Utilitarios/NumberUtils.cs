using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilitarios {

	public class NumberUtils {

		public static bool IsWithin(int value, int minimum, int maximum)
		{
			return value >= minimum && value <= maximum;
		}

		public static bool IsWithin(float value, float minimum, float maximum)
		{
			return value >= minimum && value <= maximum;
		}

		public static bool IsWithin(double value, double minimum, double maximum)
		{
			return value >= minimum && value <= maximum;
		}

	}

}