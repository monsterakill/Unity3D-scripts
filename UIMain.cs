using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMain : MonoBehaviour {
	public float Resource = 0;
	public float CurrentOxygen = 100;
	public float CurrentArmor = 0;
	public float CurrentLead = 0;
	public float CurrentCarSpeed = 0;


	public float OxygenRatio;
	GameObject Player;
	public bool OxygenZoneCheck = true;


	GameObject MainUIResource;
	GameObject MainUIO2;
	GameObject MainUIArmor;
	GameObject MainUILeadM;
	GameObject MainUICarSpeed;
	public GameObject PickUpInfoObj;
	public GameObject MainUIAlert;

	Text CanvasTextMainUIResource;
	Text CanvasTextMainUIO2;
	Text CanvasTextMainUIArmor;
	Text CanvasTextMainUILeadM;
	Text CanvasTextMainUICarSpeed;

	public float Alertcooldown = 0.2f;
	public float PickUpInfoCooldown = 0.2f;
	float cooldownRemaining = 0;

	public bool OxygenRepairCheck = false;
	private bool StartCool = false;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		MainUIResource = GameObject.Find("MainUIResource");
		MainUIO2 = GameObject.Find("MainUIO2");
		MainUIArmor = GameObject.Find("MainUIArmor");
		MainUILeadM = GameObject.Find("MainUIResourceLead");
		MainUICarSpeed = GameObject.Find("MainUICarSpeed");
		CanvasTextMainUIResource = GameObject.Find("Current Resource Value").GetComponent<Text>();
		CanvasTextMainUIO2 = GameObject.Find("Current O2 Value").GetComponent<Text>();
		CanvasTextMainUIArmor = GameObject.Find("Current Armor Value").GetComponent<Text>();
		CanvasTextMainUILeadM = GameObject.Find("Current Lead Value").GetComponent<Text>();
		CanvasTextMainUICarSpeed = GameObject.Find("Current Car Speed Value").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		Oxygen();
		MainUI();
		Armor();
		OxygenRepair();
		PickUpInfo();

	}
	void MainUI()
	{
		if(MainUIResource != null)
		{
			CanvasTextMainUIResource.text = Resource.ToString();
		}
		if(MainUIO2 != null)
		{
			CanvasTextMainUIO2.text = CurrentOxygen.ToString("F2");
		}
		if(MainUIArmor != null)
		{
			CanvasTextMainUIArmor.text = CurrentArmor.ToString();
		}
		if(MainUILeadM != null)
		{
			CanvasTextMainUILeadM.text = CurrentLead.ToString();
		}
		if(MainUICarSpeed != null)
		{
			CanvasTextMainUICarSpeed.text = CurrentCarSpeed.ToString("F0");
		}
	}
	void Armor()
	{
		if(CurrentArmor < 0)
		{
			OxygenRatio = 1.6f;
			CurrentArmor = 0;
			
		}
		if(CurrentArmor >= 100)
		{
			CurrentArmor = 100;
			OxygenRatio = 0.4f;
			//Armor Max
		}
		if(OxygenRatio > 0.8f)
		{
			if(cooldownRemaining <=2)
			{
				MainUIAlert.SetActive(true);

			}
			if(cooldownRemaining <=1)
			{
				MainUIAlert.SetActive(false);
				
			}
			if(cooldownRemaining <= 0)
			{
				cooldownRemaining = Alertcooldown;
			}
		}
	}

	void Oxygen()
	{
		if(OxygenZoneCheck)
		{
			CurrentOxygen -= OxygenRatio*Time.deltaTime;
			if(CurrentOxygen <= 0)
			{
				Destroy(Player);
			}
		}
	}

	void OxygenRepair()
	{
		if(OxygenRepairCheck == true && OxygenRatio > 0.8f)
		{
			OxygenRatio = 0.8f;
			MainUIAlert.SetActive(false);
			OxygenRepairCheck = false;
		}
	}

	void PickUpInfo()
	{
		if(PickUpInfoObj.activeSelf)
		{
			StartCool = true;
		}
		if(StartCool)
		{
			if(cooldownRemaining <= 0)
			{
				cooldownRemaining = PickUpInfoCooldown;
			}
			if(cooldownRemaining <= 0.2f)
			{
				PickUpInfoObj.SetActive(false);
			}

		}
	}
}
