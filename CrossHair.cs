using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {

	public Texture2D CrosshairTexture;
	public bool showCrosshair = true;
	public float CrossHairSize;
	void Start()
	{
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}
	void Update()
	{
	}

	void OnGUI()
	{
		if(showCrosshair == true)
		{
			GUI.DrawTexture(new Rect((Screen.width-CrosshairTexture.width*CrossHairSize)/2 ,(Screen.height-CrosshairTexture.height*CrossHairSize)/2, CrosshairTexture.width*CrossHairSize, CrosshairTexture.height*CrossHairSize),CrosshairTexture);
		}
	}
}