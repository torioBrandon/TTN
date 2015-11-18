using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	public GameObject[] spaces; 
	public bool[] usedSpaces;
	public GameObject turn_display;
	public GameObject o_score_display;
	public GameObject x_score_display;

	static int turns_taken;

	public string[,] space_value;
	public string[] space_map;
	public bool turn = false; 	//false is player, true is AI
	public bool XO = false;

	public static int player_one_score = 0;
	public static int player_two_score = 0;


	float turn_start_time; 

	// Use this for initialization
	void Start () {
		XO = Choice_Manager.X_or_O;
		space_value = new string[4,4];
		for (int i = 0; i<=3; i++) {
			for (int j = 0; j<=3; j++) {
				space_value[i, j] = "";
			}			
		}
		turn_start_time = Time.time;	
	//	turn_display = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		o_score_display.GetComponentInChildren<Text> ().text = "O Score: " + player_one_score;
		x_score_display.GetComponentInChildren<Text> ().text = "X Score: " + player_two_score;

		if (XO) {
			turn_display.GetComponentInChildren<Text>().text = "O's turn, " + Mathf.Round((3 - (Time.time - turn_start_time)) * 100f)/100f;
		} else {
			turn_display.GetComponentInChildren<Text>().text = "X's turn, " + Mathf.Round((3 - (Time.time - turn_start_time)) * 100f)/100f;
		}
		if (Time.time - turn_start_time >= 3.0f){
			Debug.Log ("time's up");
			turn_start_time = Time.time;
			XO =! XO;
		}
	}

	public void spaceClicked(GameObject spaceClicked){
		
		int space_number = int.Parse(spaceClicked.name);	//use the name of the game object to index the array
		if (usedSpaces [space_number]) {
			Debug.Log("space already used");
			return; 
		}
		//place the X or O
		if(XO){	//O
			Debug.Log ("user put an O down at space " + int.Parse (spaceClicked.name));
			space_map[space_number] = "O";
			spaceClicked.GetComponentInChildren<Text>().text = "O";

		}
		else{	//X
			Debug.Log ("user put a X down at space " + int.Parse (spaceClicked.name) );			
			space_map[space_number] = "X";
			spaceClicked.GetComponentInChildren<Text>().text = "X";


		}
		turns_taken++;
		usedSpaces[space_number] = true;	//mark that the space is used

		space_value [Mathf.CeilToInt (space_number / 4), Mathf.CeilToInt (space_number % 4)] = (string)space_map [space_number];

		checkForWin ();
		
	}

	//called whenever a player clicks a space
	public bool checkForWin(){

		//check for big horizontal win
		for (int i = 0; i<=3; i++) {
			if(space_value[i, 0].Equals(space_value[i, 1]) && space_value[i, 0].Equals(space_value[i, 2])
			   && space_value[i, 0].Equals(space_value[i, 3])){
				if(space_value[i, 0].Equals("") || space_value[i, 1].Equals("") || space_value[i, 2].Equals("") || space_value[i, 3].Equals("")){

				}else{
					Debug.Log ("Horizontal big win at row " + i + " for " + XO + " (false is x)");
					if(XO){
						player_two_score+=4;
					}else{
						player_one_score+=4;
					}
				}
			}
		}

		//check for big vertical win
		for (int i = 0; i<=3; i++) {		
			if(space_value[0, i].Equals(space_value[1, i]) && space_value[0, i].Equals(space_value[2, i])
			   && space_value[0, i].Equals(space_value[3, i])){
					if(space_value[0, i].Equals("") || space_value[1, i].Equals("") || space_value[2, i].Equals("") || space_value[3, i].Equals("")){
						
					}else{	
						if(XO){
							player_two_score+=4;
						}else{
							player_one_score+=4;
						}
						Debug.Log ("Vertical win at column " + i + " for " + XO + " (false is x)");
					}
			}
		}

		//check for big diagonal win
		if (space_value [0, 0].Equals (space_value [1, 1]) && space_value [0, 0].Equals (space_value [2, 2])
			&& space_value [0, 0].Equals (space_value [3, 3])) {
			if(space_value[0, 0].Equals("") || space_value[1, 1].Equals("") || space_value[2, 2].Equals("") || space_value[3, 3].Equals("")){

			}else{	
				if(XO){
					player_two_score+=4;
				}else{
					player_one_score+=4;
				}
				Debug.Log ("Diagonal Big Win for " + XO);
			}
		}
		if (space_value [0, 3].Equals (space_value [1, 2]) && space_value [0, 3].Equals (space_value [2, 1])
		    && space_value [0, 3].Equals (space_value [3, 0])) {
			if(space_value[0, 3].Equals("") || space_value[1, 2].Equals("") || space_value[2, 1].Equals("") || space_value[3, 0].Equals("")){
				
			}else{	
				if(XO){
					player_two_score+=4;
				}else{
					player_one_score+=4;
				}
				Debug.Log ("Diagonal Big Win for " + XO);
			}
		}


		XO = !XO;
		turn_start_time = Time.time;
		if (turns_taken == 16)
			clearBoard ();
		return true;
	}

	public void clearBoard(){
		foreach(GameObject g in spaces){
			g.GetComponentInChildren<Text>().text = "";
		}
		for (int i = 0; i<16; i++) {
			space_map[i] = "";
			usedSpaces[i] = false;
		}
		for (int i = 0; i<=3; i++) {
			for (int j = 0; j<=3; j++) {
				space_value[i, j] = "";
			}			
		}
	}
}

