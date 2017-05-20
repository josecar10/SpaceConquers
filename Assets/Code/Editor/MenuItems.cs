using UnityEditor;
using UnityEngine;

public class MenuItems
{
	[MenuItem("CONTEXT/RectTransform/Set anchors to rect")]
	private static void SetAnchorsToRect(MenuCommand menuCommand)
	{
		// TODO
		//RectTransform target = menuCommand.context as RectTransform;
		/*Undo.RecordObject (target, "Anchors setted");
		float minX = - target.sizeDelta.x / 2f + target.anchoredPosition.x;
		float minY = - target.sizeDelta.y / 2f + target.anchoredPosition.y;
		float maxX =   target.sizeDelta.x / 2f + target.anchoredPosition.x;
		float maxY =   target.sizeDelta.y / 2f + target.anchoredPosition.y;
		target.anchorMin = new Vector2 (Mathf.Clamp01 (MathUtils.Remap (minX, - Screen.width / 2f, Screen.width / 2f, 0f, 1f)), Mathf.Clamp01 (MathUtils.Remap (minY, - Screen.height / 2f, Screen.height / 2f, 0f, 1f))); // low left
		target.anchorMax = new Vector2 (Mathf.Clamp01 (MathUtils.Remap (maxX, - Screen.width / 2f, Screen.width / 2f, 0f, 1f)), Mathf.Clamp01 (MathUtils.Remap (maxY, - Screen.height / 2f, Screen.height / 2f, 0f, 1f))); // top right
		target.anchoredPosition3D = Vector3.zero;
		target.offsetMax = Vector2.zero;
		target.offsetMin = Vector2.zero;*/
	}
}
