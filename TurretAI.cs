using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretAI : MonoBehaviour {

	public GameObject currentTarget;

	public float attackMinDistance;
	public float attackMaxDistance;
	public float attackDamage;
	public float reloadTime;
	public float reloadTimeConst;
	public float towerRotationSpeed;

	public Transform towerHead;
	public RaycastHit Hit;

	private EnemyHealth enemyHealth;

	public GameObject BulletPrefab;
	public GameObject go;

	TowerBullet TB;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTarget != null)
		{
			float distance = Vector3.Distance(towerHead.position, currentTarget.transform.position);
			Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
			Debug.DrawRay(towerHead.position,forward,Color.green);
			if (attackMinDistance < distance && distance < attackMaxDistance)
			{
				//transform.LookAt(currentTarget.transform);
				towerHead.rotation = Quaternion.Slerp(towerHead.rotation, Quaternion.LookRotation(currentTarget.transform.position - towerHead.position), towerRotationSpeed * Time.deltaTime);
				//towerHead.rotation = Quaternion.LookRotation(currentTarget.transform.position - towerHead.position);
				//towerHead.rotation = Quaternion.Euler(new Vector3(0f, towerHead.rotation.eulerAngles.y, 0f));
				if (reloadTime > 0) reloadTime -= Time.deltaTime;
				if (reloadTime < 0) reloadTime = 0;
				if (reloadTime == 0)
				{
					Shoot();
					Debug.Log("Shoot");
					reloadTime = reloadTimeConst;

				}

			}
			if(distance > attackMaxDistance) currentTarget = null;
		}

		else{
			currentTarget = SortTargets();
		}
	}
	public GameObject SortTargets()
	{
		float closestMobDistance = 0; 
		GameObject nearestmob = null; 
		List<GameObject> sortingMobs = new List<GameObject>();
		sortingMobs.AddRange(GameObject.FindGameObjectsWithTag("Enemy")); 
		foreach (var everyTarget in sortingMobs) 
		{
			if ((Vector3.Distance(everyTarget.transform.position, towerHead.position) < closestMobDistance) || closestMobDistance == 0)
			{
				closestMobDistance = Vector3.Distance(everyTarget.transform.position, towerHead.position); 
				nearestmob = everyTarget;
			}
		}

		return closestMobDistance > attackMaxDistance ? null : nearestmob;
	}
	void Shoot()
	{
		Ray ray = new Ray (transform.position+transform.forward, transform.forward);
		RaycastHit hitInfo;
		
		if (Physics.Raycast (ray, out hitInfo, 10.0f)) 
		{
			Vector3 hitPoint = hitInfo.point;
			go = hitInfo.collider.gameObject;
			Debug.Log ("Hit Object: " + go.name);
			Debug.Log ("Hit Point: " + hitPoint);
			if (BulletPrefab != null) 
			{
				Instantiate (BulletPrefab, transform.position + 0.1f * transform.forward, transform.rotation);
			}
			if(hitInfo.collider.CompareTag("Enemy") && go == currentTarget)
			{
				enemyHealth = currentTarget.GetComponent<EnemyHealth>();
				enemyHealth.currentHealth -= attackDamage;
			}
		}
	}

}
