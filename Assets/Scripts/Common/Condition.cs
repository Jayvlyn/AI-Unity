using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition
{
	public enum Predicate
	{
		GREATER,
		LESS,
		EQUAL,
		NOT_EQUAL
	}

	public abstract bool IsTrue();
}
