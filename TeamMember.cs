using UnityEngine;
using System.Collections;

public class TeamMember : MonoBehaviour {

	int _teamID = 0;

	public int teamID{
		get { return _teamID; }
	}

	[PunRPC]
	void SetTeamID(int id) {
		_teamID = id;
		MeshRenderer mySkin = this.transform.GetComponentInChildren<MeshRenderer> ();
		
		if (mySkin == null) {
			Debug.LogError("Couldn't find a SkinnedMeshRenderer");
		}
		
		if (teamID == 1) {
			mySkin.material.color = Color.red;
		}
		if (teamID == 2) {
			mySkin.material.color = new Color(.5f, 1f, .5f);
		}

	}
}
