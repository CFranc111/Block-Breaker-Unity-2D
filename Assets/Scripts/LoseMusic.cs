using UnityEngine;
using System.Collections;

public class LoseMusic : MonoBehaviour {

	static LoseMusic instance = null; // Init as no MusicPlayer // This is an example of a singleton pattern.
	
	// 
	// Before start
	//
	void Awake () {
		Debug.Log ("Music player Awake " + GetInstanceID());
		
		// Keep multiple instances of music player from starting up
		if (instance != null) { // If a MusicPlayer instance exists
			Destroy (gameObject);
			print ("Duplicate music player destructed.");
		} else { // Claim current MusicPlayer -> Only triggered the first time this script runs.
			instance = this; // this = the class level instance of MusicPlayer
			GameObject.DontDestroyOnLoad(gameObject); // Arg is instance of the music player object - Make music persist through level change.
		}

	}

	// 
	// Initialize
	//
	void Start () {
		Debug.Log ("LoseMusic instace started: " + GetInstanceID());
	}
}
