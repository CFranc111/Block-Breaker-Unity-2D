using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
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
		levelManager.LoadLevel("Lose");	
	}
}
