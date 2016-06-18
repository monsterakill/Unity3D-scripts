using UnityEngine;
using System.Collections;

public class CameraPositionV2 : MonoBehaviour {
	
	public GameObject Player;
	private Camera cam;
	public float CamCurrentPosition = 12.5f;
	public float CamSmoothChange = 0.3f;
	public float CamLerp = 0.2f;
	private Vector3 Pullback;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = CamCurrentPosition;
		pos = cam.ScreenToWorldPoint(pos);
		Pullback = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, CamCurrentPosition));
		Vector3 targetPosition = Vector3.Lerp(Player.transform.position, Pullback, CamLerp);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, CamSmoothChange);
		transform.position = new Vector3(transform.position.x, 12.5f, transform.position.z);
	}

	void OnGUI()
	{
		GUI.Label (new Rect (25, 25, 100, 30), cam.transform.position.y.ToString());
	}
}
