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

	public static void Animate (this MonoBehaviour monoBehaviour, float animationTime, System.Action<float> animationAction, System.Action actionPost = null, System.Action actionPre = null,  float delay = 0f)
	{
		monoBehaviour.StartCoroutine (AnimateCoroutine(animationTime, delay, animationAction, actionPost, actionPre));
	}

	static IEnumerator AnimateCoroutine (float animationTime, float delay, System.Action<float> animationAction, System.Action actionPost = null, System.Action actionPre = null)
	{
		yield return new WaitForSeconds (delay);
		actionPre.SafeInvoke ();
		float elapsedTime = 0f;
		while (elapsedTime <= animationTime)
		{
			animationAction (elapsedTime/animationTime);
			yield return null;
			elapsedTime += Time.deltaTime;
		}

		Debug.Log ("Anim finished: " + elapsedTime);
		actionPost.SafeInvoke ();
	}
}
