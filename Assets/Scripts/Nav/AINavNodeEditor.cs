using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class NavNodeEditor : MonoBehaviour
{
	[SerializeField] GameObject navNodePrefab;
	[SerializeField] LayerMask layerMask;

	private Vector3 position = Vector3.zero;
	private bool spawnable = false;
	private AINavNode navNode = null;
	private AINavNode activeNavNode = null;

	private bool active = false;
	private bool mousePressed = false;
	
	private void OnEnable()
	{
		if (!Application.isEditor)
		{
			Destroy(this);
		}
		SceneView.duringSceneGui += OnScene;
	}

	private void OnDisable()
	{
		SceneView.duringSceneGui -= OnScene;
	}


	void OnScene(SceneView scene)
	{
		Event e = Event.current;

		// set editor active when space is held down
		if (e.isKey && e.keyCode == KeyCode.Space)
		{
			if (e.type == EventType.KeyDown) active = true;
			if (e.type == EventType.KeyUp) active = false;
		}

		// return if not active, reset nodes
		if (!active)
		{
			navNode = null;
			activeNavNode = null;
			return;
		}

		// scene does not pass mouse up event, work around to get mouse up event type
		HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

		var controlID = GUIUtility.GetControlID(FocusType.Passive);
		var eventType = e.GetTypeForControl(controlID);

		// check for node or spawn ray hit
		if (e.isMouse && (e.type == EventType.MouseMove || e.type == EventType.MouseDrag))
		{
			// get scene mouse position
			Vector3 mousePosition = e.mousePosition;
			mousePosition.y = scene.camera.pixelHeight - mousePosition.y * EditorGUIUtility.pixelsPerPoint;
			mousePosition.x *= EditorGUIUtility.pixelsPerPoint;

			// compute ray from mouse position
			Ray ray = scene.camera.ScreenPointToRay(mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
			{
				position = hitInfo.point;
				// if not over node in scene, set spawnable to true
				spawnable = !(hitInfo.collider.gameObject.TryGetComponent<AINavNode>(out navNode));
				e.Use();
			}
			else
			{
				// if not over spawn or node layer then reset navNode
				navNode = null;
				spawnable = false;
			}
			
		}

		// check mouse down
		if (eventType == EventType.MouseDown)
		{
			// if spawnable, create nav node
			if (spawnable && navNode == null && activeNavNode == null)
			{
				Instantiate(navNodePrefab, position, Quaternion.identity, transform);
			}
			// if nav node is selected then set active nav node to nav node (used for connections)
			if (navNode != null && activeNavNode == null)
			{
				activeNavNode = navNode;
				navNode = null;
			}
			e.Use();
		}

		// check mouse up
		if (eventType == EventType.MouseUp)
		{
			// if there's an active node and over a different node, create connection
			if (activeNavNode != null && navNode != null && activeNavNode != navNode)
			{
				// connect from active nav node to nav node, if not already connected
				if (!activeNavNode.neighbors.Contains(navNode))
				{
					activeNavNode.neighbors.Add(navNode);
				}

				// connect from nav node to active nav node, if not already connected
				if (!navNode.neighbors.Contains(activeNavNode))
				{
					navNode.neighbors.Add(activeNavNode);
				}
			}
			activeNavNode = null;
			e.Use();
		}

		// delete nav node
		if (e.isKey && e.keyCode == KeyCode.Minus)
		{
			if (navNode != null)
			{
				DestroyImmediate(navNode.gameObject);
			}
			e.Use();
		}
	}

	private void OnDrawGizmos()
	{
		if (!active) return;
		

		if (spawnable && navNode == null)
		{
			Gizmos.color = Color.white;
			Gizmos.DrawWireSphere(position, 1);
		}
		if (navNode != null && navNode != activeNavNode)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(navNode.gameObject.transform.position, 1);
		}
		if (activeNavNode != null)
		{
			Gizmos.color = (navNode != null && activeNavNode != navNode) ? Color.green : Color.red;
			Gizmos.DrawWireSphere(activeNavNode.gameObject.transform.position, 1.5f);
			Gizmos.DrawLine(activeNavNode.gameObject.transform.position + Vector3.up, position + Vector3.up);
		}

		// draw connections
		var nodes = AINavNode.GetAINavNodes();
		foreach (AINavNode node in nodes)
		{
			foreach (AINavNode neighbors in node.neighbors)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(node.transform.position + Vector3.up, neighbors.transform.position + Vector3.up);
			}
		}

	}
}
