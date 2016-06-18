using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	private Transform Target;
	private Transform patrolPos;
	private NavMeshAgent NMA;
	public GameObject EnemyPatrolCenter;
	public GameObject Enemy;
	public GameObject Enemy1;
	public GameObject Enemy2;
	BotAI script;

	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		//patrolPos = GameObject.FindGameObjectWithTag("EnemyRadius").GetComponent<Transform>();
		NMA = (NavMeshAgent)this.GetComponent<NavMeshAgent>();
		script = Enemy.GetComponent<BotAI>();
		script = Enemy1.GetComponent<BotAI>();
		script = Enemy2.GetComponent<BotAI>();
	}
	
	// Update is called once per frame
	void Update () {
		if(script.StartPatrol == true)
		{
			NMA.SetDestination(EnemyPatrolCenter.transform.position);
		}
		else{
			NMA.SetDestination(Target.position);

		}
	
	}
}
