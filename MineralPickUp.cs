using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MineralPickUp : MonoBehaviour {

	public GameObject Mineral;
	GameObject MainCamera;
	CrossHair CrossCheck;
	UIMain AddMineral;
	MeshCollider MCollider;
	public GameObject Canvas;
	private bool StartPickUp = false;
	Slider Slider;



	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
		AddMineral = MainCamera.GetComponent<UIMain>();
		MCollider = this.GetComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == Mineral)
		{
			StartPickUp = true;
			Canvas.SetActive(true);
			Slider = GameObject.Find("ResourcePickUp").GetComponent<Slider>();
		}
		if(StartPickUp && Input.GetKey(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == Mineral)
		{
			Slider.value += 1;
		}
		if(StartPickUp && CrossCheck.CanChange != false && CrossCheck.Gtemp != Mineral)
		{
			StartPickUp = false;
			Slider.value = 0;
			Canvas.SetActive(false);
		}
		if(StartPickUp && Slider.value == 100)
		{
			AddMineral.CurrentLead += Random.Range(0,100);
			StartPickUp = false;
			Slider.value = 0;
			Canvas.SetActive(false);
			MCollider.enabled = false;
		}
		
	}
}
