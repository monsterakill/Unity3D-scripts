using UnityEngine;
using System.Collections;

public class BotAI : MonoBehaviour {
	
	private Transform Target;
	Vector3 PlayerTransform;
	RaycastHit EnemyRay;
	public bool StartPatrol = false;
	public Transform[] Points;
	public float Speed = 0.0f, Distance = 0.0f;
	public float RotSpeed = 5.0f;
	private int _currentPoint;

	UIMain AddResource;
	private GameObject MainCamera;
	public float Attackcooldown = 0.2f;
	float cooldownRemaining = 0;

	// Use this for initialization
	void Start (){
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		this.GetComponent<Navigation>().enabled = false;
		this.GetComponent<NavMeshAgent>().enabled = false;

		MainCamera = GameObject.FindWithTag("MainCamera");
		AddResource = MainCamera.GetComponent<UIMain>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldownRemaining -= Time.deltaTime;
		PlayerTransform = Target.transform.position - transform.position;
		PlayerTransform.y = 0;
		chase();
		patrol();
	}
	void chase()
	{
		if(Vector3.Distance(transform.position, Target.position) <= 25.0f)
		{
			this.GetComponent<Navigation>().enabled = true;
			this.GetComponent<NavMeshAgent>().enabled = true;
			StartPatrol = false;
			//Debug.Log("StartFollow");
			if(Vector3.Distance(transform.position, Target.position) <= 2.0f && cooldownRemaining <=0)
			{
					//Debug.Log("Attack");
					AddResource.CurrentArmor -= Random.Range(1,3);
					cooldownRemaining = Attackcooldown;
			}
		}else{
			//Debug.Log("PlayerDistanceRangeTooFar");
			patrol();
			StartPatrol = true;

		}
	}
	void patrol()
	{
		if(StartPatrol)
		{
			if(_currentPoint == Points.Length) _currentPoint = 0;

			float _currentDistance = Vector3.Distance(transform.position, Points[_currentPoint].position);
			Quaternion targetRotation = Quaternion.LookRotation(Points[_currentPoint].position - transform.position);
			if(_currentDistance <= 15)
			{
				this.GetComponent<Navigation>().enabled = false;
				this.GetComponent<NavMeshAgent>().enabled = false;
			}
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotSpeed * Time.deltaTime);
			transform.position += transform.forward * Speed * Time.deltaTime;
			
			if(_currentDistance <= Distance) _currentPoint = Random.Range(0,4);

		}

	}
}
