// MoveDestination.cs
using UnityEngine;

public class MoveDestination : MonoBehaviour {
	
	public Transform goal;
	public Transform centerWaypoint;
	BotAi scriptBotAi;
	void Start () {
		scriptBotAi = this.GetComponent<BotAi>();
	}
	void Update () {
		if(scriptBotAi.startPatrol == true)
		{
			NavMeshAgent agent = GetComponent<NavMeshAgent>();
			agent.destination = centerWaypoint.transform.position;
		}
		else{
			NavMeshAgent agent = GetComponent<NavMeshAgent>();
			agent.destination = goal.position; 
		}
	}
}