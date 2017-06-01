using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResourceType {
	Food,
	Crew,
	Metropolis,
	Planet
}

public class ResourceHolder : MonoBehaviour
{
	public ResourceType resourceType;
	public Image resourceSprite;

	public void SetResourceAmount (int amount, bool animate = true)
	{
		float originAmount = resourceSprite.fillAmount;
		float targetAmount = amount * 0.01f;
		if (animate) {
			StopAllCoroutines ();
			this.Animate (0.3f, (animationProgress) => {
				resourceSprite.fillAmount = Mathf.Lerp(originAmount, targetAmount, animationProgress);
			}, () => {
				resourceSprite.fillAmount = targetAmount;
			});
		} else {
			resourceSprite.fillAmount = targetAmount;
		}
		
	}
}
