using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarEnter : MonoBehaviour {

	private bool c_Enter = false;
	private GameObject c_Main;
	private GameObject m_Camera;
	private GameObject c_Camera;
	private GameObject Player;
	private GameObject Arms;
	UIMain CarSpeed;
	private bool c_SpeedOn = false;
	private bool c_InCar = false;
	// Use this for initialization
	void Start () {
		c_Main = GameObject.FindGameObjectWithTag("Car");
		m_Camera = GameObject.FindGameObjectWithTag("MainCamera");
		c_Camera = GameObject.Find("CarCam");
		Player = GameObject.FindGameObjectWithTag("Player");
		Arms = GameObject.Find("ArmsV2");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(c_SpeedOn)
		{

			CarSpeed.CurrentCarSpeed = c_Main.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;

		}


		if(Input.GetKeyDown(KeyCode.E) && c_Enter)
		{
			StartCoroutine(WaitTimeEnter(2.0f));
		}
		if(Input.GetKeyDown(KeyCode.E) && c_InCar)
		{
			StartCoroutine(WaitTimeExit(2.0f));   // Setting car stop after player leave
		}

	
	}

	IEnumerator WaitTimeEnter(float waitTime)
	{
		c_Enter = false;
		CarSpeed = m_Camera.GetComponent<UIMain>();
		c_Main.GetComponent<Rigidbody>().isKinematic = false;
		c_Main.GetComponent<CarMain>().enabled = true;
		m_Camera.GetComponent<CrossHair>().crossHair_Enable = false;
		m_Camera.GetComponent<Camera>().enabled = false;
		Player.GetComponent<CharacterController>().enabled = false;
		Arms.SetActive(false);
		Player.transform.position = c_Main.transform.position;
		Player.transform.SetParent(c_Main.transform);
		c_Camera.GetComponent<Camera>().enabled = true;
		yield return new WaitForSeconds(waitTime);
		c_SpeedOn = true;
		c_InCar = true;
		c_Main.GetComponent<CarMain>().maxTorque = 450f;
	}

	IEnumerator WaitTimeExit(float waitTime)
	{
		c_Main.GetComponent<Rigidbody>().isKinematic = true;
		c_Main.GetComponent<CarMain>().enabled = false;
		c_Main.GetComponent<CarMain>().maxTorque = 0f;
		m_Camera.GetComponent<CrossHair>().crossHair_Enable = true;
		c_Camera.GetComponent<Camera>().enabled = false;
		Player.GetComponent<CharacterController>().enabled = true;
		Arms.SetActive(true);
		Player.transform.parent = null;
		m_Camera.GetComponent<Camera>().enabled = true;
		yield return new WaitForSeconds(waitTime);
		c_SpeedOn = false;
		c_InCar = false;
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			c_Enter = true;
		}

	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			c_Enter = false;
			
		}
	}
}
