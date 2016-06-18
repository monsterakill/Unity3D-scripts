using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M4A1 : MonoBehaviour {



	public GameObject shootPoint;
	public float bulletSpeed;
	public float range = 5.0f;

	//Shoot Cooldown
	public float fireRate = 0.2f;
	float cooldownRemaining = 0;

	//Reload Cooldown
	public float Reloadcooldown = 0.2f;


	public float damage = 50f;

	public float currentbulletsInHolder;
	public float bulletsInHolder;
	public float allBullets;
	private AudioSource PistolMainAudio;
	public AudioClip EmptyAmmoSound;
	public AudioClip ShootSound;
	public AudioClip ReloadSound;
	public ParticleSystem GunMuzzle;
	public GameObject bloodParticle;
	public GameObject linePrefab;
	
	private bool delay = false;
	//CrossHair
	public Texture2D CrosshairTexture;
	public bool showCrosshair = true;
	public float CrossHairSize;

	private Camera mainCam;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		if(EmptyAmmoSound || ShootSound || ReloadSound != null)
		{
			PistolMainAudio = GameObject.Find("m4A1").GetComponent<AudioSource>();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		Debug.DrawRay(shootPoint.transform.position , shootPoint.transform.forward * 15, Color.blue);

		if (Input.GetKey(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder > 0) 
		{
			currentbulletsInHolder -= 1;
			//Muzzle
			if(GunMuzzle != null) GunMuzzle.Play();
			//Animation
			//Sound
			if(ShootSound != null) PistolMainAudio.PlayOneShot(ShootSound);
			Shoot();
			cooldownRemaining = fireRate;
		}

		if (Input.GetKey(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder == 0) 
		{
			//Animation
			if(EmptyAmmoSound != null) PistolMainAudio.PlayOneShot(EmptyAmmoSound);
			cooldownRemaining = fireRate;
		}


		if(Input.GetKeyDown(KeyCode.R) && allBullets > 0 && cooldownRemaining <= 0 || Input.GetButton("Reload") && Input.GetButton("Fire1") && allBullets > 0) //  
		{
			//Reload ANimation Play
			cooldownRemaining = Reloadcooldown;
			if(ReloadSound != null) PistolMainAudio.PlayOneShot(ReloadSound);
			delay = true;
		}
		if(cooldownRemaining <= 0.5 && delay == true)
		{
			if(allBullets + currentbulletsInHolder < bulletsInHolder)
			{
				currentbulletsInHolder += allBullets;
				allBullets = 0;
			}else{
				float i = (bulletsInHolder - currentbulletsInHolder);
				currentbulletsInHolder += i;
				//currentbulletsInHolder = bulletsInHolder;
				allBullets -= i;
			}
			delay = false;
		}


	}

	void Shoot()
	{
		Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));//(shootPoint.transform.position , shootPoint.transform.forward );
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
			//LineRENDERER
			GameObject newLineObject = Instantiate(linePrefab);
			LineRenderer newLine = newLineObject.GetComponent<LineRenderer>();
			newLine.SetPosition(0, shootPoint.transform.position);
			newLine.SetPosition(1, hitPoint);
			//LineRENDERER
			Health h = go.GetComponent<Health>();

			//Check Object Health
			if(h != null)
			{
				h.ReceiveDamage(damage);
			}


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

