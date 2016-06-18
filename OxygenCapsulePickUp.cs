using UnityEngine;
using System.Collections;

public class OxygenCapsulePickUp : MonoBehaviour {

	public GameObject OxygenCapsule;
	GameObject MainCamera;
	CrossHair CrossCheck;
	//UIMain AddOxygen;
	//BoxCollider BCollider;
	Inventory InventoryItem;




	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
		//AddOxygen = MainCamera.GetComponent<UIMain>();
		//BCollider = this.GetComponent<BoxCollider>();

	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X) && CrossCheck.CanChange == false && CrossCheck.Gtemp == OxygenCapsule)
		{
			InventoryItem = MainCamera.GetComponent<Inventory>();
			InventoryItem.ConsumableItemH2OV2();
			Destroy(OxygenCapsule);
		}
	
	}
}
