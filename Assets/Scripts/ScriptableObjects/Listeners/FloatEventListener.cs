using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// FloatEventListener - MonoBehaviour that listens to an FloatEvent and invokes a UnityEvent<float> in response.
/// </summary>
public class FloatEventListener : MonoBehaviour
{
	[SerializeField] private FloatEvent _event = default; // The FloatEvent to subscribe to.
	public UnityEvent<float> listener; // The UnityEvent<float> to invoke in response to the FloatEvent.

	/// <summary>
	/// Subscribe to the FloatEvent when this MonoBehaviour is enabled.
	/// </summary>
	private void OnEnable()
	{
		_event?.Subscribe(Respond);
	}

	/// <summary>
	/// Unsubscribe from the FloatEvent when this MonoBehaviour is disabled.
	/// </summary>
	private void OnDisable()
	{
		_event?.Unsubscribe(Respond);
	}

	/// <summary>
	/// Response method invoked when the subscribed FloatEvent is raised.
	/// Invokes the UnityEvent<float> to trigger the associated Unity events with the provided float value.
	/// </summary>
	/// <param name="value">The float value passed by the FloatEvent.</param>
	private void Respond(float value)
	{
		listener?.Invoke(value);
	}
}
