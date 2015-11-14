using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public GameObject space;
	public GameObject[] spaces; 
	public bool[] usedSpaces;
	public bool turn = false; 	//false is player, true is AI
	public int turnsPassed; //because you should only check for a win when this number hits 5
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spaceClicked(GameObject spaceClicked){

		//Debug.Log (int.Parse (spaceClicked.name));
		usedSpaces [int.Parse(spaceClicked.name)] = true;	//set that the space is no longer clickable 
		//Debug.Log (usedSpaces [int.Parse(spaceClicked.name)]);

		//place the X or O
		if (!turn) {	//if it is the player's turn
			if(Choice_Manager.X_or_O){
				Debug.Log ("user put an X down");
			}
			else{
				Debug.Log ("user put a O down");
			}
		}

		//check for a win - this could probably be hella optimized
		if (turnsPassed >= 5) {
			
		}



		turn = !turn;	//switch turns between player and AI
	}
}
