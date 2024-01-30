using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IntVariable - ScriptableObject representing an integer variable.
/// Implements ISerializationCallbackReceiver for custom serialization behavior.
/// </summary>
[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
	public int initialValue; // The initial value of the integer variable.

	[NonSerialized]
	public int value; // The current value of the integer variable.

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
	/// Implicit conversion from IntVariable to int.
	/// Allows using IntVariable directly as if it were an int.
	/// </summary>
	/// <param name="variable">The IntVariable to convert.</param>
	/// <returns>The underlying int value of the variable.</returns>
	public static implicit operator int(IntVariable variable)
	{
		return variable.value;
	}
}

