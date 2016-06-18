using UnityEngine;
using System.Collections;

public class ControlPanel : MonoBehaviour {

	public AudioClip mySound;
	public AudioSource mySource;
	public GameObject Base;
	CrossHair CrossCheck;
	private GameObject MainCamera;
	public GameObject controlPanel;

	private GameObject ControlPanelStateOpen;

	private Renderer rendCPSO;

	public float FadeSpeed = 1;
	private Color ColorStart = Color.white;
	private Color ColorEnd = Color.green;
	private Color ColorEnd2 = Color.red;
	private Color ColorEnd3 = Color.blue;

	public bool DoorOpenState;
	public bool DoorCloseState;
	public bool DoorNeedKeyState;

	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
		ControlPanelStateOpen = controlPanel.transform.FindChild("ControlPanelStateOpen").gameObject;

		rendCPSO = ControlPanelStateOpen.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(DoorOpenState)
		{
			float lerp = Mathf.PingPong(Time.time, FadeSpeed) / FadeSpeed;
			rendCPSO.material.color = Color.Lerp(ColorStart,ColorEnd,lerp);
			if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == controlPanel)
			{
				mySource.PlayOneShot(mySound);
				Base.GetComponent<Animation>().Blend("DoorOpen");
			}
		}
		if(DoorCloseState)
		{
			float lerp = Mathf.PingPong(Time.time, FadeSpeed) / FadeSpeed;
			rendCPSO.material.color = Color.Lerp(ColorStart,ColorEnd2,lerp);

		}
		if(DoorNeedKeyState)
		{
			float lerp = Mathf.PingPong(Time.time, FadeSpeed) / FadeSpeed;
			rendCPSO.material.color = Color.Lerp(ColorStart,ColorEnd3,lerp);

		}
		if(!DoorOpenState && !DoorCloseState && !DoorNeedKeyState)
		{
			rendCPSO.material.color = ColorStart;

		}
	}
}
