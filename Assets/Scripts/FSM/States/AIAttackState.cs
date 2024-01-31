using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIState
{
	public AIAttackState(AIStateAgent agent) : base(agent)
	{
	}

	public override void OnEnter()
	{
	}

	public override void OnExit()
	{
	}

	public override void OnUpdate()
	{
		Debug.Log("Attack");
	}
}
