using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils
{
	/// <summary>
	/// Example: Remap(2,1,3,0,10) = 5
	/// </summary>
	public static float Remap (float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
