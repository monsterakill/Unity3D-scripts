using UnityEngine;
using System.Collections;

public class TransparentRoof : MonoBehaviour {

	public Material[] Transparent;
	public Material[] Normal;
	public MeshRenderer meshRend;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			meshRend.materials = Transparent;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			meshRend.materials = Normal;
		}
	}
}
