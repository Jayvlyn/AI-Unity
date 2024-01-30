using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameVariable - ScriptableObject representing a GameObject variable.
/// </summary>
[CreateAssetMenu(menuName = "Variables/GameObject")]
public class GameObjectVariable : ScriptableObject
{
	public GameObject initialValue; // The initial value of the GameObject variable.

	[NonSerialized]
	public GameObject value; // The current value of the GameObject variable.

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
	/// Implicit conversion from GameObjectVariable to GameObject.
	/// Allows using GameObjectVariable directly as if it were a GameObject.
	/// </summary>
	/// <param name="variable">The GameObjectVariable to convert.</param>
	/// <returns>The underlying GameObject value of the variable.</returns>
	public static implicit operator GameObject(GameObjectVariable variable)
	{
		return variable.value;
	}
}

