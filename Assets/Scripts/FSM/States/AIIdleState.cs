using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
	ValueRef<bool> Dance1 = new ValueRef<bool>(false);
	ValueRef<bool> Dance2 = new ValueRef<bool>(false);
	ValueRef<bool> Wave = new ValueRef<bool>(false);

	public AIIdleState(AIStateAgent agent) : base(agent)
	{
		AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
		transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIChaseState));
		transition.AddCondition(new BoolCondition(agent.enemySeen));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIDanceState));
		transition.AddCondition(new BoolCondition(Dance1));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIDance2State));
		transition.AddCondition(new BoolCondition(Dance2));
		transitions.Add(transition);

		transition = new AIStateTransition(nameof(AIWaveState));
		transition.AddCondition(new BoolCondition(Wave));
		transitions.Add(transition);

	}

	public override void OnEnter()
	{
		Dance1.value = false;
		Dance2.value = false;
		Wave.value = false;
		agent.timer.value = 1000;
		agent.movement.Stop();
		agent.movement.Velocity = Vector3.zero;

		switch(Random.Range(1, 10))
		{
			case 1:
				Wave.value = true;
				break;
			case 2:
				Dance1.value = true;
				break;
			case 3:
				Dance2.value = true;
				break;
			default:
				agent.timer.value = Random.Range(1, 2);
				break;
		}
	}

	public override void OnExit()
	{
	}

	public override void OnUpdate()
	{
	}
}
