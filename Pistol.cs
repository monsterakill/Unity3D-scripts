using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pistol : MonoBehaviour {

	public float range = 100.0f;

	//Shoot Cooldown
	public float cooldown = 0.2f;
	float cooldownRemaining = 0;

	//Reload Cooldown
	public float Reloadcooldown = 0.2f;


	public float damage = 50f;

	public GameObject debrisPrefab;
	public GameObject bulletHole;

	public float currentbulletsInHolder;
	public float bulletsInHolder;
	public float Holders;
	public Text bulletsInHolderCanvas;
	public Text totalBulletsInPistolCanvas;
	private AudioSource PistolMainAudio;
	public AudioClip EmptyAmmoSound;
	public AudioClip ShootSound;
	public AudioClip ReloadSound;
	public ParticleSystem GunMuzzle;
	
	private bool delay = false;

	// Use this for initialization
	void Start () {
		PistolMainAudio = GameObject.Find("PShooT").GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;

		bulletsInHolderCanvas.text = currentbulletsInHolder.ToString("F0");
		totalBulletsInPistolCanvas.text = Holders.ToString("F0");

		if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder > 0) 
		{
			currentbulletsInHolder -= 1;
			//Muzzle
			GunMuzzle.Play();
			//Animation
			GameObject.Find("PistolMesh").GetComponent<Animation>().Play("Shoot");
			//Sound
			if(ShootSound != null) PistolMainAudio.PlayOneShot(ShootSound);
			Shoot();
			cooldownRemaining = cooldown;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder == 0) 
		{
			GameObject.Find("PistolMesh").GetComponent<Animation>().Play("NoAmmo");
			if(EmptyAmmoSound != null) PistolMainAudio.PlayOneShot(EmptyAmmoSound);
			cooldownRemaining = cooldown;
		}


		if(currentbulletsInHolder <= bulletsInHolder-1 && Holders > 0 && Input.GetKeyDown(KeyCode.R) && cooldownRemaining <= 0)
		{
			//Reload ANimation Play

			cooldownRemaining = Reloadcooldown;
			GameObject.Find("PistolMesh").GetComponent<Animation>().Play("Reload");
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
		Ray ray = new Ray (Camera.main.transform.position+Camera.main.transform.forward, Camera.main.transform.forward);
		RaycastHit hitInfo;
		
		if (Physics.Raycast (ray, out hitInfo, range)) 
		{
			Vector3 hitPoint = hitInfo.point;
			GameObject go = hitInfo.collider.gameObject;
			Debug.Log ("Hit Object: " + go.name);
			Debug.Log ("Hit Point: " + hitPoint);
			
			Health h = go.GetComponent<Health>();
			
			//Check Object Health
			if(h != null)
			{
				h.ReceiveDamage(damage);
			}
			//Check Bullet Prefab
			if (debrisPrefab != null) 
			{
				Instantiate (debrisPrefab, hitPoint, Quaternion.identity);
			}
			//Check BulletHole Prefab
			if (bulletHole != null) 
			{
				Instantiate(bulletHole, hitPoint, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
			}
		}
	}

}

