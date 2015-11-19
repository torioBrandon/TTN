using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	public GameObject[] spaces; 
	public bool[] usedSpaces;
	public GameObject turn_display;
	public GameObject o_score_display;
	public GameObject x_score_display;

	public bool[] won_rows = new bool[4];
	public bool[] won_columns = new bool[4];

	static int turns_taken;

	public string[,] space_value;
	public string[] space_map;
	public bool turn = false; 	//false is player, true is AI
	public bool XO = false;

	public static int player_one_score = 0;
	public static int player_two_score = 0;

	static float match_time = 30.0f;


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
			//Debug.Log ("user put an O down at space " + int.Parse (spaceClicked.name));
			space_map[space_number] = "O";
			spaceClicked.GetComponentInChildren<Text>().text = "O";

		}
		else{	//X
			//Debug.Log ("user put a X down at space " + int.Parse (spaceClicked.name) );			
			space_map[space_number] = "X";
			spaceClicked.GetComponentInChildren<Text>().text = "X";


		}
		turns_taken++;
		usedSpaces[space_number] = true;	//mark that the space is used

		space_value [Mathf.CeilToInt (space_number / 4), Mathf.CeilToInt (space_number % 4)] = (string)space_map [space_number];

		checkForWin (space_number);
		
	}

	//called whenever a player clicks a space
	public bool checkForWin(int space_number){

		int same_row_values = 0;
		int same_col_values = 0;
		int same_diagonal_rl = 0;
		int same_diagonal_lr = 0;

		bool diagonal_big_win_rl = false;
		bool diagonal_big_win_lr = false;

		bool[] col_small_win = new bool[4];
		bool[] row_small_win = new bool[4];
		bool[] col_big_win = new bool[4];
		bool[] row_big_win = new bool[4];

		int col = Mathf.CeilToInt (space_number % 4);
		int row = Mathf.CeilToInt (space_number / 4);

		if (!XO) {	//
			for (int i = 0; i<=3; i++) {
				if (space_value [row, i].Equals ("X")) {
					same_col_values++;
				}else{
					if(i == 1 || i == 2)
						same_col_values = 0;
				}
			}
			if (same_col_values == 3) {	//small win at row row
				if(!row_small_win[row] && !row_big_win[row]){
					player_two_score++;
					row_small_win[row] = true;
				}

			}
			if (same_col_values == 4) {
				if(!row_big_win[row]){
					player_two_score += 4;
					row_big_win[row] = true;
				}
			}
		}
		if (!XO) {	//last move was O's
			for (int i = 0; i<=3; i++) {
				if (space_value [i , col].Equals ("X")) {
					same_row_values++;
				}else{
					if(i == 1 || i == 2)
						same_row_values = 0;
				}
			}
			if (same_row_values == 3) {	//small win at row row
				if(!col_small_win[col] && !col_big_win[col]){
					player_two_score++;
					col_small_win[col] = true;
				}
				
			}
			if (same_row_values == 4) {
				if(!col_big_win[col]){
					player_two_score += 4;
					col_big_win[col] = true;
				}
			}
		}
		//big diagonal win right to left check for x
		if (!XO) {
			for(int i = 0; i<4; i++){
				if(space_value[i, i].Equals("X")){
					same_diagonal_rl++;
				}
			}
			if(same_diagonal_rl == 4 && !diagonal_big_win_rl){
				diagonal_big_win_rl = true;
				player_two_score+=4;
			}
		}

		


		if (XO) {	//
			for (int i = 0; i<=3; i++) {
				if (space_value [row, i].Equals ("O")) {
					same_col_values++;
				}else{
					if(i == 1 || i == 2)
						same_col_values = 0;
				}
			}
			if (same_col_values == 3) {	//small win at row row
				if(!row_small_win[row] && !row_big_win[row]){
					player_one_score++;
					row_small_win[row] = true;
				}
				
			}
			if (same_col_values == 4) {
				if(!row_big_win[row]){
					player_one_score += 4;
					row_big_win[row] = true;
				}
			}
		}
		if (XO) {	//last move was O's
			for (int i = 0; i<=3; i++) {
				if (space_value [i , col].Equals ("O")) {
					same_row_values++;
				}else{
					if(i == 1 || i == 2)
						same_row_values = 0;
				}
			}
			if (same_row_values == 3) {	//small win at row row
				if(!col_small_win[col] && !col_big_win[col]){
					player_one_score++;
					col_small_win[col] = true;
				}
				
			}
			if (same_row_values == 4) {
				if(!col_big_win[col]){
					player_one_score += 4;
					col_big_win[col] = true;
				}
			}
		}

		


		same_col_values = 0;
		same_row_values = 0;

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
