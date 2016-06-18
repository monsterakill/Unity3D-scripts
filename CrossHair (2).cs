using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {

	private Texture2D CrosshairTexture;
	public Texture2D UseTexture;
	public Texture2D NormalTexture;
	public bool showCrosshair = true;
	public bool CanChange = false;
	public float RayLengh = 5f;
	public GameObject Gtemp;
	public float CrossHairSize;
	public bool crossHair_Enable = true;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		CrosshairTexture = NormalTexture;
	}
	void Update()
	{
		if(crossHair_Enable)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, RayLengh))
			{
				if(hit.collider.gameObject.tag == "RayCastObj")
				{
					CanChange = false;
					
					CrosshairTexture = UseTexture;
					
					Gtemp = hit.collider.gameObject;
					
				}
				else 
				{
					CanChange = true;
					
					CrosshairTexture = NormalTexture; 
					
					Gtemp = null;
				}
			}
			else
			{
				CanChange = true;
				
				CrosshairTexture = NormalTexture;
				
				Gtemp = null;
			}
			Debug.DrawRay(ray.origin,ray.direction * RayLengh,Color.red);
		}
	}

	void OnGUI()
	{
		if(showCrosshair == true)
		{
			GUI.DrawTexture(new Rect((Screen.width-CrosshairTexture.width*CrossHairSize)/2 ,(Screen.height-CrosshairTexture.height*CrossHairSize)/2, CrosshairTexture.width*CrossHairSize, CrosshairTexture.height*CrossHairSize),CrosshairTexture);
		}
	}
}