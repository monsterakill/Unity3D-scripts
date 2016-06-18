using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {
	public bool showCrosshair = true;
	public float CrossHairSizeCordX;
	public float CrossHairSizeCordY;
	public Texture2D NormalTexture;
	// Use this for initialization
	void Start () {
		//Cursor.visible = false;
	}
	
	void OnGUI()
	{
		if(showCrosshair == true)
		{
			//GUI.DrawTexture(new Rect((Screen.width-CrosshairTexture.width*CrossHairSize)/2 ,(Screen.height-CrosshairTexture.height*CrossHairSize)/2, CrosshairTexture.width*CrossHairSize, CrosshairTexture.height*CrossHairSize),CrosshairTexture);
			Vector2 mousePos = Event.current.mousePosition;
			GUI.DrawTexture(new Rect( mousePos.x - (NormalTexture.width/CrossHairSizeCordX),mousePos.y - (NormalTexture.height/CrossHairSizeCordX),NormalTexture.width/CrossHairSizeCordY,NormalTexture.height/CrossHairSizeCordY), NormalTexture);

		}
	}
}
