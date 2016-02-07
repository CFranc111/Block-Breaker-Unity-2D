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
		camera.backgroundColor = bgColor2;
		Invoke ("ResetBgColor", 1);
	}
	
	void ResetBgColor () {
		camera.backgroundColor = bgColor1;
	}
	
	
	
}
