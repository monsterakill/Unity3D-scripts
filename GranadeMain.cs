using UnityEngine;
using System.Collections;

public class GranadeMain : MonoBehaviour {

	public GameObject GranadePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G)) 
		{
			Instantiate (GranadePrefab, transform.position + transform.forward, transform.rotation);		
		}
	}
}
