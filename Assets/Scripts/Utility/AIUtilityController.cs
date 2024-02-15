using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUtilityController : MonoBehaviour
{
	[SerializeField] AIUtilityAgent agent;
	[SerializeField] LayerMask layerMask;

	void Update()
	{
		// don't move agent if agent is using an utility object
		if (Input.GetMouseButtonDown(0) && agent.activeUtilityObject == null)
		{
			// get ray from mouse position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// cast ray into world, check for layer
			if (Physics.Raycast(ray, out RaycastHit raycastHit, 100, layerMask))
			{
				// move agent towards ray hit point
				agent.movement.MoveTowards(raycastHit.point);
			}
		}
	}
}
