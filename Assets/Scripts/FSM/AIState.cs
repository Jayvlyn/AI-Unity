using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
	private AIStateAgent agent;

	public AIState(AIStateAgent agent)
	{
		this.agent = agent;
	}

	public abstract void OnEnter();
	public abstract void OnExit();
	public abstract void OnUpdate();
}
