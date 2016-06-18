using UnityEngine;
using System.Collections;

public class PlayerFlowers : MonoBehaviour {

	public int flower;
	public int money;
	//public bool pick = true;

	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		Inventory Quest = GetComponent<Inventory>();
		if(flower != 0)
		{
			Quest.QuestItemFlowerLeaf();
			flower = 0;


		}
	
	}
}
