using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemInitialization : MonoBehaviour
{
	public CanvasGroup introElements;

	void Start ()
	{
		introElements.alpha = 0;
		introElements.interactable = false;
		this.DoAfterSeconds (() => {
			StartCoroutine (InAnim (0.35f));
		}, 2f);
	}

	public void LoadGameScene ()
	{
		SceneManager.LoadScene ("Game");
	}

	IEnumerator InAnim (float animTime)
	{
		float elapsedTime = 0f;
		while (elapsedTime <= animTime) {
			introElements.alpha = elapsedTime / animTime;
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		introElements.alpha = 1;
		introElements.interactable = true;
	}
}
