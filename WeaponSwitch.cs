using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

	public GameObject Pistol;
	public GameObject SMG;
	public bool HavePistol = true;
	public bool HaveSMG = false;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1) && HavePistol == true)
		{
			Pistol.SetActive(true);
			SMG.SetActive(false);



		}
		if(Input.GetKeyDown(KeyCode.Alpha2) && HaveSMG == true)
		{
			SMG.SetActive(true);
			Pistol.SetActive(false);
			
		}
	}
}
