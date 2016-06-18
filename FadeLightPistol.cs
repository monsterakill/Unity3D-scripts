using UnityEngine;
using System.Collections;

public class FadeLightPistol : MonoBehaviour {

	public GameObject fadeLightObj;
	private Renderer rendObj;
	public float FadeSpeed = 1;
	private Color ColorStart = Color.white;
	private Color ColorEnd = Color.green;
	private CrossHair CrossCheck;
	private GameObject MainCamera;
	private Pistol p_Script;
	//private GameObject HideGun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeLightObj.activeSelf == true)
		{
			MainCamera = GameObject.FindWithTag("MainCamera");
			CrossCheck = MainCamera.GetComponent<CrossHair>();
			rendObj = fadeLightObj.GetComponent<Renderer>();
			PistolGlobalAmmo AmmoCheck = GameObject.Find("PistolAmmoCheck").GetComponent<PistolGlobalAmmo>();
			float lerp = Mathf.PingPong(Time.time, FadeSpeed) / FadeSpeed;
			rendObj.materials[1].color = Color.Lerp(ColorStart,ColorEnd,lerp);

			if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == fadeLightObj)
			{
				AmmoCheck.globalAmmo++;
				Destroy(fadeLightObj);

			}
		}

	
	}
}
