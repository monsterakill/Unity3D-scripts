using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	
	public float currentHealth = 100;
	public float maxHealth = 100;
	private Renderer rend;
	private float mainColor;
	public Color MinDamageColor = Color.green;
	public Color MaxDamageColor = Color.red;
	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer>();
		if (maxHealth < 1) maxHealth = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0)
		{
			InstatiateObjectOnClick IOOC = GameObject.Find("Main Camera").GetComponent<InstatiateObjectOnClick>();
			IOOC.Money += 15;
			Destroy(gameObject,1.0f);
		}
		rend.material.color = Color.Lerp(MaxDamageColor, MinDamageColor, currentHealth / maxHealth);

	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "TowerBullet")
		{
			this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
			Debug.Log("hit");
			Destroy(other.gameObject, 0.3f);
		}
	}

}
