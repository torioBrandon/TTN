using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour {

	public GameObject countdown_display;
	public GameObject countdown_display2;
	//countdown before match starts
	void Start () {
		StartCoroutine (Countdown());
	}

	IEnumerator Countdown(){
		Debug.Log ("3");
		yield return new WaitForSeconds(1);
		Debug.Log ("2");
		countdown_display.GetComponentInChildren<Text>().text = "2";
		countdown_display2.GetComponentInChildren<Text>().text = "2";
		yield return new WaitForSeconds(1);
		countdown_display2.GetComponentInChildren<Text>().text = "1";
		countdown_display.GetComponentInChildren<Text>().text = "1";
		Debug.Log ("1");
		yield return new WaitForSeconds(1);
		Application.LoadLevel ("TTN Gameplay");

	}
}
