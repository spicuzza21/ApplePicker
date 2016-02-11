using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int score = 1000;

	void Awake(){
		//if the applepickerhighscore already exists, read it 
		if (PlayerPrefs.HasKey ("ApplePickerHighScore")) {
			score = PlayerPrefs.GetInt ("ApplePickerHighScore");
		}
	}

	void update() {
		GUIText gt = this.GetComponent<GUIText> ();
		gt.text = "High Score: " + score;
		//Update Applepicker high score in player prefs if necessary
			if (score > PlayerPrefs.GetInt("ApplePickerHighScore")){
				PlayerPrefs.SetInt("ApplePickerHighScore",score);
		}
	}
}
