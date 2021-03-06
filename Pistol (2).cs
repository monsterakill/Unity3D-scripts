﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pistol : MonoBehaviour {


	public GameObject shootPoint;
	public float bulletSpeed;
	public float range = 5.0f;

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
	private AudioSource PistolMainAudio;
	public AudioClip EmptyAmmoSound;
	public AudioClip ShootSound;
	public AudioClip ReloadSound;
	public ParticleSystem GunMuzzle;
	
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

		if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownRemaining <= 0 && currentbulletsInHolder == 0) 
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
		Ray ray = new Ray (shootPoint.transform.position , shootPoint.transform.forward );
		RaycastHit hitInfo;
		
		if (Physics.Raycast (ray, out hitInfo, range)) 
		{
			Vector3 hitPoint = hitInfo.point;
			GameObject go = hitInfo.collider.gameObject;
			Debug.Log ("Hit Object: " + go.name);
			Debug.Log ("Hit Point: " + hitPoint);
			
			//Health h = go.GetComponent<Health>();
			
			//Check Object Health
			//if(h != null)
			//{
				//h.ReceiveDamage(damage);
			//}
			//Check Bullet Prefab
			if (debrisPrefab != null) 
			{
				GameObject thebullet = (GameObject)Instantiate (debrisPrefab, shootPoint.transform.position + shootPoint.transform.forward, shootPoint.transform.rotation);
				Rigidbody rb = thebullet.GetComponent<Rigidbody>();
				rb.AddForce(shootPoint.transform.forward * bulletSpeed, ForceMode.Impulse);
				//Instantiate (debrisPrefab, hitPoint, Quaternion.identity);
			}
			//Check BulletHole Prefab
			if (bulletHole != null) 
			{
				Instantiate(bulletHole, hitPoint, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
			}
		}
	}

}

