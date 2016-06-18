using UnityEngine;
using System.Collections;

public class RailCollider : MonoBehaviour {

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
		this.gameObject.GetComponent<PhotonView>().RPC("RailPicked", PhotonTargets.AllBuffered, null);
	}
	[PunRPC]
	public void RailPicked()
	{
		if(EnteredPlayer != null)
		{
			EnteredPlayer.gameObject.GetComponent<PlayerShooting>().RailGun = true;
		}
		//PhotonNetwork.Destroy(this.gameObject);
	}

}
