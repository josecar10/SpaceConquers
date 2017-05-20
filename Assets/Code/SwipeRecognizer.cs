using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SwipeDirection { Left, Right, Stationary }

public class SwipeRecognizer : MonoBehaviour
{
	public static event System.Action<SwipeDirection, float> OnSwipe;
	public static event System.Action OnFingerUp;

	float startPosition;
	bool dragging = false;
	SwipeDirection swipeDirection = SwipeDirection.Stationary;

	void Update ()
	{
		if (Input.touchCount == 0)
			return;
		
		Touch touch = Input.GetTouch (0);
		Debug.Log (touch.phase.ToString ());
		if (touch.phase == TouchPhase.Began) {
			startPosition = Camera.main.ScreenToViewportPoint (touch.position).x;
			dragging = true;
			swipeDirection = SwipeDirection.Stationary;
		}

		if (dragging) {
			float actualPosition = Camera.main.ScreenToViewportPoint (touch.position).x;
			SwipeDirection direction = SwipeDirection.Left;
			if (actualPosition >= startPosition)
				direction =	SwipeDirection.Right;

			if (swipeDirection != SwipeDirection.Stationary && swipeDirection != direction)
				startPosition = actualPosition;
			
			OnSwipe (direction, Mathf.Abs (startPosition - actualPosition));
			swipeDirection = direction;
		}
			
		if (touch.phase == TouchPhase.Ended) {
			dragging = false;
			OnFingerUp ();
		}
	}
}
