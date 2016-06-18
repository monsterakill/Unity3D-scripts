using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {
	public GameObject Sun;
	public float DirLightRotSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Quaternion rot = DirLight.transform.localRotation;
		//DirLightRot = DirLightRotSpeed*Time.deltaTime;
		Sun.transform.Rotate(DirLightRotSpeed*Time.deltaTime,0,0);

	}
}
