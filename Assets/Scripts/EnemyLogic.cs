﻿using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	private float speed = 1.5f;
	private Rigidbody2D rb2d;
	private SpriteRenderer rdr;
	private bool visible;
	private float maxLeft;
	private float maxRight;
	private float randomFloat;

	private bool movingRight;
	private bool movingLeft;

	private float _tempX;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rdr = GetComponent<SpriteRenderer> ();
		maxLeft = rb2d.position.x - SceneScript.instance.prevX;
		maxRight = rb2d.position.x + SceneScript.instance.prevX;
		randomFloat = RandomFloat();
	}
	
	void Update () {

		//Speed is units per second.
		rb2d.position = new Vector2 (PingPong (Time.time * speed + randomFloat, maxLeft, maxRight), rb2d.position.y);

		if(rb2d.position.x > _tempX && movingLeft){
			rdr.flipX = !rdr.flipX;
		}

		if(rb2d.position.x < _tempX && movingRight){
			rdr.flipX = !rdr.flipX;
		}

		if(rb2d.position.x > _tempX){
			movingRight = true;
			movingLeft = false;
		}

		if(rb2d.position.x < _tempX){
			movingLeft = true;
			movingRight = false;
		}

		_tempX = rb2d.position.x;

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
		float posY = rb2d.position.y;
		return new Vector2 (posX, posY);
	}

	float RandomFloat(){
		return UnityEngine.Random.Range (0f, 5f);
	}

	void OnBecameVisible(){
		visible = true;
	}

	void OnBecameInvisible(){
		if(rb2d.position.x < Camera.main.transform.position.x){
			Destroy (gameObject, 1);
		}
	}
}