using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUtilityWaypoints : MonoBehaviour
{
	[SerializeField] AIUtilityAgent agent;
	[SerializeField] float moveTimer;
	[SerializeField] Transform[] waypoints;

	Coroutine timerCR = null;

	void Update()
	{
		// stop coroutine if using utility object
		if (agent.activeUtilityObject != null && timerCR != null)
		{
			StopCoroutine(timerCR);
			timerCR = null;
		}
		else if (timerCR == null)
		{
			// start coroutine if not using utility object and coroutine has not been started
			timerCR = StartCoroutine(MoveToRandomWaypoint(moveTimer));
		}
	}

	IEnumerator MoveToRandomWaypoint(float timer)
	{
		yield return new WaitForSeconds(timer);
		agent.movement.MoveTowards(waypoints[Random.Range(0, waypoints.Length)].position);
		yield return new WaitUntil(() => Vector3.Distance(agent.transform.position, agent.movement.Destination) < 2);
		timerCR = null;
	}
}
