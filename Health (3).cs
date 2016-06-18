using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float hitPoints = 100f;

	public void ReceiveDamage(float AMT){
		Debug.Log ("ReceiveDamage: " + AMT);
		hitPoints -= AMT;
		if (hitPoints <= 0) {
			Explode ();
		}
	}

	void Explode (){
		Destroy (gameObject);
	}
}
