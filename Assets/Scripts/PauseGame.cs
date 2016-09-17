using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	public GameObject[] activeOnPause;
	public GameObject[] activeOnResume;
	

	private PlayerMovement pMovement;
	private CameraFollow_Alt cFollow;

	void Start () {
		pMovement = GetComponent<PlayerMovement> ();
		cFollow = Camera.main.GetComponent<CameraFollow_Alt> ();
	}

	public void Pause(){
		foreach (GameObject ob in activeOnPause) {
			ob.SetActive (true);	
		}
		foreach (GameObject ob in activeOnResume) {
			ob.SetActive (false);
		}
		pMovement.enabled = false;
		cFollow.enabled = false;
		Time.timeScale = 0;
	}

	public void Resume(){
		foreach (GameObject ob in activeOnPause) {
			ob.SetActive (false);
		}
		foreach (GameObject ob in activeOnResume) {
			ob.SetActive (true);
		}
		pMovement.enabled = true;
		cFollow.enabled = true;
		Time.timeScale = 1;
	}

	public void VolumeChanged(){
		
	}
}
