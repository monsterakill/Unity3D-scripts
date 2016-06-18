using UnityEngine;
using System.Collections;

public class TowerBullet : MonoBehaviour {
	public float time = 0.001f;
	private float fade = 0.001f;

	public float BulletSpeed;
	//public bool dmg = false;
	//TurretAI TAi;
	// Use this for initialization
	void Start () {
		//TAi = GameObject.FindGameObjectWithTag("Tower").GetComponent<TurretAI>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Time.deltaTime*BulletSpeed*transform.forward;
		time -= Time.deltaTime;
		if(time < 0)
		{
			fade -= (Time.deltaTime / 1f);
			if(fade < 0)
			{
				Destroy(transform.gameObject);
			}
		}
	}
}
