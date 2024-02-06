using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCondition : Condition
{
	ValueRef<bool> parameter;
	bool condition;

	public BoolCondition(ValueRef<bool> parameter, bool condition = true)
	{
		this.parameter = parameter;
		this.condition = condition;
	}

	public override bool IsTrue()
	{
		return (parameter == condition);
	}
}
