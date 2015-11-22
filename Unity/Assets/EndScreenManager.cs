using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EndScreenManager : MonoBehaviour {

	public GameObject player_one_display;
	public GameObject player_two_display;

	// Use this for initialization
	void Start () {
		player_one_display.GetComponentInChildren<Text> ().text = "X score: " + GameLogic.player_one_score;
		player_two_display.GetComponentInChildren<Text> ().text = "O score: " + GameLogic.player_two_score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playAgain(){
		Application.LoadLevel ("TTN");

	}
}
