using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

	public GameObject Enemy;
	public GameObject Player;
	public Renderer PlayerRenderer;
	public bool PlayerOnCamera;
	private Camera cam;
	public float CamCurrentPosition = 12.5f;
	public float CamStandartPosition = 12.5f;
	public float CamMaxPosition = 18.0f;
	private Vector3 velocity = Vector3.zero;
	public float CamSmoothChange = 0.3f;
	public float CamLerp = 0;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Enemy = FindClosestEnemy();

		Vector3 targetPosition = Vector3.Lerp(Player.transform.position, Enemy.transform.position, CamLerp);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, CamSmoothChange);
		
		PlayerOnCamera = IsVisibleFrom(PlayerRenderer, cam);
		if(!PlayerOnCamera && CamCurrentPosition <= CamMaxPosition)
		{
			CamCurrentPosition += 0.03f;
			transform.position = new Vector3(transform.position.x, CamCurrentPosition, transform.position.z);
		}
		if(!PlayerOnCamera && CamCurrentPosition >= CamMaxPosition)
		{
			CamCurrentPosition -= 0.03f;
			transform.position = new Vector3(transform.position.x, CamCurrentPosition, transform.position.z);
		}
		if(PlayerOnCamera && CamCurrentPosition >= CamStandartPosition)
		{
			CamCurrentPosition -= 0.003f;
			transform.position = new Vector3(transform.position.x, CamCurrentPosition, transform.position.z);
		}
		if(PlayerOnCamera && CamCurrentPosition <= CamStandartPosition)
		{
			transform.position = new Vector3(transform.position.x, 12.5f, transform.position.z);
		}

	}
	public static bool IsVisibleFrom(Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
	
	public GameObject FindClosestEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = Player.transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (25, 25, 100, 30), cam.transform.position.y.ToString());

	}
}
