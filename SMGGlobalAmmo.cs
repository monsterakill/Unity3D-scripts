using UnityEngine;
using System.Collections;

public class SMGGlobalAmmo : MonoBehaviour {

	public float globalAmmo = 5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject Pistol = GameObject.Find("SMGOff");

		if(Pistol != null)
		{
			SMG Shoot = GameObject.Find("SShooT").GetComponent<SMG>();
			Shoot.Holders = globalAmmo;
		}
	
	}
}
