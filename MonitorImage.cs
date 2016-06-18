using UnityEngine;
using System.Collections;

public class MonitorImage : MonoBehaviour {
	//public Texture[] textureArray;
	//public GameObject Monitor;
	public Renderer rend;
	//public Material BluePrint;
	//private bool StartMonitor = false;
	//private int i = 0;

	// Use this for initialization
	void Start () {
		//InvokeRepeating("MaterialsChange",0,1.5f);
		//InvokeRepeating("MaterialsChange1",0,1.0f);
		//rend = Monitor.GetComponent<Renderer>();
		//rend.materials[3].shader = Shader.Find("Custom/SimplePhysicalShader");

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < rend.materials.Length; i++)
		{
			if(rend.materials[i].name == "BluePrint (Instance)")
			{
				float smoothness = Random.Range(1.0f,5.0f);
				float mettallicity = Random.Range(0f,1.0f);
				rend.materials[i].SetFloat("_Smoothness",smoothness);
				rend.materials[i].SetFloat("_Metallicity",mettallicity);
			}
		}
	}
}
