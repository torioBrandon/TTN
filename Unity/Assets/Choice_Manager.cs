using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Choice_Manager : MonoBehaviour {


	public static bool X_or_O = false;	//false for X, true for O

	public static int turn_duration;
	public GameObject turn_duration_input;

	// Use this for initialization
	void Start () {
	
	}

	public void setTurnDuration(){
//		turn_duration = int.Parse(s);
		Debug.Log (turn_duration_input.GetComponentInChildren<Text> ().text);
		turn_duration = int.Parse(turn_duration_input.GetComponentInChildren<Text> ().text);
		Application.LoadLevel ("TTN Gameplay");
		//return s;
	}
}
