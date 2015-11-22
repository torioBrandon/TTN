using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject play_button;
	public GameObject rules_button;
	public GameObject ok_button;
	public GameObject rules_text;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchScene(){
		Application.LoadLevel ("TTN Setup");
	}

	public void showRules(){
		play_button.SetActive(false);
		rules_button.SetActive (false);
		ok_button.SetActive(true); 
		rules_text.SetActive(true);
	}

	public void okButton(){
		play_button.SetActive(true);
		rules_button.SetActive(true);
		ok_button.SetActive (false);
		rules_text.SetActive (false);
	}
}
