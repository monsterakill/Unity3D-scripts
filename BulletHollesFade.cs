using UnityEngine;
using System.Collections;

public class BulletHollesFade : MonoBehaviour {

	public float time = 5f;
	private float fade = 1f;
	public Renderer rend;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if(time < 0)
		{
			fade -= (Time.deltaTime / 3f);
			Color textureColor = rend.material.color;
			textureColor.a = fade;
			rend.material.color = textureColor;
			if(fade < 0)
			{
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
