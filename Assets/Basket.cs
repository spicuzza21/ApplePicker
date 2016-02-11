using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;

	// Update is called once per frame
	void Update () {
	//Get the current screen position of the mouse from the input
		Vector3 mousePos2D = Input.mousePosition;//1
	
	//The camera's z position sets the how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z; //2

	//convert the point from 2d screen space into 3d game work space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );//3

	//move the x position of this basket to the x position of the mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}
		
		void start()
	{
		//find reference to the Score counter gameobject
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		//Get the GUI text component of that game object
		scoreGT = scoreGO.GetComponent<GUIText> ();
		//set the starting number to 0
		scoreGT.text = "0";
	}

	void OnCollisionEnter( Collision coll ) {
		//Find out what hit the basket
		GameObject collideWith = coll.gameObject;
		if (collideWith.tag == "Apple") {
			Destroy (collideWith);
		}

	//parse the text of the scoregt into an int
		int score = int.Parse( scoreGT.text );
		//add points for catching the apple
		score += 100;
		//convert the score back to a string and display it
		scoreGT.text = score.ToString();

		//track the high score
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
