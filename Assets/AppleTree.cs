using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	//Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed at which the Apple Tree moves in meters/second
	public float speed=1f;

	//distance where the appletree turns around
	public float leftAndRightEdge=10f;

	//chance that the AppleTree will change direction
	public float chanceToChangeDirection=0.1f;

	//Rate at which apples will be initiated
	public float secondsBetweenAppleDrops=1f;

	// Use this for initialization
	void Start () {
		//dropping apples every second
		InvokeRepeating("DropApple",2f,secondsBetweenAppleDrops);
	}

	void DropApple()
	{
		GameObject Apple = Instantiate(applePrefab) as GameObject;
		Apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//changing direction 
		if (pos.x <  -leftAndRightEdge) {
			speed = Mathf.Abs(speed);//move right
		}
		else if (pos.x > leftAndRightEdge) {
			speed =  -Mathf.Abs (speed);//Move left
		} 
	}

	void FixedUpdate() {
		//changing direction randomly
		if (Random.value < chanceToChangeDirection) {
			speed *= -1; //change direction
		}
	}
}
