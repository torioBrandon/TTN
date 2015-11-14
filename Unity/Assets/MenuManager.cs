using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public bool X_or_O;	//false for X, true for O

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchScene(){
		Application.LoadLevel ("TTN Gameplay");
	}
}
