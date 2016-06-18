using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SMGParts : MonoBehaviour {

	public GameObject SMGPart;
	GameObject MainCamera;
	CrossHair CrossCheck;
	//UIMain AddMineral;
	//BoxCollider BCollider;
	public GameObject Canvas;
	Inventory InventoryItem;
	public Sprite SMG_Stock;
	public Sprite SMG_Barrel;
	public Sprite SMG_Receiver;

	Text CanvasTextMainUIPickedItemInfo;
	Image CanvasImageMainUIPickItemImage;


	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();

		//AddMineral = MainCamera.GetComponent<UIMain>();
		//BCollider = SMGPart.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == SMGPart)
		{
			Canvas.SetActive(true);
			CanvasTextMainUIPickedItemInfo = GameObject.Find("PickedItemInfo").GetComponent<Text>();
			CanvasImageMainUIPickItemImage = GameObject.Find("PickedItemInfoImage").GetComponent<Image>();
			if(SMGPart.name == "SMG Stock")
			{
				InventoryItem = MainCamera.GetComponent<Inventory>();
				InventoryItem.QuestItemSMGStock();
				CanvasImageMainUIPickItemImage.sprite = SMG_Stock;
				CanvasTextMainUIPickedItemInfo.text = SMGPart.name;
				Destroy(SMGPart);
			}
			if(SMGPart.name == "SMG Barrel")
			{
				InventoryItem = MainCamera.GetComponent<Inventory>();
				InventoryItem.QuestItemSMGBarrel();
				CanvasImageMainUIPickItemImage.sprite = SMG_Barrel;
				CanvasTextMainUIPickedItemInfo.text = SMGPart.name;
				Destroy(SMGPart);
			}
			if(SMGPart.name == "SMG Receiver")
			{
				InventoryItem = MainCamera.GetComponent<Inventory>();
				InventoryItem.QuestItemSMGReceiver();
				CanvasImageMainUIPickItemImage.sprite = SMG_Receiver;
				CanvasTextMainUIPickedItemInfo.text = SMGPart.name;
				Destroy(SMGPart);
			}
		}
	}
}
