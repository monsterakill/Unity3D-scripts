using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject enemyPrefab;
	private float spawnRate;
	private float enemyCount;
	public bool roundStart = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(roundStart)
		{
			enemyCount = Random.Range(15,25);
			spawnRate = Random.Range(0.2f,1.0f);
			InvokeRepeating("Spawn", spawnRate, spawnRate);
			roundStart = false;
		}
		if(enemyCount <= 0)
		{
			CancelInvoke("Spawn");
		}
	}
	void Spawn()
	{
		Instantiate(enemyPrefab, this.gameObject.transform.position, Quaternion.identity);
		enemyCount--;
	}
	public void RoundStart()
	{
		roundStart = true;
	}
}
