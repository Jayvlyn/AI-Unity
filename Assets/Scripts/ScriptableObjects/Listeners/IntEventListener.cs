using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// IntEventListener - MonoBehaviour that listens to an IntEvent and invokes a UnityEvent<int> in response.
/// </summary>
public class IntEventListener : MonoBehaviour
{
	[SerializeField] private IntEvent _event = default; // The IntEvent to subscribe to.
	public UnityEvent<int> listener; // The UnityEvent<int> to invoke in response to the IntEvent.

	/// <summary>
	/// Subscribe to the IntEvent when this MonoBehaviour is enabled.
	/// </summary>
	private void OnEnable()
	{
		_event?.Subscribe(Respond);
	}

	/// <summary>
	/// Unsubscribe from the IntEvent when this MonoBehaviour is disabled.
	/// </summary>
	private void OnDisable()
	{
		_event?.Unsubscribe(Respond);
	}

	/// <summary>
	/// Response method invoked when the subscribed IntEvent is raised.
	/// Invokes the UnityEvent<int> to trigger the associated Unity events with the provided int value.
	/// </summary>
	/// <param name="value">The int value passed by the IntEvent.</param>
	private void Respond(int value)
	{
		listener?.Invoke(value);
	}
}
