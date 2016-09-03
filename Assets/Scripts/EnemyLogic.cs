using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	private float speed = 1.5f;
	private Rigidbody2D rb2d;
	//private BoxCollider2D boxCol;
	private bool visible;
	private float maxLeft;
	private float maxRight;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		//boxCol = GetComponent<BoxCollider2D> ();
		maxLeft = transform.position.x - SceneScript.instance.prevX;
		maxRight = transform.position.x + SceneScript.instance.prevX;
		transform.position = RandomStartingPoint (maxLeft, maxRight);
	}
	
	void Update () {

		//Speed is units per second.
		transform.position = new Vector2(PingPong(Time.time * speed, maxLeft, maxRight), transform.position.y);

		//Moves smoothly, useful code (don't delete).
		/*
		transform.position = Vector2.Lerp(
			new Vector2(maxLeft, transform.position.y), 
			new Vector2(maxRight, transform.position.y,
			Mathf.SmoothStep(
				0f,
				1f,
				Mathf.PingPong(Time.time,1f)
			)
		);
		*/
	}

	//Manipulated PingPong function, to change the default starting value of (0, 0, 0) to any value.
	float PingPong(float t, float minLength, float maxLength) {
		return Mathf.PingPong(t, maxLength - minLength) + minLength;
	}

	Vector2 RandomStartingPoint(float maxLeft, float maxRight){
		float posX = UnityEngine.Random.Range (maxLeft, maxRight);
		float posY = transform.position.y;
		return new Vector2 (posX, posY);
	}

	void OnBecameVisible(){
		visible = true;
	}

	void OnBecameInvisible(){
		visible = false;
	}
}