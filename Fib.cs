using UnityEngine;
using System.Collections;

public class Fib : MonoBehaviour {

	UIMain AddResource;
	private GameObject MainCamera;


	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		AddResource = MainCamera.GetComponent<UIMain>();
		InvokeRepeating("Fiba",0,5f);
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	static int F(int n)
	{
		if( n<3 )
		{
			return 1;
		}
		else{
			return F(n-1)+F(n-2);
		}
	}

	void Fiba()
	{
		AddResource.Resource += F(15);
	}
}
