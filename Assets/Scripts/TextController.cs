using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private Color initColor;
	
	void Start () {
		initColor = text.color;
	}
	
	public void SetLivesText (int livesLeft) {
		text.text = "Lives Remaining: " + livesLeft;
		text.color = Color.red;
		Invoke ("resetColor", 1);
	}
	
	void resetColor () {
		text.color = initColor;
	}

}
