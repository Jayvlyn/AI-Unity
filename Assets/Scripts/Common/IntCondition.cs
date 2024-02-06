using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCondition : Condition
{
	ValueRef<int> parameter;
	int condition;
	Predicate predicate;

	public IntCondition(ValueRef<int> parameter, Predicate predicate, int condition)
	{
		this.parameter = parameter;
		this.predicate = predicate;
		this.condition = condition;
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
