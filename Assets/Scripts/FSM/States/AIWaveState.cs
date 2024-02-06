using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveState : AIState
{
	float timer = 0;

	public AIWaveState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		agent.animator?.SetTrigger("Wave");
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