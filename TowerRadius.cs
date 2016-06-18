using UnityEngine;
using System.Collections;

public class TowerRadius : MonoBehaviour {

	public GameObject ThisTowerHead;
	private MeshRenderer rend;
	TurretAI TAI;
	private Transform ThisObj;
	// Use this for initialization
	void Start () {
		rend = this.GetComponent<MeshRenderer>();
		ThisObj = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Ray rayRadius = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitTower;
		if (Physics.Raycast(rayRadius,out hitTower) && hitTower.collider.gameObject == ThisTowerHead)
		{
			TAI = ThisTowerHead.GetComponent<TurretAI>();
			Vector3 tScale = new Vector3(TAI.attackMaxDistance, 0.02f, TAI.attackMaxDistance);
			ThisObj.localScale = tScale;
			rend.enabled = true;
			//Rotate Turret Radius
			this.transform.Rotate(Vector3.up, Time.deltaTime * 10);
		}
		else{

			rend.enabled = false;
		}
	}
}
