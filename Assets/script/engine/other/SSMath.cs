using System;

namespace Susie
{
	public class SSMath
	{
		public static float FloatPrecise = 0.0001f;
		public static bool IsFloatZero(float val){
			return Math.Abs (val) <= FloatPrecise;
		}
	}
}

