using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TreasurePanel : MonoBehaviour {
	
	public AudioClip mySound;
	public AudioSource mySource;
	public GameObject Treasure;
	CrossHair CrossCheck;
	UIMain AddResource;
	TreasurePanel Script;
	BoxCollider boxCollider;
	private GameObject MainCamera;

	//MiniGame
	private bool StartMiniGame = false;
	Slider slider;
	Slider sliderPoint1;
	Slider sliderPoint2;
	private bool StartSlider = true;
	FirstPersonController FPSController;
	private GameObject Player;
	public GameObject Canvas;
	private bool randValue = true;
	private bool StartMoveSlider = true;
	private float Score = 0;
	public float WinScore;


	
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
		CrossCheck = MainCamera.GetComponent<CrossHair>();
		AddResource = MainCamera.GetComponent<UIMain>();
		Script = Treasure.GetComponent<TreasurePanel>();
		boxCollider = Treasure.GetComponent<BoxCollider>();

		Player = GameObject.FindWithTag("Player");
		FPSController = Player.GetComponent<FirstPersonController>();

		
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && CrossCheck.CanChange == false && CrossCheck.Gtemp == Treasure)
		{
			WinScore = Random.Range(2,7); 
			Canvas.SetActive(true);
			FPSController.enabled = false;
			StartMiniGame = true;
		}
		if(StartMiniGame)
		{
			slider = GameObject.Find("MiniGame").GetComponent<Slider>();
			sliderPoint1 = GameObject.Find("MiniGamePoint1").GetComponent<Slider>();
			sliderPoint2 = GameObject.Find("MiniGamePoint2").GetComponent<Slider>();
			MiniGame();
		}
	}

	void MiniGame()
	{
		boxCollider.enabled = false; //Block Treasure for opening.
		if(StartMoveSlider){
			if(randValue){
				sliderPoint1.value = Random.Range(0,100);
				sliderPoint2.value = Random.Range(0,100);
				randValue = false;
			}
			if(StartSlider)
			{
				slider.value += 1;
				if(slider.value >= 100) StartSlider = false;
			}else{
				slider.value -= 1;
				if(slider.value <= 0) StartSlider = true;

			}
		}
		// points range Fix
		float pointRange;
		if(sliderPoint1.value == sliderPoint2.value)
		{
			sliderPoint2.value += 8; // check
		}
		if(sliderPoint1.value > sliderPoint2.value)
		{
			pointRange = sliderPoint1.value - sliderPoint2.value;
			if(pointRange <= 5)
			{
				
				sliderPoint1.value += 8;
			}
			if(pointRange >= 30)
			{
				sliderPoint1.value -= 10;
				
			}
		}else{
			pointRange = sliderPoint2.value - sliderPoint1.value;
			if(pointRange <= 5)
			{
				
				sliderPoint2.value += 8;
			}
			if(pointRange >= 30)
			{
				sliderPoint2.value -= 10;
				
			}
		}
	
		if(Input.GetKeyDown(KeyCode.Space))
		{

			StartMoveSlider = false;
			if(slider.value >= sliderPoint1.value && slider.value <= sliderPoint2.value || slider.value >= sliderPoint2.value && slider.value <= sliderPoint1.value)
			{
				Debug.Log("WIN");
				randValue = true;
				StartMoveSlider = true;
				slider.value = 0;
				Score += 1;
			}
			else{
				Debug.Log("LOSE");
				StartMiniGame = false;
				Canvas.SetActive(false);
				FPSController.enabled = true;
				randValue = true;
				boxCollider.enabled = true;
				StartMoveSlider = true;
				slider.value = 0;
				Score = 0;
			}
		}
		if(WinScore == Score)
		{
			StartMiniGame = false;
			Canvas.SetActive(false);
			FPSController.enabled = true;
			randValue = true;
			boxCollider.enabled = false;
			StartMoveSlider = true;
			slider.value = 0;
			mySource.PlayOneShot(mySound);
			Treasure.GetComponent<Animation>().Play("TreasureOpen");
			AddResource.Resource += Random.Range(1,100);
			Script.enabled = false;
		}
	}
}