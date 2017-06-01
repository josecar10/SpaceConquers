using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCard : MonoBehaviour
{
	[Header ("Visual aspect")]
	public Text titleText;
	public Text descriptionText;
	public Image cardImage;
	public Text leftActionText;
	public Text rightActionText;

	[Header ("Animations")]
	public AnimationCurve animationCurve;
	public GameObject leftActionSign, rightActionSign;
	public float maxMovementAmount = 0.1f;

	RectTransform rectTransform;
	float targetRotation = -14;
	float targetPosition = 50;
	float animationPercentaje;
	SwipeDirection optionChosed;

	Card currentCard;

	void Start ()
	{
		SwipeRecognizer.OnSwipe += OnSwipe;
		SwipeRecognizer.OnFingerUp += OnFingerUp;

		rectTransform = transform as RectTransform;
		currentCard = GameController.Instance.GetCard ();
		DrawCardInfo ();
	}

	void OnDestroy ()
	{
		SwipeRecognizer.OnSwipe += OnSwipe;
		SwipeRecognizer.OnFingerUp += OnFingerUp;
	}

	void OnSwipe (SwipeDirection swipeDirection, float movementAmount)
	{
		if (currentCard == null || !gameObject.activeSelf)
			return;
		
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

		if (swipeDirection != SwipeDirection.Stationary && animationPercentaje > 0.66f)
			optionChosed = swipeDirection;
		else
			optionChosed = SwipeDirection.Stationary;
	}

	void OnFingerUp ()
	{
		if (currentCard == null || !gameObject.activeSelf)
			return;

		GameController.Instance.ApplyCardEffect (currentCard, optionChosed);
		currentCard = GameController.Instance.GetCard ();

		// TODO: out anim
		// TODO: in anim

		rectTransform.anchoredPosition = Vector2.zero;
		rectTransform.localRotation = Quaternion.identity;
		leftActionSign.SetActive (false);
		rightActionSign.SetActive (false);
		optionChosed = SwipeDirection.Stationary;
		DrawCardInfo ();
	}

	void DrawCardInfo ()
	{
		if (currentCard == null) {
			cardImage.enabled = false;
		} else {
			titleText.text = currentCard.title;
			descriptionText.text = currentCard.description;
			leftActionText.text = currentCard.leftActionText;
			rightActionText.text = currentCard.rightActionText;
		}
	}
}
