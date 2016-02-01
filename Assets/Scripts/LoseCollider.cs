﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private Ball ball;
	public int livesLeft = 3;
	public bool debug = true;
	
	//
	// Initialize
	//
	void Start () {
		// Link the level mgr with the lose collider
		levelManager = Object.FindObjectOfType<LevelManager>();
	}

	//
	// On trigger enter
	//
	void OnTriggerEnter2D (Collider2D trigger) { // type, name = instance passed in
	
		// Lose a life
		livesLeft--;
		if (debug) Debug.Log ("Lives left: " + livesLeft);
		
		if (livesLeft < 1) {
			levelManager.LoadLevel("Lose");	
		} else {
			ball = GameObject.FindObjectOfType<Ball>(); // The current ball instance
			ball.ResetBall();
		}
	
	}
}
