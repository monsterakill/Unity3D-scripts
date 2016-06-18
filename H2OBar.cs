using UnityEngine;
using System.Collections;

public class H2OBar : MonoBehaviour {
	public float CurrentOxygen;
	public float OxygenRatio;
	GameObject Player;
	public bool OxygenZoneCheck = true;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");


	
	}
	
	// Update is called once per frame
	void Update () {
		if(OxygenZoneCheck)
		{
			CurrentOxygen -= OxygenRatio*Time.deltaTime;
			if(CurrentOxygen <= 0)
			{
				Destroy(Player);
			}
		}
	}



	void OnGUI()
	{
		GUI.Label(new Rect(100, 100, 100, 100), CurrentOxygen.ToString("F0"));

	}

	public static void AutoResize(int screenWidth, int screenHeight)
	{
		Vector2 resizeRatio = new Vector2((float)Screen.width / screenWidth, (float)Screen.height / screenHeight);
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
	}
}
