using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AIUtilityAgent : AIAgent
{
	[SerializeField] AIPerception perception;
	[SerializeField] Animator animator;

	[SerializeField] AIUtilityNeed[] needs;
	[SerializeField, Range(0, 1), Tooltip("minimum score to use utlity object")] float scoreThreshold = 0.2f;

	[Header("UI")]
	[SerializeField] AIUIMeter meter;


	public AIUtilityObject activeUtilityObject { get; set; } = null;

	// property to calculate and return agent's happiness level based on its needs
	public float happiness
	{
		get
		{
			// Total up total motives (desires) of all needs

			// Calculate happiness level based on the average fulfillment of needs
			// The lower the total motives (desires), the happier the agent
			// If the agent has a high amount of desires then they are unhappy (unfulfilled)
			return 0; // 1 - (divide total motives by number of needs to get average)
		}
	}

	private void OnValidate()
	{
		meter.text = "Happiness";
	}

	// initialize needs array if not assigned in the editor
	void Start()
	{
		needs ??= GetComponentsInChildren<AIUtilityNeed>();
	}
		
	void Update()
	{
		animator.SetFloat("Speed", movement.Velocity.magnitude);

		// check if not using utility object, if not look for one to use
		if (activeUtilityObject == null) 
		{ 
			var gameObjects = perception.GetGameObjects();

			// get utility objects
			var utilityObjects = gameObjects.GetComponents<AIUtilityObject>();

			// ** set active utility object to utility object with the hightest score **
			// iterate through utility objects
			//		if utility score is > score threshold and score is higher than currect active utility object
			//			set active utility object to utility object

			// start active utility object usage
			if (activeUtilityObject != null) 
			{
				StartCoroutine(UseUtilityCR(activeUtilityObject));
			}
		}
	}

	private void LateUpdate()
	{
		meter.value = happiness;
	}

	IEnumerator UseUtilityCR(AIUtilityObject utilityObject)
	{
		// move to utility position
		
		// wait until at destination position
		
		// play animation
		
		// wait duration
		
		// stop animation
		
		// apply utility
		ApplyUtility(utilityObject);

		// set active utility object to null (done using)
		activeUtilityObject = null;
		
		yield return null;
	}


	void ApplyUtility(AIUtilityObject utilityObject)
	{
		foreach (var effector in utilityObject.effectors)
		{
			AIUtilityNeed need = GetNeedByType(effector.type);
			if (need == null) continue;

			// apply effector change to input
		}
	}

	public float GetUtilityScore(AIUtilityObject utilityObject)
	{
		float score = 0;
		foreach (var effector in utilityObject.effectors)
		{
			AIUtilityNeed need = GetNeedByType(effector.type);
			if (need != null) 
			{
				float futureNeed = need.GetMotive(need.input + effector.change);
				score += need.motive - futureNeed;
			}
		}

		return score;
	}

	AIUtilityNeed GetNeedByType(AIUtilityNeed.Type type)
	{
		return needs.First(need => need.type == type);
	}
}
