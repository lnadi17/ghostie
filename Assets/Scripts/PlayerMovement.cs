﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameObject bullet;

	[HideInInspector]
	public static bool grounded;

	public float speed;
	public float jumpForce;

	private bool facingRight;
	private SpriteRenderer playerSpriteRenderer;
	private Rigidbody2D playerRigidbody;
	private ParticleSystem pSystem;
	private Transform groundCheck;
	private float sinceShoot = 0f; 

	//Touch controls:
	//private int heightPixel;
	private int widthPixel;

	void Start () {
		facingRight = true;
		playerSpriteRenderer = GetComponent<SpriteRenderer> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find("GroundCheck");
		pSystem = groundCheck.GetComponent<ParticleSystem> ();

		//Touch controls:
		//heightPixel = Camera.main.pixelHeight;
		widthPixel = Camera.main.pixelWidth;
	}
	
	void Update () {
		if (facingRight) {
			playerSpriteRenderer.flipX = false;
			groundCheck.transform.position = new Vector2 (transform.position.x - 0.5f, groundCheck.position.y);
		} else {
			playerSpriteRenderer.flipX = true;
			groundCheck.transform.position = new Vector2 (transform.position.x + 0.5f, groundCheck.position.y);
		}

		//When playing starts:
		if (SceneScript.instance.playingStarted) {
			Debug.Log ("1");
			pSystem.Play();
			transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
		}

		CheckIfGrounded ();
		//if (grounded && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
		//if (grounded && Input.GetKeyDown(KeyCode.Space)){
		if (grounded && leftSideTouch()){
			if (!SceneScript.instance.playingStarted) {
				SceneScript.instance.playingStarted = true;
				Debug.Log ("2");
				return;
			}
			Vector2 jumpVector = (Vector2.up * jumpForce);
			playerRigidbody.velocity = Vector2.zero;
			playerRigidbody.AddForce (jumpVector);
		}

		sinceShoot += Time.deltaTime;
		if(rightSideTouch() && sinceShoot > 1){
		//if(Input.GetKeyDown(KeyCode.LeftShift) && sinceShoot > 1){
			Shoot ();
		}
	}

	void Shoot(){
		Instantiate (bullet, transform.position, Quaternion.identity);
		sinceShoot = 0;
	}

	void CheckIfGrounded(){
		grounded = Physics2D.Linecast (
			transform.position, 
			groundCheck.transform.position, 
			1 << LayerMask.NameToLayer("Ground")
		);
	}

	bool leftSideTouch(){
		/*if(Input.GetTouch(0).position.x < widthPixel * 0.5f && Input.GetTouch(0).phase == TouchPhase.Began){x
			return true;
		}*/
		foreach(Touch touch in Input.touches){
			if(touch.position.x < widthPixel * 0.5f && touch.phase == TouchPhase.Began){
				return true;
			}
		}
		return false;
	}

	bool rightSideTouch(){
		/*if(Input.GetTouch(0).position.x > widthPixel * 0.5f && Input.GetTouch(0).phase == TouchPhase.Began){
			return true;
		}*/
		foreach(Touch touch in Input.touches){
			if(touch.position.x > widthPixel * 0.5f && touch.phase == TouchPhase.Began){
				return true;
			}
		}
		return false;
	}
}