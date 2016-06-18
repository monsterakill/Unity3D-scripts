using UnityEngine;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	public GameObject standbyCamera;
	SpawnSpot[] spawnSpots;

	public bool offlineMode = false;

	bool connecting = false;

	List<string> chatMessages;
	int maxChatMessages = 5;

	public float respawnTimer = 0;

	bool hasPickedTeam = false;
	int teamID = 0;


	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		PhotonNetwork.player.name = PlayerPrefs.GetString("Username", "Player");
		chatMessages = new List<string>();

	}

	public void AddChatMessage(string m){
		GetComponent<PhotonView> ().RPC ("AddChatMessage_RPC", PhotonTargets.AllBuffered, m);
	}

	[PunRPC]
	void AddChatMessage_RPC(string m){
		while (chatMessages.Count >= maxChatMessages) {
			chatMessages.RemoveAt(0);
		}
		chatMessages.Add (m);

	}

	void OnDestroy() {

		PlayerPrefs.SetString("Username", PhotonNetwork.player.name);
		//Hashtable props = PhotonNetwork.player.customProperties;


	}
	
	void Connect(){

		PhotonNetwork.ConnectUsingSettings ("v4.2");
	}

	void OnGUI(){
				GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());

		if (PhotonNetwork.connected == false && connecting == false) {

			//MENU buttons
			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();

			//Menu player name
			GUILayout.BeginHorizontal();
			GUILayout.Label("Username :  ");
			PhotonNetwork.player.name = GUILayout.TextField(PhotonNetwork.player.name);
			GUILayout.EndHorizontal();

			if(GUILayout.Button ("Single Player")){
				connecting = true;
				PhotonNetwork.offlineMode = true;
				OnJoinedLobby ();
			}

			if(GUILayout.Button ("Multi Player")){
				connecting = true;
				Connect ();

			}
			//MENU buttons
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		if (PhotonNetwork.connected == true && connecting == false) {

			if(hasPickedTeam){


			  GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			  GUILayout.BeginVertical();
			  GUILayout.FlexibleSpace();

			  foreach(string msg in chatMessages){
			    	GUILayout.Label(msg);
			  }

			  GUILayout.EndVertical();
			  GUILayout.EndArea();
			}
			else{

				GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.BeginVertical();
				GUILayout.FlexibleSpace();

				
				if(GUILayout.Button ("Red Team")){
					SpawnMyPlayer (1);
				}
				if(GUILayout.Button ("Green Team")){
					SpawnMyPlayer (2);
				}
				if(GUILayout.Button ("Random")){
					SpawnMyPlayer (Random.Range(1,3));
				}
				//if(GUILayout.Button ("Renegade!")){
					//SpawnMyPlayer (0);
				//}

				GUILayout.FlexibleSpace();
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndArea();


			}
		}

	}

	void OnJoinedLobby(){
		//PhotonNetwork.CreateRoom ("PlayerRoomName");
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();

		}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonJoinFailed");
		PhotonNetwork.CreateRoom (null);

		}

	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");

		connecting = false;
		//SpawnMyPlayer ();
	
	}
	void SpawnMyPlayer (int teamID){
		this.teamID = teamID;
		hasPickedTeam = true;
		//Instantiate (PlayerPrefs); only on my computer
		//SpawnSpot[] spots = GameObject.FindObjectsOfType<SpawnSpot> (); настройка спавнов для конкретной цели
		AddChatMessage ("Spawning player : " + PhotonNetwork.player.name);
		Cursor.lockState = CursorLockMode.Locked;


		if (spawnSpots == null) {
						Debug.LogError ("WTF!?!?!?");
						return;
				}


		SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
		GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate ("PlayerController", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		standbyCamera.SetActive(false);

		//((MonoBehaviour)myPlayerGO.GetComponent("FPSInputController") ).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("MouseLook") ).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("PlayerMovement") ).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("PlayerShooting") ).enabled = true;


		myPlayerGO.GetComponent<PhotonView> ().RPC("SetTeamID", PhotonTargets.AllBuffered, teamID);
	

		myPlayerGO.transform.FindChild("Main Camera").gameObject.SetActive (true);
	}

	void Update(){
		if (respawnTimer > 0) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0){

				SpawnMyPlayer(teamID);
			}
		}
	}
}
