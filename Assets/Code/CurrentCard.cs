using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCard : MonoBehaviour
{
	public AnimationCurve animationCurve;
	public GameObject rightActionSign, leftActionSign;

	RectTransform rectTransform;
	public float maxMovementAmount = 0.1f;
	float targetRotation = -14;
	float targetPosition = 50;
	float animationPercentaje;

	void Start ()
	{
		SwipeRecognizer.OnSwipe += OnSwipe;
		SwipeRecognizer.OnFingerUp += OnFingerUp;

		rectTransform = transform as RectTransform;
	}

	void OnDestroy ()
	{
		SwipeRecognizer.OnSwipe += OnSwipe;
		SwipeRecognizer.OnFingerUp += OnFingerUp;
	}

	void OnSwipe (SwipeDirection swipeDirection, float movementAmount)
	{
		animationPercentaje = movementAmount / maxMovementAmount;
		if (swipeDirection == SwipeDirection.Left)
		{
			rectTransform.anchoredPosition = new Vector2 (- animationCurve.Evaluate (animationPercentaje) * targetPosition, 0);
			rectTransform.localRotation = Quaternion.Euler (0, 0, - animationCurve.Evaluate (animationPercentaje) * targetRotation);
			leftActionSign.SetActive (animationPercentaje > 0.66f);
			if (rightActionSign.activeSelf && animationPercentaje > 0.2f)
				rightActionSign.SetActive (false);
		}
		else if (swipeDirection == SwipeDirection.Right)
		{
			rectTransform.anchoredPosition = new Vector2 (animationCurve.Evaluate (animationPercentaje) * targetPosition, 0);
			rectTransform.localRotation = Quaternion.Euler (0, 0, animationCurve.Evaluate (animationPercentaje) * targetRotation);
			rightActionSign.SetActive (animationPercentaje > 0.66f);
			if (leftActionSign.activeSelf && animationPercentaje > 0.2f)
				leftActionSign.SetActive (false);
		}
	}

	void OnFingerUp ()
	{
		rectTransform.anchoredPosition = Vector2.zero;
		rectTransform.localRotation = Quaternion.identity;
		leftActionSign.SetActive (false);
		rightActionSign.SetActive (false);
	}

}
