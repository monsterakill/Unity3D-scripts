using UnityEngine;
using System.Collections;

public class PistolCollider : MonoBehaviour {

	public Collider EnteredPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		EnteredPlayer = other;
		this.gameObject.GetComponent<PhotonView>().RPC("PistolPicked", PhotonTargets.AllBuffered, null);
	}
	[PunRPC]
	public void PistolPicked()
	{
		if(EnteredPlayer != null)
		{
			EnteredPlayer.gameObject.GetComponent<PlayerShooting>().RailGun = false;
		}
		//PhotonNetwork.Destroy(this.gameObject);
	}

}
