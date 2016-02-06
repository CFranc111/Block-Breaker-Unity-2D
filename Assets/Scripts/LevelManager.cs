using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//
	// Load specific level
	//
	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	//
	// Load next level
	//
	public void LoadNextLevel() { // Subsequent levels
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	// 
	// Load next level when player beats level
	//
	public void BrickDestroyed() {
		if(Brick.breakableCount <= 0) {
			Invoke("LoadNextLevel", 5);
		}
	}
}
