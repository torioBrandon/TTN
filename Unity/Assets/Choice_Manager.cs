using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Choice_Manager : MonoBehaviour {


	public static bool X_or_O = false;	//false for X, true for O

	public static int turn_duration;
	public GameObject turn_duration_input;
	public GameObject no_turn_duration;


	public GameObject match_duration_input;
	public static int match_duration; 
	public GameObject no_match_duration;

	//bool other_value_set;

	// Use this for initialization
	void Start () {
		turn_duration = 0;
		match_duration = 0;
		no_turn_duration.SetActive (false);
		no_match_duration.SetActive (false);
		
		
	}

	public void setTurnDuration(){
//		turn_duration = int.Parse(s);
		Debug.Log (turn_duration_input.GetComponentInChildren<Text> ().text);
		turn_duration = int.Parse(turn_duration_input.GetComponentInChildren<Text> ().text);

	}

	public void setMatchDuration(){
		Debug.Log (match_duration_input.GetComponentInChildren<Text> ().text);
		match_duration = int.Parse(match_duration_input.GetComponentInChildren<Text> ().text);

	}

	public void playGame(){
		no_turn_duration.SetActive (false);
		no_match_duration.SetActive (false);
		if (turn_duration == 0) {
			no_turn_duration.SetActive(true);
		} else if (match_duration == 0) {
			no_match_duration.SetActive(true);
		} else {
			Application.LoadLevel ("TTN Countdown");
	
		}
	}

}