using UnityEngine;
using System.Collections;

public class VentRot : MonoBehaviour {
	public GameObject Base;
	// Use this for initialization
	void Start () {
		Base.GetComponent<Animation>().Blend("VentRotate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
