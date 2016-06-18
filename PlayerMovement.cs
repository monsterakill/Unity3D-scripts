using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10f;
	public float jumpSpeed = 7f;
	Vector3 direction = Vector3.zero;
	float verticalVelocity = 0;
	
	CharacterController cc;
	//Animator anim;


	//CapsuleCollider capsCollider;
	//float realCapsuleColliderHeight = 2f;
	//float jumpCapsuleColliderHeight = 1.2f;
	
	
	// Use this for initialization
	void Start () {
		
		cc = GetComponent<CharacterController> ();
		//anim = GetComponent<Animator> ();
		//capsCollider = (CapsuleCollider)collider;
	}
	
	// Update is called once per frame
	void Update () {
		//WASD forward back left right movement is stiored in direction
		direction = transform.rotation * new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		if (direction.magnitude > 1f) {

			direction = direction.normalized;
				}


		//anim.SetFloat ("Speed", direction.magnitude);
		//handle jumping

		if (cc.isGrounded && Input.GetButton ("Jump")) {
			verticalVelocity = jumpSpeed;
			//capsCollider.height = realCapsuleColliderHeight;
				 
		}
		AdjustAimAngle ();
	} 

	void AdjustAimAngle(){

		//Transform myCamera = Camera.main.transform;

		Camera myCamera = this.GetComponentInChildren<Camera> ();

		if (myCamera == null) {
			Debug.LogError("My Character Doesn't have Camera");
			return;
		}

		float AimAngle = 0;

		if (myCamera.transform.rotation.eulerAngles.x <= 90f) {
						//we looking down
			AimAngle = -myCamera.transform.rotation.eulerAngles.x;
		} 
		else {
			AimAngle = 360 - myCamera.transform.rotation.eulerAngles.x;
		}
		//Debug.Log (AimAngle);
		//anim.SetFloat ("AimAngle", AimAngle);
	}


	//its called once per physics loop do all MOVEMET and other physics stuff here
	void FixedUpdate (){
		Vector3 dist = direction * speed * Time.deltaTime;


		if (cc.isGrounded && verticalVelocity < 0) {

						//anim.SetBool ("Jumping", false);

						verticalVelocity = Physics.gravity.y * Time.deltaTime;

				}
		else {
						if (Mathf.Abs (verticalVelocity) > jumpSpeed * 0.75f) {

								//anim.SetBool ("Jumping", true);
						}

						verticalVelocity += Physics.gravity.y * Time.deltaTime;
			}




			

		//Debug.Log (verticalVelocity);


			dist.y = verticalVelocity * Time.deltaTime;
		
			cc.Move (dist);
		
		
	}
	
}
