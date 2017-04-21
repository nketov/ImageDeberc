using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject[] windows;
	public UnityEngine.Audio.AudioMixer audioMixer;


    void Awake()
    {
		audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("SoundVolume", -15f ));
		audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", -15f ));
    }



    // Use this for initialization
    void Start () {
		windows [0].SetActive (true);
		for (int i = 1; i < windows.Length; i++) {
			windows [i].SetActive (false);
		}
               
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateRoom(){
		if (GameManager.Instance)
			GameManager.Instance.ConnectRoom ();
	}

	public void JoinRoom(){
		if (GameManager.Instance)
			GameManager.Instance.ConnectRoom ();
	}
}
