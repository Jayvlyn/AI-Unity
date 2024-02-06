using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCondition : Condition
{
	ValueRef<float> parameter;
	float condition;
	Predicate predicate;

	public FloatCondition(ValueRef<float> parameter, Predicate predicate, float condition)
	{
		this.parameter = parameter;
		this.predicate = predicate;
		this.condition = condition;
	}

	public static FloatCondition Create(ValueRef<float> parameter, Predicate predicate, float condition)
	{
		return new FloatCondition(parameter, predicate, condition);
	}

	public override bool IsTrue()
	{
		bool result = false;

		switch (predicate)
		{
			case Predicate.GREATER:
				result = (parameter > condition);
				break;
			case Predicate.LESS:
				result = (parameter < condition);
				break;
			case Predicate.EQUAL:
				result = (parameter == condition);
				break;
			case Predicate.NOT_EQUAL:
				result = (parameter != condition);
				break;
			default:
				break;
		}

		return result;
	}
}
