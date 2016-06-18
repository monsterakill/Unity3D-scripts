using UnityEngine;
using System.Collections;

public class OxygenZoneForSphere : MonoBehaviour {
	GameObject MainCamera;
	UIMain OxygenVariable; 
	public AudioClip OxygenMaskOff;
	public AudioClip OxygenMaskOn;
	public AudioSource PlayerSource;
	private GameObject Storm;
	private bool triggered = true;
	public GameObject Sphere;
	public GameObject OZMain;

	public float ShieldCooldown = 0.2f;
	float cooldownRemaining = 0;

	//private bool AutoSwitch = false;

	ShieldControlPanel SCP;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		OxygenVariable = MainCamera.GetComponent<UIMain>();
		Storm = GameObject.FindGameObjectWithTag("SandStorm");
		SCP = GameObject.Find("ShieldControlPanel").GetComponent<ShieldControlPanel>();

		
	}
	
	// Update is called once per frame
	void Update () {	
		cooldownRemaining -= Time.deltaTime;
		if(!Sphere.activeSelf && triggered)
		{

			triggered = false;
			OZMain.SetActive(true);
			OxygenVariable.OxygenZoneCheck = true;
			Storm.SetActive(true);
			if(PlayerSource.clip != OxygenMaskOn)
			{
				PlayerSource.clip = OxygenMaskOn;
				PlayerSource.loop = true;
				PlayerSource.Play();
			}
		}
		if(Sphere.activeSelf)
		{
			cooldownRemaining = ShieldCooldown;
			triggered = true;
		}

		if(!Sphere.activeSelf && cooldownRemaining <= 0)
		{
			SCP.ShieldOn();
		}
	} 
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			OZMain.SetActive(false);
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
