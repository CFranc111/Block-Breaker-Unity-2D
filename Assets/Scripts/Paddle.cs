using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false; // For play testing, set in Inspector
	public float minX, maxX; // Set in Inspector
	
	private Ball ball;
	
	//
	// Initialize
	//
	void Start () {
		autoPlay = false;
		ball = GameObject.FindObjectOfType<Ball>(); // The current ball instance
	}

	//
	// Once per frame
	//
	void Update () {
	
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	//
	// AutoPlay for play testing
	//
	void AutoPlay () { // Move mouse to Y position of mouse
		Vector3 paddlePos = new Vector3 (minX, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX); 
		this.transform.position = paddlePos;
	}
	
	//
	// For AutoPlay
	//
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (minX, this.transform.position.y, 0f); // y position is set in 
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; // Gives x position between 0 and 1, relative by screen width, converted to game units (16 horizontally on the screen)
		paddlePos.x =  Mathf.Clamp(mousePosInBlocks, minX, maxX); // f = float. Note we keep the existing y position. Clamp => then stay within these bounds
		this.transform.position = paddlePos;
	}
}
