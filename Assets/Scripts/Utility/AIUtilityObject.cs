using System.Collections.Generic;
using UnityEngine;

public class AIUtilityObject : MonoBehaviour
{
	[System.Serializable]
	public class Effector
	{
		public AIUtilityNeed.Type type;
		[Range(-2, 2)] public float change;
	}

	[Header("Parameters")]
	[SerializeField] public Effector[] effectors;
	[SerializeField, Tooltip("Time to use object")] public float duration;
	[SerializeField, Tooltip("Animation to play when using")] public string animationName;

	[SerializeField] public Transform target;

	[Header("UI")]
	[SerializeField, Tooltip("Radius to detect agent")] float radius = 5;
	[SerializeField] LayerMask agentLayerMask;
	[SerializeField] AIUIMeter meterPrefab;
	[SerializeField] Vector3 meterOffset;

	public float score { get; set; }

	AIUIMeter meter;
	Dictionary<AIUtilityNeed.Type, float> registry = new Dictionary<AIUtilityNeed.Type, float>();

	void Start()
	{
		// create meter ui at run-time
		meter = Instantiate(meterPrefab, GameObject.Find("Canvas").transform);

		// set meter
		meter.name = name;
		meter.text = name;
		meter.position = transform.position + meterOffset;

		// set effectors array into dictionary
		foreach (var effector in effectors) 
		{
			registry[effector.type] = effector.change;
		}
	}

	private void Update()
	{
		meter.visible = false; // hide meter by default

		// show object meter if near agent
		var colliders = Physics.OverlapSphere(transform.position, radius, agentLayerMask);
		if (colliders.Length > 0)
		{
			// check colliders for utility agent 
			foreach (var collider in colliders)
			{
				if (collider.TryGetComponent(out AIUtilityAgent agent))
				{
					// set meter alpha based on distance to agent (fade-in)
					//float distance = 1 - Vector3.Distance(agent.transform.position, transform.position) / radius;
					score = agent.GetUtilityScore(this);
					meter.alpha = 0.25f;
					meter.visible = true;
				}
			}
		}
	}

	void LateUpdate()
	{
		meter.value = score;
		meter.position = transform.position + meterOffset;
	}

	public float GetNeedChange(AIUtilityNeed.Type type)
	{
		return registry.TryGetValue(type, out float value) ? value : 0f;
	}

	public bool HasNeedType(AIUtilityNeed.Type type)
	{
		return registry.ContainsKey(type);
	}
}
