using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateTransition
{
	public string nextState;

	List<Condition> conditions = new List<Condition>();

	public AIStateTransition(string nextState, List<Condition> conditions)
	{
		this.nextState = nextState;
		this.conditions = conditions;
	}

	public AIStateTransition(string nextState)
	{
		this.nextState = nextState;
	}

	public void AddCondition(Condition condition)
	{
		conditions.Add(condition);
	}

	public bool ToTransition()
	{
		foreach (var condition in conditions)
		{
			if (!condition.IsTrue()) return false;
		}
		return true;
	}
}
