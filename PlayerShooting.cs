using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	
	float cooldown = 0;
	float preloadCooldown = 0;
	FXManager fxManager;
	WeaponData weaponData;
	bool Preload = false;
	public bool RailGun = false;
	public GameObject Pistol;
	public GameObject Rail;

	void Start(){
		fxManager = GameObject.FindObjectOfType<FXManager>(); //(typeof(FXManager));
		if (fxManager == null) 
		{
			Debug.LogError("Can not find an FXManager");

		}
	}
		
	void Update () 
	{
		cooldown -= Time.deltaTime;

		if(RailGun)
		{
			PreloadWeapon();
			Pistol.SetActive(false);
			Rail.SetActive(true);
			gameObject.GetComponentInChildren<WeaponData>().damage = 100;
			if (Input.GetButtonUp ("Fire1") && Preload == true) 
			{
				//player wants shoot
				Preload = false;
				Fire ();
				preloadCooldown = 0;

			}
		}else{
			gameObject.GetComponentInChildren<WeaponData>().damage = 15;
			Rail.SetActive(false);
			Pistol.SetActive(true);

			if (Input.GetButtonDown ("Fire1")) 
			{
				//player wants shoot
				Fire ();
			}
		}
	}

	void Fire()
	{
		if (weaponData == null) 
		{
			weaponData = gameObject.GetComponentInChildren<WeaponData> ();
			if (weaponData == null) 
			{
				Debug.LogError ("Missing weapon DATA");
				return;
			}
		}

		if(cooldown > 0)
		{
			return;
		}	
		Debug.Log ("FIRE");

		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		Transform hitTransform;
		Vector3 hitPoint;
		hitTransform = FindClosestHitObject (ray, out hitPoint );

		if (hitTransform != null) 
		{
			Debug.Log ("We hit: " + hitTransform.name);

			//DoRicochetffectAt(hitPoint);

			Health h = hitTransform.GetComponent<Health> ();

			while (h == null && hitTransform.parent) 
			{
					hitTransform = hitTransform.parent;
					h = hitTransform.GetComponent<Health> ();

			}
			if (h != null) 
			{
				//h.TakeDamage (damage); single player
				PhotonView pv = h.GetComponent<PhotonView> ();
				if (pv == null) 
				{
					Debug.LogError ("Freak OUT Photon VIEW");
				}else{

					TeamMember tm = hitTransform.GetComponent<TeamMember>();
					TeamMember myTm = this.GetComponent<TeamMember>();
					if(tm == null || tm.teamID == 0 || myTm == null || myTm.teamID == 0 || tm.teamID != myTm.teamID)
					{
						h.GetComponent<PhotonView> ().RPC ("TakeDamage", PhotonTargets.AllBuffered, weaponData.damage);
					}
				}
			}
			if (fxManager != null) 
			{
				DoGunFX(hitPoint);
			}				
		}else{
			//we didn't hit anything
			if (fxManager != null) 
			{
				hitPoint = Camera.main.transform.position + (Camera.main.transform.forward * 100f);
				DoGunFX(hitPoint);
			}
		}
		cooldown = weaponData.fireRate;
	}

	void DoGunFX(Vector3 hitPoint) {
		//GameObject go = GameObject.Find ("FirePoint"); deklaracija igrovogo objkekta v peremennuju
		if(RailGun == false)
		{
			fxManager.GetComponent<PhotonView> ().RPC ("SniperBulletFX", PhotonTargets.All, weaponData.transform.position, hitPoint, false);
		}
		if(RailGun == true)
		{
			fxManager.GetComponent<PhotonView> ().RPC ("SniperBulletFX", PhotonTargets.All, weaponData.transform.position, hitPoint, true);

		}

	}


	Transform FindClosestHitObject(Ray ray, out Vector3 hitPoint) {

		RaycastHit[] hits = Physics.RaycastAll (ray);

		Transform closestHit = null;
		float distance = 0;
		hitPoint = Vector3.zero;

		foreach (RaycastHit hit in hits) {
				if (hit.transform != this.transform && (closestHit == null || hit.distance < distance)) {

					closestHit = hit.transform;
					distance = hit.distance;
				hitPoint = hit.point;

				}
		}
	    return closestHit;
	}

	void PreloadWeapon()
	{
		if(Input.GetButton ("Fire1"))
		{
			preloadCooldown += Time.deltaTime;
			//RailAudio.PlayOneShot(RailClip);

		}
		if(preloadCooldown >= 2.0f)
		{	
			Preload = true;
		}
		if(Input.GetButtonUp ("Fire1"))
		{	
			preloadCooldown = 0;
			if(preloadCooldown < 2.0)
			{
				
			}
		}
	}
}
