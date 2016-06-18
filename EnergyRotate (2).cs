using UnityEngine;
using System.Collections;

public class EnergyRotate : MonoBehaviour {
	public GameObject Ring1;
	public GameObject Ring2;
	public GameObject Ring3;
	public GameObject Ring4;
	public GameObject Ring5;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//Quaternion temp = Ring1.transform.rotation;
		//temp.x += 1;
		//Ring1.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
		Ring1.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
		Ring1.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed, Space.World);
		Ring2.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
		//Ring2.transform.Rotate(Vector3.left * Time.deltaTime * rotateSpeed, Space.World);
		Ring3.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
		Ring3.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed, Space.World);
		Ring4.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
		//Ring4.transform.Rotate(Vector3.left * Time.deltaTime * rotateSpeed, Space.World);
		Ring5.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
		Ring5.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed, Space.World);
	}
}
