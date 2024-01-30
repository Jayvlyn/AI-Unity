using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameObjectEvent - A simple observer pattern implementation using ScriptableObject.
/// </summary>
[CreateAssetMenu(menuName = "Events/GameObject Event")]
public class GameObjectEvent : ScriptableObjectBase
{
	// Unity Actions allow you to dynamically call multiple functions.
	// They are a simple way to implement delegates in scripting without
	// needing to explicitly define them.
	public UnityAction<GameObject> onEventRaised;

	/// <summary>
	/// Raises the event with the specified GameObject value.
	/// </summary>
	/// <param name="value">The GameObject value to pass to subscribers.</param>
	public void RaiseEvent(GameObject value)
	{
		onEventRaised?.Invoke(value);
	}

	/// <summary>
	/// Subscribes an object to the event.
	/// </summary>
	/// <param name="listener">The object that wants to subscribe.</param>
	public void Subscribe(UnityAction<GameObject> listener)
	{
		onEventRaised += listener;
	}

	/// <summary>
	/// Unsubscribes an object from the event.
	/// </summary>
	/// <param name="listener">The object that wants to unsubscribe.</param>
	public void Unsubscribe(UnityAction<GameObject> listener)
	{
		onEventRaised -= listener;
	}
}
