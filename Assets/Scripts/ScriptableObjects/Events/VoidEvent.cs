using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event - A simple observer pattern implementation using ScriptableObject.
/// </summary>
[CreateAssetMenu(menuName = "Events/Event")]
public class VoidEvent : ScriptableObjectBase
{
	// Unity Actions allow you to dynamically call multiple functions.
	// They are a simple way to implement delegates in scripting without
	// needing to explicitly define them.
	public UnityAction onEventRaised;

	/// <summary>
	/// Raises the event with the specified boolean value.
	/// </summary>
	public void RaiseEvent()
	{
		onEventRaised?.Invoke();
	}

	/// <summary>
	/// Subscribes an object to the event.
	/// </summary>
	/// <param name="listener">The object that wants to subscribe.</param>
	public void Subscribe(UnityAction listener)
	{
		onEventRaised += listener;
	}

	/// <summary>
	/// Unsubscribes an object from the event.
	/// </summary>
	/// <param name="listener">The object that wants to unsubscribe.</param>
	public void Unsubscribe(UnityAction listener)
	{
		onEventRaised -= listener;
	}
}
