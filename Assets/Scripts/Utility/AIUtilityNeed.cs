using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUtilityNeed : MonoBehaviour
{
	public enum Type
	{
		Energy,
		Hunger,
		Bladder,
		Hygiene,
		Fun
	}

	[Header("Parameters")]
	[SerializeField] public Type type;
	[SerializeField] AnimationCurve curve;

	[SerializeField] float decayRate = 0;
	[SerializeField] public float initalInput;

	[Header("UI")]
	[SerializeField] AIUIMeter meter;

	private float _input;

	public float motive
	{
		get
		{
			return GetMotive(input);
		}
	}

	public float input
	{
		get { return _input; }
		set
		{
			_input = Mathf.Clamp(value, -1, 1);
		}

	}

	private void OnValidate()
	{
		meter.name = type.ToString();
		meter.text = type.ToString();
	}

	void Update()
	{
		input = input - ((1 / decayRate) * Time.deltaTime);
		meter.value = 1 - motive;
	}

	public float GetMotive(float value)
	{
		return Mathf.Clamp(curve.Evaluate(value), 0, 1);
	}
}
