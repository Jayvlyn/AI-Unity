using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BoolVariable - ScriptableObject representing a boolean variable.
/// </summary>
[CreateAssetMenu(menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject
{
	public bool initialValue; // The initial value of the boolean variable.

	[NonSerialized]
	public bool value; // The current value of the boolean variable.

	/// <summary>
	/// Called after deserialization. Sets the current value to the initial value.
	/// </summary>
	public void OnAfterDeserialize()
	{
		value = initialValue;
	}

	/// <summary>
	/// Called before serialization. Placeholder method with no implementation.
	/// </summary>
	public void OnBeforeSerialize()
	{
		// No implementation needed for this method.
	}

	/// <summary>
	/// Implicit conversion from BoolVariable to bool.
	/// Allows using BoolVariable directly as if it were a bool.
	/// </summary>
	/// <param name="variable">The BoolVariable to convert.</param>
	/// <returns>The underlying bool value of the variable.</returns>
	public static implicit operator bool(BoolVariable variable)
	{
		return variable.value;
	}
}

