using UnityEngine;
using System.Collections;

public class BotAi : MonoBehaviour {
	Transform Target;
	public float Attackcooldown = 0.2f;
	float cooldownRemaining = 0;
	public bool followPlayer = true;
	public bool startPatrol = true;
	public Transform[] wayPoints;
	private int currentPoint;
	public float patrolRotateSpeed = 1;
	public float patrolWalkSpeed = 1;
	Animator animator;
	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		if(Vector3.Distance(transform.position, Target.position) <= 25.0f)
		{
			animator.SetFloat("Walk", 0f);
			this.GetComponent<MoveDestination>().enabled = true;
			this.GetComponent<NavMeshAgent>().enabled = true;
			startPatrol = false;
			//Debug.Log("StartFollow");
			if(Vector3.Distance(transform.position, Target.position) <= 2.0f && cooldownRemaining <=0)
			{
				//Debug.Log("Attack");
				cooldownRemaining = Attackcooldown;
			}
		}else{
			//Debug.Log("PlayerDistanceRangeTooFar");
			animator.SetFloat("Walk", 1.0f);
			startPatrol = true;
			
		}

		if(startPatrol)
		{
			if(currentPoint == wayPoints.Length) currentPoint = 0;

			float _currentDistance = Vector3.Distance(transform.position, wayPoints[currentPoint].position);
			Quaternion targetRotation = Quaternion.LookRotation(wayPoints[currentPoint].position - transform.position);
			if(_currentDistance <= 15)
			{
				this.GetComponent<MoveDestination>().enabled = false;
				this.GetComponent<NavMeshAgent>().enabled = false;
			}
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, patrolRotateSpeed * Time.deltaTime);
			transform.position += transform.forward * patrolWalkSpeed * Time.deltaTime;
			
			if(_currentDistance <= 1) currentPoint = Random.Range(0,4);
			
		}
	}
}
