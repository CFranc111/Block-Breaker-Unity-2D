using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

//	private Camera camera;
	public AudioClip loseLife;
	private LevelManager levelManager;
	private TextController textController;
	private Ball ball;
	public static int totalLives = 5;
	private int livesLeft;
	public bool debug = true;
	
	//
	// Initialize
	//
	void Start () {
		livesLeft = totalLives;
//		loseLife = GetComponent<AudioSource>();
		
		// Link the level mgr 
		levelManager = Object.FindObjectOfType<LevelManager>();	
		textController = GameObject.FindObjectOfType<TextController>();
		
//		camera = Object.FindObjectOfType<Camera>();	
	}

	//
	// On trigger enter
	//
	void OnTriggerEnter2D (Collider2D trigger) { // type, name = instance passed in
	
		// Lose a life
		if (livesLeft > 0) {
			AudioSource.PlayClipAtPoint (loseLife, transform.position);
			livesLeft--;
//			camera.LoseLifeBg();
			textController.SetLivesText(livesLeft, totalLives);
			if (debug) Debug.Log ("Lives left: " + livesLeft);
		} 
		
		// Handle game lost
		if (livesLeft == 0) { 
			Invoke("gameOver", 1);
		} else {
			ball = GameObject.FindObjectOfType<Ball>(); // The current ball instance
			ball.ResetBall();
		}
	
	}
	
	void gameOver () {
		levelManager.LoadLevel("Lose");	
	}
}
