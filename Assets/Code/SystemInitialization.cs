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
		this.Animate (0.35f, (animationProgress) => {
			introElements.alpha = animationProgress;
		}, () => {
			introElements.alpha = 1;
			introElements.interactable = true;
		}, null, 2f);
	}

	public void LoadGameScene ()
	{
		SceneManager.LoadScene ("Game");
	}
}
