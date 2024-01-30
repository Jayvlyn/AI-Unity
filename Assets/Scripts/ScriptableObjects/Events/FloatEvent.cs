using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// FloatEvent - A simple observer pattern implementation using ScriptableObject.
/// </summary>
[CreateAssetMenu(menuName = "Events/Float Event")]
public class FloatEvent : ScriptableObjectBase
{
	// Unity Actions allow you to dynamically call multiple functions.
	// They are a simple way to implement delegates in scripting without
	// needing to explicitly define them.
	public UnityAction<float> onEventRaised;

	/// <summary>
	/// Raises the event with the specified float value.
	/// </summary>
	/// <param name="value">The float value to pass to subscribers.</param>
	public void RaiseEvent(float value)
	{
		onEventRaised?.Invoke(value);
	}

	/// <summary>
	/// Subscribes an object to the event.
	/// </summary>
	/// <param name="listener">The object that wants to subscribe.</param>
	public void Subscribe(UnityAction<float> listener)
	{
		onEventRaised += listener;
	}

	/// <summary>
	/// Unsubscribes an object from the event.
	/// </summary>
	/// <param name="listener">The object that wants to unsubscribe.</param>
	public void Unsubscribe(UnityAction<float> listener)
	{
		onEventRaised -= listener;
	}
}
