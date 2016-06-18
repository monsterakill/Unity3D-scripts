using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	private Transform Target;
	private NavMeshAgent NMA;

	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag("FinishPoint").GetComponent<Transform>();
		NMA = (NavMeshAgent)this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		NMA.SetDestination(Target.position);
	}
}
