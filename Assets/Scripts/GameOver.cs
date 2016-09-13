using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public GameObject overCanvas;
	public Text scoreText;

	private Transform camTransform;

	void Start () {
		camTransform = Camera.main.transform;
	}
	
	void Update () {
		if(transform.position.y < camTransform.position.y - 5){
			SceneScript.instance.playingStarted = false;
			IfOver ();
		}
	}

	void IfOver(){
		overCanvas.SetActive (true);
		scoreText.text = SceneScript.instance.score.ToString () + "m";
	}
}
