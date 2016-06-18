using UnityEngine;
using System.Collections;

public class PistolGlobalAmmo : MonoBehaviour {

	public float globalAmmo = 5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject Pistol = GameObject.Find("PistolOff");

		if(Pistol != null)
		{
			Pistol Shoot = GameObject.Find("PShooT").GetComponent<Pistol>();
			Shoot.Holders = globalAmmo;
		}
	
	}
}
