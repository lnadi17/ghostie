using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpForce;

	private KeyCode left;
	private KeyCode right;
	private KeyCode up;

	private bool facingRight;
	private bool jumped;
	private bool grounded;
	private SpriteRenderer playerSpriteRenderer;
	private Rigidbody2D playerRigidbody;
	private Transform groundCheck;

	void Start () {
		/*Temporary*/
		left = KeyCode.A;
		right = KeyCode.D;
		up = KeyCode.W;

		facingRight = true;
		playerSpriteRenderer = GetComponent<SpriteRenderer> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		groundCheck = transform.FindChild ("GroundCheck");
	}
	
	void Update () {
		if (facingRight) {
			playerSpriteRenderer.flipX = false;
		} else {
			playerSpriteRenderer.flipX = true;
		}


		if (Input.GetKey (right)) {
			facingRight = true;
			transform.Translate(new Vector2(0.1f * speed, 0));
		}

		if (Input.GetKey(left)){
			facingRight = false;
			transform.Translate(new Vector2(-0.1f * speed, 0));
		}

		CheckIfGrounded ();
		if (grounded && Input.GetKeyDown (up)) {
			Vector2 jumpVector = (Vector2.up * jumpForce);
			playerRigidbody.AddForce (jumpVector);
			print ("jumped");
			jumped = true;
		}
	}

	void CheckIfGrounded(){
		grounded = Physics2D.Linecast (transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));
	}
}