using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters;
using System.Reflection;
using UnityEngine.UI;


public class MonitorPanel : MonoBehaviour {
	public AudioClip mySound;
	public AudioSource mySource;
	public GameObject Monitor;
	FirstPersonController FPSController;
	private GameObject Player;
	CrossHair CrossCheck;
	UIMain AddResource;
	private GameObject MainCamera;
	public GameObject UpgradeButton;
	public GameObject UpgradeMenu;
	public GameObject CraftButton;
	public GameObject CraftMenu;
	public Text CanvasText;
	Text RunSpeedCost;
	Text JumpCost;
	Text RandomEffectCost;
	Text ArmorCost;
	private float AC;
	GameObject Pistol;

	Inventory InventoryItem;


	GameObject SMG_Receiver;
	GameObject SMG_Barrel;
	GameObject SMG_Stock;
	Button SMGCraftButton;

	Image SMGPart1Canvas;
	Image SMGPart2Canvas;
	Image SMGPart3Canvas;
	

	public Sprite StockSprite;
	public Sprite BarrelSprite;
	public Sprite ReceiverSprite;

	WeaponSwitch WeaponSwitch;
	private bool ButtonLock = false;
	Text CanvasTextMainUIPickedItemInfo;
	public GameObject PickedItemCanvas;





	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
		Player = GameObject.FindWithTag("Player");
		FPSController = Player.GetComponent<FirstPersonController>();
		AddResource = MainCamera.GetComponent<UIMain>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == Monitor)
		{
			Pistol = GameObject.FindGameObjectWithTag("HideGun");
			mySource.PlayOneShot(mySound);
			CrossCheck.enabled = false;
			FPSController.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			if(Pistol != null) Pistol.SetActive(false);
			UpgradeButton.SetActive(true);
			CraftButton.SetActive(true);
		}
		if(UpgradeButton != null)
		{
			CanvasText.text = AddResource.Resource.ToString();
		}
		//SMGPartsCheck();
	}
	public void CanvasOff()
	{
		CrossCheck.enabled = true;
		FPSController.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if(Pistol != null) Pistol.SetActive(true);
		UpgradeMenu.SetActive(false);
		CraftMenu.SetActive(false);
	}
	public void RandomEffect()
	{
		RandomEffectCost = GameObject.Find("RandomEffectCost").GetComponent<Text>();
		float REC = float.Parse(RandomEffectCost.text.ToString());
		if(AddResource.Resource >= REC && AddResource.OxygenRatio > 0.8f)
		{
			AddResource.Resource -= REC;
			AddResource.OxygenRepairCheck = true;
		}
	}
	public void ArmorBuy()
	{
		ArmorCost = GameObject.Find("ArmorCost").GetComponent<Text>();
		float AC = float.Parse(ArmorCost.text.ToString());
		if(AddResource.Resource >= AC && AddResource.CurrentArmor <= 100)
		{
			AddResource.Resource -= AC;
			AddResource.CurrentArmor += 10;
		}
	}
	public void RunSpeedUp()
	{
		RunSpeedCost = GameObject.Find("RunSpeedCost").GetComponent<Text>(); 
		float RSC = float.Parse(RunSpeedCost.text.ToString());
		if(AddResource.Resource >= RSC)
		{
			AddResource.Resource -= RSC;
			FPSController.RunSpeed += 0.2f;

		}
	}
	public void JumpSpeedUp()
	{
		JumpCost = GameObject.Find("JumpCost").GetComponent<Text>();
		float JC = float.Parse(JumpCost.text.ToString());
		if(AddResource.Resource >= JC)
		{
			AddResource.Resource -= JC;
			FPSController.JumpSpeed += 0.2f;

		}
	}
	public void UpgradeMenuShow()
	{
		UpgradeMenu.SetActive(true);
		UpgradeButton.SetActive(false);
		CraftButton.SetActive(false);
	}
	public void CraftMenuShow()
	{
		CraftMenu.SetActive(true);
		CraftButton.SetActive(false);
		UpgradeButton.SetActive(false);
		SMG_Receiver = GameObject.Find("SMG Receiver");
		SMG_Barrel = GameObject.Find("SMG Barrel");
		SMG_Stock = GameObject.Find("SMG Stock");
		if(SMG_Stock == null)
		{
			SMGPart1Canvas = GameObject.Find("SMGPart1").GetComponent<Image>();
			SMGPart1Canvas.sprite = StockSprite;
		}

		if(SMG_Barrel == null)
		{
			SMGPart2Canvas = GameObject.Find("SMGPart2").GetComponent<Image>();
			SMGPart2Canvas.sprite = BarrelSprite;
		}

		if(SMG_Receiver == null)
		{
			SMGPart3Canvas = GameObject.Find("SMGPart3").GetComponent<Image>();
			SMGPart3Canvas.sprite = ReceiverSprite;
		}

		if(SMG_Receiver == null && SMG_Barrel == null && SMG_Stock == null && ButtonLock == false)
		{
			SMGCraftButton = GameObject.Find("CraftButton").GetComponent<Button>();
			SMGCraftButton.interactable = true;
			ButtonLock = true;
		}
	}
	public void SMGCraft()
	{
		PickedItemCanvas.SetActive(true);
		CanvasTextMainUIPickedItemInfo = GameObject.Find("PickedItemInfo").GetComponent<Text>();
		SMGCraftButton = GameObject.Find("CraftButton").GetComponent<Button>();
		WeaponSwitch = MainCamera.GetComponent<WeaponSwitch>();
		CanvasTextMainUIPickedItemInfo.text = "SMG";
		WeaponSwitch.HaveSMG = true;
		SMGCraftButton.interactable = false;
	}
}
