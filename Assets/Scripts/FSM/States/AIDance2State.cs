using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDance2State : AIState
{
	float timer = 0;

	public AIDance2State(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		agent.animator?.SetTrigger("Dance2");
		timer = Time.time + 5;
	}

	public override void OnUpdate()
	{
		if (Time.time > timer)
		{
			agent.stateMachine.SetState(nameof(AIIdleState));
		}
	}

	public override void OnExit()
	{
	}

}