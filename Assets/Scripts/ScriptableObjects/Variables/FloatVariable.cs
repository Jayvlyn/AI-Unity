using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FloatVariable - ScriptableObject representing a floating-point number variable.
/// </summary>
[CreateAssetMenu(menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{
	public float initialValue; // The initial value of the floating-point variable.

	[NonSerialized]
	public float value; // The current value of the floating-point variable.

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
	/// Implicit conversion from FloatVariable to float.
	/// Allows using FloatVariable directly as if it were a float.
	/// </summary>
	/// <param name="variable">The FloatVariable to convert.</param>
	/// <returns>The underlying float value of the variable.</returns>
	public static implicit operator float(FloatVariable variable)
	{
		return variable.value;
	}
}

