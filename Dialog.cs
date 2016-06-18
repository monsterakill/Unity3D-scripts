using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

	GameObject MainCamera;
	CrossHair CrossCheck;
	public GameObject NPC;
	public GameObject Canvas;
	//public GameObject Mask;
	//private Text CanvasTextMainUIDialogText;
	RectTransform Mask;
	private bool StartShowText = false;
	private float TextXPos = 0;
	private float TextWidth = 500;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X) && CrossCheck.CanChange == false && CrossCheck.Gtemp == NPC)
		{
			Canvas.SetActive(true);
			//CanvasTextMainUIDialogText = GameObject.Find("DialogText").GetComponent<Text>();
			Mask = GameObject.Find("Mask").GetComponent<RectTransform>();
			StartShowText = true;
		}
		if(StartShowText)
		{
			TextXPos += 0.3f;
			TextWidth -= 1f;
			if(TextXPos <= 220)
			{
				Mask.transform.localPosition = new Vector3 (TextXPos, Mask.transform.localPosition.y, Mask.transform.localPosition.z);
				Mask.sizeDelta = new Vector2 (TextWidth, 30);

			}
		}
	}


	public void CanvasOff()
	{
		Canvas.SetActive(false);
	}
}
