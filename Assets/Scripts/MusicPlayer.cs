using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null; // Init as no MusicPlayer // This is an example of a singleton pattern.
	private WinMusic winMusic;
	
	// 
	// Before start
	//
	void Awake () {
		Debug.Log ("Music player Awake " + GetInstanceID());
		
		// Kill win music if player navigates from the win screen
		winMusic = GameObject.FindObjectOfType<WinMusic>();
        AudioSource clip;
        if (winMusic) {
            clip = winMusic.audio;
            clip.Stop();
        };
	

		
		// Keep multiple instances of music player from starting up
		if (instance != null) { // If a MusicPlayer instance exists
			Destroy (gameObject);
			print ("Duplicate music player destructed.");
		} else { // Claim current MusicPlayer -> Only triggered the first time this script runs.
			instance = this; // this = the class level instance of MusicPlayer
			//GameObject.DontDestroyOnLoad(gameObject); // Arg is instance of the music player object - Make music persist through level change.
		}
	}

	// 
	// Initialize
	//
	void Start () {
		Debug.Log ("Music player Start " + GetInstanceID());

	}
}
