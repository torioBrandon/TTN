using UnityEngine;
using System.Collections;

public class Choice_Manager : MonoBehaviour {


	public static bool X_or_O = false;	//false for X, true for O

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickedX(){
		Application.LoadLevel ("TTN Gameplay");
	}

	public void clickedY(){
		X_or_O = true;
		Application.LoadLevel ("TTN Gameplay");
	}
}
