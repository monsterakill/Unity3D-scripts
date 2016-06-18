using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour {
	public float speed =20f;


	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (transform.forward * speed * Time.deltaTime,Space.World);
	
	}
}
