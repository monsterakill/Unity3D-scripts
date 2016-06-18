using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InstatiateObjectOnClick : MonoBehaviour {

	private Text CurrentMoney;
	public float Money = 0;
	public GameObject Tower1;
	public GameObject Tower2;
	private bool BuyTowerV1 = false;
	private bool BuyTowerV2 = false;
	
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		CurrentMoney = GameObject.Find("CurrentMoney").GetComponent<Text>();
		CurrentMoney.text = Money.ToString();
		if(Input.GetKeyDown(KeyCode.Mouse0) && BuyTowerV1 == true)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit) && hit.collider.tag == "TowerPlace")
			{
				GameObject childObject = Instantiate(Tower1,hit.transform.position,Quaternion.identity) as GameObject;
				childObject.transform.parent = hit.transform;
				//Instantiate(Tower1,hit.point,Quaternion.identity);
				Money -= 15;
				BuyTowerV1 = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Mouse0) && BuyTowerV2 == true)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit) && hit.collider.tag == "TowerPlace")
			{
				Instantiate(Tower2,hit.point,Quaternion.identity);
				Money -= 30;
				BuyTowerV2 = false;
			}
		}
	

	}
	public void BuyTowerV1Func()
	{
		if(Money >= 15)
		{
			BuyTowerV1 = true;
		}
	}
	public void BuyTowerV2Func()
	{
		if(Money >= 30)
		{
			BuyTowerV2 = true;
		}
	}

}
