using UnityEngine;
using System.Collections;

public class DetonatesOnHit : MonoBehaviour {

	public GameObject explosionPrefab;

	public float damage = 200f; //damage on center of expl
	public float explosionRadius = 6f;

	public Vector3 detonationPoint;

	void OnCollisionEnter(){
		Debug.Log ("OnCollisionEnter: ");
		Detonate ();
	}
	void OnTriggerEnter(){
		Debug.Log ("OnTriggerEnter: ");
		Detonate ();
	}

	/*void FixedUpdate(){
				Ray ray = new Ray (transform.position, transform.forward);
				if (Physics.Raycast (ray, speed * Time.deltaTime)) {
						Detonate ();
				}
		}*/

	void Detonate(){
		Vector3 explosionPoint = transform.position + detonationPoint;

		if(explosionPrefab != null){
			Instantiate(explosionPrefab, explosionPoint,Quaternion.identity);
		}
		Destroy (gameObject);

		Collider[] colliders = Physics.OverlapSphere (explosionPoint, explosionRadius);

		foreach( Collider c in colliders){
			//Health h = c.GetComponent<Health>();
			//if(h != null){
				//float dist = Vector3.Distance (explosionPoint, c.transform.position);
				//float damageRation = 1.2f - (dist / explosionRadius);

				//h.ReceiveDamage(damage * damageRation);

		}
	}
}
