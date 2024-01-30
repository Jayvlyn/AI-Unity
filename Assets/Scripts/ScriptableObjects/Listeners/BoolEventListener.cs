using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// BoolEventListener - MonoBehaviour that listens to a BoolEvent and invokes a UnityEvent<bool> in response.
/// </summary>
public class BoolEventListener : MonoBehaviour
{
	[SerializeField] private BoolEvent _event = default; // The BoolEvent to subscribe to.
	public UnityEvent<bool> listener; // The UnityEvent<bool> to invoke in response to the BoolEvent.

	/// <summary>
	/// Subscribe to the BoolEvent when this MonoBehaviour is enabled.
	/// </summary>
	private void OnEnable()
	{
		_event?.Subscribe(Respond);
	}

	/// <summary>
	/// Unsubscribe from the BoolEvent when this MonoBehaviour is disabled.
	/// </summary>
	private void OnDisable()
	{
		_event?.Unsubscribe(Respond);
	}

	/// <summary>
	/// Response method invoked when the subscribed BoolEvent is raised.
	/// Invokes the UnityEvent<bool> to trigger the associated Unity events with the provided bool value.
	/// </summary>
	/// <param name="value">The bool value passed by the BoolEvent.</param>
	private void Respond(bool value)
	{
		listener?.Invoke(value);
	}
}
