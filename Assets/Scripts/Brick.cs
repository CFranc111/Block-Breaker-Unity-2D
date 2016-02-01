using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip destroy;
	public AudioClip crack;
	public Sprite[] hitSprites; // Create sprite array
	public static int breakableCount = 0; // This static is available to all other classes (eg, LevelManager)
			
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	private Vector3 brickPos; 
	
	// 
	// Initialize
	//
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable"); // Called once for every brick
		if (isBreakable) {
			breakableCount++;
		}	
		
		// Get position
		brickPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		
	}	
	
	//
	// Each frame
	//
	void Update () {
		// Prohibit brick from getting bumped outside of play area ****** (ME -- BUG OBSERVED -- DOES IT WORK??) ******
		this.transform.position = brickPos;
	}
	
	//
	// With each hit, render the next sprite
	//
	void LoadSprites () {
	
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex]) { // Do nothing if mistakenly no sprite loaded
		   this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing.");
		}
	}
	
	//
	// Hit handler
	//
	void HandleHits () {
		timesHit++;
		
		// Max hits will always be hitSprites length +1
		int maxHits = hitSprites.Length + 1;
			
		// Destroy a brick or load next sprite
		if (timesHit >= maxHits) {
			AudioSource.PlayClipAtPoint (destroy, transform.position); // Play this sound at position of the brick (whether the brick is still there or not)
			breakableCount--; // Decrement # bricks remaining
			levelManager.BrickDestroyed(); // Check whether next
			Destroy(gameObject);
	
		} else {
			AudioSource.PlayClipAtPoint (crack, transform.position);
			LoadSprites(); 
		}	
	}
	
	//
	// On collision exit
	//
	void OnCollisionExit2D (Collision2D collision) {
				
		if (isBreakable) {
			HandleHits();
		}
	} 
}
