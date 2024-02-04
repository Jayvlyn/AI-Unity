using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
	float timer;

	public AIIdleState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		timer = Time.time + Random.Range(1, 2);
	}

	public override void OnExit()
	{
	}

	public override void OnUpdate()
	{
		if(Time.time > timer)
		{
			agent.stateMachine.SetState(nameof(AIPatrolState));
		}

		var enemies = agent.enemyPerception.GetGameObjects();
		var friends = agent.friendPerception.GetGameObjects();
		if(friends.Length > 0)
		{
			agent.stateMachine.SetState(nameof(AIDanceState));
		}
		else if (enemies.Length > 0)
		{
			agent.stateMachine.SetState(nameof(AIAttackState));
		}
	}
}
