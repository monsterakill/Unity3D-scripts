using UnityEngine;
using System.Collections;

public class FXManager : MonoBehaviour {

	
	//public AudioClip bulletRicochetFXAudio;
	public GameObject sniperBulletFXPrefab;
	public GameObject railBulletFXPrefab;
	//public bool Rail = false;

	[PunRPC]
	void SniperBulletFX(Vector3 startPos, Vector3 endPos, bool Rail){
		Debug.Log ("SniperBulletFX");
		if (sniperBulletFXPrefab != null && railBulletFXPrefab != null) 
		{
			if(!Rail)
			{
				GameObject sniperFX = (GameObject)Instantiate (sniperBulletFXPrefab, startPos, Quaternion.LookRotation(endPos - startPos));
				LineRenderer lr = sniperFX.transform.Find ("LineFX").GetComponent<LineRenderer> ();
				if(lr != null){
				  lr.SetPosition (0, startPos);
				  lr.SetPosition (1, endPos);
				}
				else{
					Debug.LogError("sniperBulletFXPrefab line rende is missing");
				}
			}else{
				GameObject sniperFX = (GameObject)Instantiate (railBulletFXPrefab, startPos, Quaternion.LookRotation(endPos - startPos));
				LineRenderer lr = sniperFX.transform.Find ("LineFX").GetComponent<LineRenderer> ();
				if(lr != null){
					lr.SetPosition (0, startPos);
					lr.SetPosition (1, endPos);
				}
				else{
					Debug.LogError("sniperBulletFXPrefab line rende is missing");
				}
			}
		} 
		else {
			Debug.LogError ("sniperBulletFXPrefab or railBulletFXPrefab is MISSING");
		}
	}

}
