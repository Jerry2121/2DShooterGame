using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

	public float Movement_Speed = 3.0f;
    //  public GameObject Timertext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//horizontal stores the user input when they press
		//a, d, left, right on a scale from -1 to 1
		float horizontal = Input.GetAxis("Horizontal");
		//vertical stores the user input when they press
		//w, s, up, down on a scale from -1 to 1
		float vertical = Input.GetAxis ("Vertical");
		//create a puish variable that combines the user input
		Vector2 push = new Vector2 (horizontal, vertical);
		//use push to change the velocity of the object
		gameObject.GetComponent<Rigidbody2D> ().velocity = push * Movement_Speed;
	}
}
