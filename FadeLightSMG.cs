using UnityEngine;
using System.Collections;

public class FadeLightSMG : MonoBehaviour {

	public GameObject fadeLightObj;
	private Renderer rendObj;
	public float FadeSpeed = 1;
	private Color ColorStart = Color.white;
	private Color ColorEnd = Color.blue;
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
			SMGGlobalAmmo AmmoCheck = GameObject.Find("SMGAmmoCheck").GetComponent<SMGGlobalAmmo>();
			float lerp = Mathf.PingPong(Time.time, FadeSpeed) / FadeSpeed;
			rendObj.materials[1].color = Color.Lerp(ColorStart,ColorEnd,lerp);

			if(Input.GetKeyDown(KeyCode.X) && CrossCheck.CanChange == false && CrossCheck.Gtemp == fadeLightObj)
			{
				AmmoCheck.globalAmmo++;
				Destroy(fadeLightObj);

			}
		}

	
	}
}
