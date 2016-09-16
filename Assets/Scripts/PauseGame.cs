using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public GameObject pauseGameObject;

	//private PlayerMovement pMovement;

	void Start () {
		//pMovement = GetComponent<PlayerMovement> ();
	}

	public void Pause(){
		Time.timeScale = 0;
	}

	public void Resume(){
		Time.timeScale = 1;
	}
}
