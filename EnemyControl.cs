using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float SpawnRate;
	private bool RoundStart = false;
	public float enemyCount = 30;
	private Text CurrentEnemy;
	private bool StartWave = true;
	private EnemyHealth enemyHealth;
	private Button StartWaveButton;
	// Use this for initialization
	void Start () {
		StartWaveButton = GameObject.Find("StartWaveBtn").GetComponent<Button>();
	}
	// Update is called once per frame
	void Update () {
		CurrentEnemy = GameObject.Find("CurrentEnemy").GetComponent<Text>();
		CurrentEnemy.text = enemyCount.ToString();
		if(RoundStart)
		{
			InvokeRepeating("Spawn",1f,SpawnRate);
			RoundStart = false;
			StartWave = false;
			StartWaveButton.interactable = false;
		}
		if(enemyCount <= 0)
		{
			CancelInvoke("Spawn");
			StartWave = true;
			StartWaveButton.interactable = true;
		}
	}
	void Spawn () {
		Instantiate(enemyPrefab,this.gameObject.transform.position,Quaternion.identity);
		/*enemyHealth = enemyPrefab.GetComponent<EnemyHealth>(); // Test Function Auto HP Increase
		enemyHealth.currentHealth += 5;
		enemyHealth.maxHealth += 5;*/
		enemyCount--;
	}
	public void StartNewWave()
	{
		if(StartWave)
		{
			RoundStart = true;
		}
		if(StartWave && enemyCount <= 0)
		{
			enemyCount = Random.Range(25,50);
		}
	}
}
