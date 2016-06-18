using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.UI;

public class Crypt : MonoBehaviour {

	private InputField UserName;
	private InputField UserPassword;
	private Text MD5;
	LoadLevelSlider LLS;
	//private Text MD5UserPassword;

	// Use this for initialization
	void Start () {
		UserName = GameObject.Find("UserName").GetComponent<InputField>();
		UserPassword = GameObject.Find("Password").GetComponent<InputField>();
		MD5 = GameObject.Find("MD5").GetComponent<Text>();
		LLS = GameObject.Find("Control").GetComponent<LoadLevelSlider>();
		//MD5UserPassword = GameObject.Find("MD5").GetComponent<Text>();




	}
	public string Md5Sum(string strToEncrypt)
		
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}

	public void Check()
	{
		string UserNameEncry;
		string UserPassEncry;
		Md5Sum(UserName.text);
		Md5Sum(UserPassword.text);
		UserNameEncry = Md5Sum(UserName.text);
		UserPassEncry = Md5Sum(UserPassword.text);
		if(UserNameEncry == "7d5c2aa01b0b5e032fb285a7ac1240cc" && UserPassEncry == "5c81a2d88916903393e9797338db66e4")
		{
			MD5.text = "Correct Name";
			LLS.ClickAsync(1);

		}
		else{
			MD5.text = "Error";
		}


	}





}
