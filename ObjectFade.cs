using UnityEngine;
using System.Collections;

public class ObjectFade : MonoBehaviour {
	public float FadeSpeed = 10;
	Renderer rend;
	private float matTime = 1;
	public float matTimecof = 0;

	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () 
	{
		//float lerp = Mathf.PingPong(Time.time, FadeSpeed) / FadeSpeed;
		//if(lerp < 1)
		//{

		if(matTime > 0)
		{
			matTime -= matTimecof;
			rend.material.SetFloat("_Cutoff", matTime);
		}
		//}
	}
}
