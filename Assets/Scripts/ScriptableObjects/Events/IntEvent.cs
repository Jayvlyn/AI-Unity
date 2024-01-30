using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// IntEvent - A simple observer pattern implementation using ScriptableObject.
/// </summary>
[CreateAssetMenu(menuName = "Events/Int Event")]
public class IntEvent : ScriptableObjectBase
{
	// Unity Actions allow you to dynamically call multiple functions.
	// They are a simple way to implement delegates in scripting without
	// needing to explicitly define them.
	public UnityAction<int> onEventRaised;

	/// <summary>
	/// Raises the event with the specified integer value.
	/// </summary>
	/// <param name="value">The integer value to pass to subscribers.</param>
	public void RaiseEvent(int value)
	{
		onEventRaised?.Invoke(value);
	}

	/// <summary>
	/// Subscribes an object to the event.
	/// </summary>
	/// <param name="listener">The object that wants to subscribe.</param>
	public void Subscribe(UnityAction<int> listener)
	{
		onEventRaised += listener;
	}

	/// <summary>
	/// Unsubscribes an object from the event.
	/// </summary>
	/// <param name="listener">The object that wants to unsubscribe.</param>
	public void Unsubscribe(UnityAction<int> listener)
	{
		onEventRaised -= listener;
	}
}
