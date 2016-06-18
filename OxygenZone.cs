using UnityEngine;
using System.Collections;

public class OxygenZone : MonoBehaviour {
	GameObject MainCamera;
	UIMain OxygenVariable; 
	public AudioClip OxygenMaskOff;
	public AudioClip OxygenMaskOn;
	public AudioSource PlayerSource;
	private GameObject Storm;
	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		OxygenVariable = MainCamera.GetComponent<UIMain>();
		Storm = GameObject.FindGameObjectWithTag("SandStorm");
	
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag == "Player")
		{
			OxygenVariable.OxygenZoneCheck = false;
			Storm.SetActive(false);
			PlayerSource.clip = OxygenMaskOff;
			PlayerSource.loop = false;
			PlayerSource.Play();
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			OxygenVariable.OxygenZoneCheck = true;
			Storm.SetActive(true);
			PlayerSource.clip = OxygenMaskOn;
			PlayerSource.loop = true;
			PlayerSource.Play();
		}
	}
}
