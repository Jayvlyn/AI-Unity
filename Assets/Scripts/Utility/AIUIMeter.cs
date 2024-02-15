using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AIUIMeter : MonoBehaviour
{
	[SerializeField] TMP_Text label;
	[SerializeField] Slider slider;
	[SerializeField] Image image;
	
	public Vector3 position
	{
		set
		{
			Debug.DrawLine(value, value + Vector3.up * 3);
			Vector2 viewportPoint = Camera.main.WorldToViewportPoint(value);
			GetComponent<RectTransform>().anchorMin = viewportPoint;
			GetComponent<RectTransform>().anchorMax = viewportPoint;
		}
	}

	public float value
	{
		set
		{
			slider.value = value;
		}
	}

	public string text
	{
		set
		{ 
			label.text = value; 
		}
	}

	public bool visible
	{
		set
		{
			gameObject.SetActive(value);
		}
	}

	public float alpha
	{
		set
		{
			Color color = image.color;
			color.a = value;
			image.color = color;
		}
	}
}
