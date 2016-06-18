using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasAmmo : MonoBehaviour {

	Text canvasAmmo;
	M4A1 weaponScript;
	// Use this for initialization
	void Start () {
		canvasAmmo = GameObject.Find("Ammo").GetComponent<Text>();
		weaponScript = GameObject.Find("m4A1").GetComponent<M4A1>();
	}
	
	// Update is called once per frame
	void Update () {
		canvasAmmo.text = weaponScript.currentbulletsInHolder.ToString() + "/" + weaponScript.allBullets.ToString();
	}
}
