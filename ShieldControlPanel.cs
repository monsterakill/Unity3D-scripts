using UnityEngine;
using System.Collections;

public class ShieldControlPanel : MonoBehaviour {


	public GameObject ShieldControlPanelObj;
	public GameObject ShieldGenerator;
	GameObject MainCamera;
	CrossHair CrossCheck;
	Animation Anim;
	public GameObject ShieldSphere;
	private bool AnimPlay;
	AudioSource Audio;





	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
		Anim = ShieldGenerator.GetComponent<Animation>();
		Audio = ShieldGenerator.GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == ShieldControlPanelObj)
		{
			if(!ShieldSphere.activeSelf)
			{
				ShieldOn();
			}else{
				ShieldOff();
			}
		}
	}
	public void ShieldOn()
	{
		Anim.Play();
		ShieldSphere.SetActive(true);
		Audio.enabled = true;
		Audio.Play();
	}
	public void ShieldOff()
	{
		Anim.Stop();
		ShieldSphere.SetActive(false);
		Audio.enabled = false;
		Audio.Stop();
	}
}
