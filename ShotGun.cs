using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotGun : MonoBehaviour {


	public GameObject shootPoint;
	public GameObject shootPoint1;
	public GameObject shootPoint2;
	public float range = 5.0f;

	//Shoot Cooldown
	public float cooldown = 0.2f;
	float cooldownRemaining = 0;

	//Reload Cooldown
	public float Reloadcooldown = 0.2f;


	public float damage = 50f;

	public float currentbulletsInHolder;
	public float bulletsInHolder;
	public float Holders;
	private AudioSource PistolMainAudio;
	public AudioClip EmptyAmmoSound;
	public AudioClip ShootSound;
	public AudioClip ReloadSound;
	public ParticleSystem GunMuzzle;
	public GameObject bloodParticle;
	public GameObject linePrefab;
	
	private bool delay = false;

	// Use this for initialization
	void Start () {
		if(EmptyAmmoSound || ShootSound || ReloadSound != null)
		{
			PistolMainAudio = GameObject.Find("#AudioName").GetComponent<AudioSource>();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder > 0) 
		{
			currentbulletsInHolder -= 1;
			//Muzzle
			GunMuzzle.Play();
			//Animation
			//Sound
			if(ShootSound != null) PistolMainAudio.PlayOneShot(ShootSound);
			Shoot();
			cooldownRemaining = cooldown;
		}

		if (Input.GetKey(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder == 0) 
		{
			//Animation
			if(EmptyAmmoSound != null) PistolMainAudio.PlayOneShot(EmptyAmmoSound);
			cooldownRemaining = cooldown;
		}


		if(currentbulletsInHolder <= bulletsInHolder-1 && Holders > 0 && Input.GetKeyDown(KeyCode.R) && cooldownRemaining <= 0)
		{
			//Reload ANimation Play

			cooldownRemaining = Reloadcooldown;
			if(ReloadSound != null) PistolMainAudio.PlayOneShot(ReloadSound);
			delay = true;
		}
		if(cooldownRemaining <= 0.5 && delay == true)
		{

			Holders -= 1;
			currentbulletsInHolder += (bulletsInHolder - currentbulletsInHolder);
			delay = false;
		}


	}

	void Shoot()
	{
		Ray ray = new Ray (shootPoint.transform.position , shootPoint.transform.forward);
		RaycastHit hitInfo;
		
		if (Physics.Raycast (ray, out hitInfo, range)) 
		{
			Vector3 hitPoint = hitInfo.point;
			GameObject go = hitInfo.collider.gameObject;
			Debug.Log ("Hit Object: " + go.name);
			Debug.Log ("Hit Point: " + hitPoint);
			if(go.tag == "Enemy" && bloodParticle != null)
			{
				Instantiate(bloodParticle, hitPoint, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
			}
			GameObject newLineObject = Instantiate(linePrefab);
			LineRenderer newLine = newLineObject.GetComponent<LineRenderer>();
			newLine.SetPosition(0, shootPoint.transform.position);
			newLine.SetPosition(1, hitPoint);
		}

		Ray ray1 = new Ray (shootPoint1.transform.position , shootPoint1.transform.forward);
		RaycastHit hitInfo1;

		if (Physics.Raycast (ray1, out hitInfo1, range)) 
		{
			Vector3 hitPoint1 = hitInfo1.point;
			GameObject go1 = hitInfo1.collider.gameObject;
			Debug.Log ("Hit Object: " + go1.name);
			Debug.Log ("Hit Point: " + hitPoint1);

			if(go1.tag == "Enemy" && bloodParticle != null)
			{
				Instantiate(bloodParticle, hitPoint1, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
			}
			GameObject newLineObject = Instantiate(linePrefab);
			LineRenderer newLine = newLineObject.GetComponent<LineRenderer>();
			newLine.SetPosition(0, shootPoint1.transform.position);
			newLine.SetPosition(1, hitPoint1);
		}
		///////////////////////////
		Ray ray2 = new Ray (shootPoint2.transform.position , shootPoint2.transform.forward);
		RaycastHit hitInfo2;

		if (Physics.Raycast (ray2, out hitInfo2, range)) 
		{
			Vector3 hitPoint2 = hitInfo2.point;
			GameObject go2 = hitInfo2.collider.gameObject;
			Debug.Log ("Hit Object: " + go2.name);
			Debug.Log ("Hit Point: " + hitPoint2);

			if(go2.tag == "Enemy" && bloodParticle != null)
			{
				Instantiate(bloodParticle, hitPoint2, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
			}
			GameObject newLineObject = Instantiate(linePrefab);
			LineRenderer newLine = newLineObject.GetComponent<LineRenderer>();
			newLine.SetPosition(0, shootPoint2.transform.position);
			newLine.SetPosition(1, hitPoint2);
		}
	}
}

