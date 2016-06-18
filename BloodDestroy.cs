using UnityEngine;
using System.Collections;

public class BloodDestroy : MonoBehaviour {

	public float destroyTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(this.gameObject, destroyTime);
	
	}
}
