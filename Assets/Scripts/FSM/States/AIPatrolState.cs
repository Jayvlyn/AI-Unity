using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIState
{
	Vector3 destination;

	public AIPatrolState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
		var navNode = AINavNode.GetRandomAINavNode();
		destination = navNode.transform.position;
	}

    public override void OnUpdate()
    {
		// moev towards destination, go to idle if reached
        agent.movement.MoveTowards(destination);

        if (Vector3.Distance(agent.transform.position, destination) < 1)
		{
			agent.stateMachine.SetState(nameof(AIIdleState));
		}

		var enemies = agent.enemyPerception.GetGameObjects();
		if(enemies.Length > 0)
		{
            agent.stateMachine.SetState(nameof(AIChaseState));
        }

    }

    public override void OnExit()
	{
	}
}
