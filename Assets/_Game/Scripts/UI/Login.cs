using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
	public InputField username;

	// Use this for initialization
	void Start () {
		username.text = PlayerPrefs.GetString ("username", "");	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickLogin() {
	//	if (username.text == "")
		//	return;
		
		//PlayerPrefs.SetString ("username", username.text);	

		//GameManager.Instance.ConnectServer ();

		SceneManager.LoadScene ("menu");
	}
}
