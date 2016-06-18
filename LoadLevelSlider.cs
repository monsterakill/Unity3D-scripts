using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadLevelSlider : MonoBehaviour {

	
	Slider slider;
	public bool StartSlider = false;
	private AsyncOperation async;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(StartSlider)
		{
			slider = GameObject.Find("LoadLevelSlider").GetComponent<Slider>();
			slider.value += 0.1f;
			if(slider.value >= 100) StartSlider = false;
			if(slider.value == 100) Application.LoadLevel(1);
		}*/
	}
	public void ClickAsync(int level)
	{
		slider = GameObject.Find("LoadLevelSlider").GetComponent<Slider>();
		StartCoroutine(LoadLevelWithBar(level));
	}
	
	
	IEnumerator LoadLevelWithBar (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			slider.value = async.progress;
			yield return null;
		}
	}
}
