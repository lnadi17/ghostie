using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private KeyCode left;
	private KeyCode right;
	private bool facingRight;
	private SpriteRenderer playerSpriteRenderer;

	void Start () {
		left = KeyCode.A;
		right = KeyCode.D;
		facingRight = true;
		playerSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void FixedUpdate () {

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
	}
}
