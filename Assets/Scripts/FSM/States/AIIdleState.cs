using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
	public AIIdleState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		Debug.Log("idle enter");
	}

	public override void OnExit()
	{
		Debug.Log("idle exit");
	}

	public override void OnUpdate()
	{
		Debug.Log("idle update");
	}
}
