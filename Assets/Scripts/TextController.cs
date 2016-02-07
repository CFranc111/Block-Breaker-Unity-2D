using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private Color initColor;
	
	void Start () {
		initColor = text.color;
	}
	
	public void SetLivesText (int livesLeft, int totalLives) {
		text.text = "Lives: " + livesLeft + "/" + totalLives;
		text.color = Color.red;
		Invoke ("resetColor", 1);
	}
	
	void resetColor () {
		text.color = initColor;
	}

}
