using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float maxHealth = 250;
	public float currentHealth = 250;
	public float currentPercentHealth = 100;
	public float currentColorPercent = 255;
	public Color color = Color.green;
	// Use this for initialization
	public void ReceiveDamage(float damage){
		
		currentHealth-=damage;
		currentPercentHealth = currentHealth * 100 / maxHealth;
		currentColorPercent = (255 * currentPercentHealth / 255) / 100;
		if(currentHealth <= 0) Destroy(this.gameObject);
	}
	void Update(){
		color = this.gameObject.GetComponent<Renderer>().material.color;
		color.g = currentColorPercent;
		this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);


	}
}
