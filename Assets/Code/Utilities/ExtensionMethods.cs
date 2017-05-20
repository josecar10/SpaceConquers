using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
	public static void DoAfterSeconds(this MonoBehaviour monoBehaviour, System.Action actionToPerform, float delay)
	{
		monoBehaviour.StartCoroutine (DoAfterSecondsCoroutine(actionToPerform, delay));
	}

	static IEnumerator DoAfterSecondsCoroutine (System.Action actionToPerform, float delay)
	{
		yield return new WaitForSeconds (delay);
		actionToPerform.SafeInvoke ();
	}

	public static void SafeInvoke (this System.Action action)
	{
		if (action != null)
			action ();
	}
}
