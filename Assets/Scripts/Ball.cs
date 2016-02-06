using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool debug = false;

	private Paddle paddle;
	private bool hasStarted = false;
	private string[] makeHitSounds = new string[6] {"Paddle", "LeftWall", "RightWall", "TopWall", "BottomWall", "Invincible"};
	private Vector3 paddleToBallVector; // Paddle's position minus ball's position
	private float nudgeFactor = 0.2f; // Max random nudge added to the velocity of each collision (to reduce boring play loops and increase ball speed)
	private float maxSpeed = 15f;// Magnitude to constrain ball speed
	private float minSpeed = 7f;

	//
	// Initialization
	//
	void Start () {
	
		paddle = GameObject.FindObjectOfType<Paddle>(); // Get this paddle
		paddleToBallVector = this.transform.position - paddle.transform.position; // Used to initialize position below
	}
	
	//
	// Called once per frame
	//
	void Update () {
	
		// Reset position if game not yet started
		if (!hasStarted) {
		
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for mouse click to launch
			if (Input.GetMouseButtonDown(0)) { 
				hasStarted = true; // Won't run again once one mouse click occurs
				// Set initial ball velocity
				this.rigidbody2D.velocity = new Vector2 (0f, 1f); // x, y
				
				// Add some spin
//				rigidbody2D.AddTorque(10f);
			}
		}
	}
	
	//
	// Generate a random float between zero and the nudgefactor
	//
	float RandomFloat () {
		return Random.Range(0, nudgeFactor);
	} 
	
	//
	// Get the ball's velocity
	//
	Vector2 BallVelocity () { 
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		return rb.velocity;
	}
	
	//
	// Nudge the velocity to avoid boring play loops and speed up ball
	//
	void VelociNudge(Vector2 exitVelocity) {
		
		// Build and apply nudge
		Vector2 nudge;
		switch (exitVelocity.x > 0) { 
			case false: // x is -
				switch (exitVelocity.y > 0) {
					case false: // y is -
						nudge.x = -RandomFloat();
						nudge.y = -RandomFloat();
						this.rigidbody2D.velocity += nudge;
						if (debug) print ("nudge: " + nudge);
						break;
					case true: // y is +
						nudge.x = -RandomFloat();
						nudge.y = RandomFloat();
						this.rigidbody2D.velocity += nudge; 
						if (debug) print ("nudge: " + nudge);
						break;
					default:
						Debug.LogError("Exit velocity y: " + exitVelocity.y);
						break;
					}
					break;
			case true: // x is +
				switch (exitVelocity.y > 0) {
					case false: // y is -
						nudge.x = RandomFloat();
						nudge.y = -RandomFloat();
						this.rigidbody2D.velocity += nudge;
						if (debug) print ("nudge: " + nudge);
						break;
					case true: // y is +
						nudge.x = RandomFloat();
						nudge.y = RandomFloat();
						this.rigidbody2D.velocity += nudge;
						if (debug) print ("nudge: " + nudge);
						break;
					default:
					Debug.LogError("Exit velocity y: " + exitVelocity.y);
						break;
					}
					break;
			default:
				Debug.LogError("Exit velocity x: " + exitVelocity.x);
				break;
		}
	}
	
	//
	// When ball exits a collision
	//
	void OnCollisionExit2D(Collision2D coll) {
		
		if (hasStarted) { // Don't apply at very beginning when ball placed on paddle
		
			if (System.Array.IndexOf(makeHitSounds, coll.gameObject.name) > -1) {
				audio.Play(); // Play basic hit sound if appropriate
			}
			
			// Get the ball's outbound velocity
			Vector2 exitVelocity = BallVelocity();
			
			// Set up ball to nudge more upward if it hits wall very close to paddle (experimental)
			if (transform.position.y < 2f) {
				exitVelocity.y += 5f;
			}
			
			// Reset magnitude if ball gets too fast or too slow
			if (debug) print("Magnitude: " + this.rigidbody2D.velocity.magnitude);
			
			// Speed check
			if (exitVelocity.magnitude > maxSpeed) {
				this.rigidbody2D.velocity = exitVelocity = this.rigidbody2D.velocity.normalized * maxSpeed; // normalize = make magnitude 1
			} else if (exitVelocity.magnitude < minSpeed) {
				this.rigidbody2D.velocity = exitVelocity = this.rigidbody2D.velocity.normalized * minSpeed; 
			}
			
			// Apply velocity nudge
			VelociNudge(exitVelocity);
			
		} // /if hasStarted

	}
	
	public void ResetBall() {
		// Short delay before reseting ball
		Invoke ("DoReset", 2);
	}
	
	private void DoReset() {
		hasStarted = false;
	}
}
