using UnityEngine;
using System.Collections;

public class CarMain : MonoBehaviour {

	public float maxTorque = 50f;
	public float maxSpeed = 120f;
	public float Breaking = 1000f;


	public Transform centerOffMass;


	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public Transform[] wheelMeshes = new Transform[4];

	private Rigidbody m_rigidbody;
	private float currentSpeed;

	void Start()
	{

		m_rigidbody = GetComponent<Rigidbody>();
		m_rigidbody.centerOfMass = centerOffMass.localPosition;
	}

	void Update()
	{
		UpdateMeshes();

	}
	void FixedUpdate()
	{
		currentSpeed = m_rigidbody.velocity.magnitude * 3.6f;
		if (currentSpeed < maxSpeed) {
			wheelColliders[2].motorTorque = Input.GetAxis("Vertical") * maxTorque;
			wheelColliders[3].motorTorque = Input.GetAxis("Vertical") * maxTorque;
		} else {
			wheelColliders[2].motorTorque = 0;
			wheelColliders[3].motorTorque = 0;
		}
		float steer = Input.GetAxis("Horizontal");
		//float accelerate = Input.GetAxis("Vertical");

		float finalAangle = steer * 30f;
		wheelColliders[0].steerAngle = finalAangle;
		wheelColliders[1].steerAngle = finalAangle;


		//for(int i = 0; i < 4; i++)
		//{
		//	wheelColliders[i].motorTorque = accelerate * maxTorque;
		//}
	}

	void UpdateMeshes()
	{
		for(int i = 0; i < 4; i++)
		{
			Quaternion quat;
			Vector3 pos;
			wheelColliders[i].GetWorldPose(out pos, out quat);

			wheelMeshes[i].position = pos;
			wheelMeshes[i].rotation = quat;

		}

	}

}
