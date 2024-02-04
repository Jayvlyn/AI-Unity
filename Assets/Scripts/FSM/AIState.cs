using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
	public AIStateAgent agent;

	public AIState(AIStateAgent agent)
	{
		this.agent = agent;
	}

	public string name {  get { return GetType().Name; } }

	public abstract void OnEnter();
	public abstract void OnUpdate();
	public abstract void OnExit();
}
