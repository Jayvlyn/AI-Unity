using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameObjectEventListener - MonoBehaviour that listens to a GameObjectEvent and invokes a UnityEvent<GameObject> in response.
/// </summary>
public class GameObjectEventListener : MonoBehaviour
{
	[SerializeField] private GameObjectEvent _event = default; // The GameObjectEvent to subscribe to.
	public UnityEvent<GameObject> listener; // The UnityEvent<GameObject> to invoke in response to the GameObjectEvent.

	/// <summary>
	/// Subscribe to the GameObjectEvent when this MonoBehaviour is enabled.
	/// </summary>
	private void OnEnable()
	{
		_event?.Subscribe(Respond);
	}

	/// <summary>
	/// Unsubscribe from the GameObjectEvent when this MonoBehaviour is disabled.
	/// </summary>
	private void OnDisable()
	{
		_event?.Unsubscribe(Respond);
	}

	/// <summary>
	/// Response method invoked when the subscribed GameObjectEvent is raised.
	/// Invokes the UnityEvent<GameObject> to trigger the associated Unity events with the provided GameObject value.
	/// </summary>
	/// <param name="value">The GameObject value passed by the GameObjectEvent.</param>
	private void Respond(GameObject value)
	{
		listener?.Invoke(value);
	}
}
