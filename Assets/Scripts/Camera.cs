using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private Color bgColor1; // Will hold default bg color, set in editor
	private Color bgColor2 = Color.red;

	private float duration = 3F;

	// Use this for initialization
	void Start () {
	
		// Setup for background color change
		camera.clearFlags = CameraClearFlags.SolidColor;
		bgColor1 = camera.backgroundColor;
	}
	
	public void LoseLifeBg () {
		// Change background color
		float t = Mathf.PingPong(Time.time, duration) / duration;
		camera.backgroundColor = Color.Lerp(bgColor1, bgColor2, t);
		Invoke ("ResetBgColor", 1);
	}
	
	void ResetBgColor () {
		camera.backgroundColor = bgColor1;
	}
	
	
	
}
