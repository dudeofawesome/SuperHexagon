using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class CardboardIntenterPlugin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print("test1");
		Debug.Log("Returned Int " + CardboardIntenter.ReturnInt());
		print("test2");
		if (CardboardIntenter.ReturnInt() == 57471) {
			GameObject.Find("Audio/Begin").GetComponent<AudioSource>().Play();
		}
		else {
			GameObject.Find("Audio/GameOver").GetComponent<AudioSource>().Play();
		}
		Application.Quit();
	}

	public void JustDoIt () {
		Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box(new Rect(0,0,100,100), "Returned Int " + CardboardIntenter.ReturnInt());
	}
}
