using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniSceneManager : MonoBehaviour {
		
	private AsyncOperation op;


	void Start (){
		StartCoroutine(LoadRoutine());
	}


	private IEnumerator LoadRoutine(){
		op = SceneManager.LoadSceneAsync ("Main");
		op.allowSceneActivation = false;
		yield return null;
	}


	public void LoadMainScene(){
		if (op.progress >= 0.9f) {
			op.allowSceneActivation = true;
		}
	}


	public void ReloadScene(){
		LoadMainScene ();
	}


	public void BackToMenu(){
		SceneManager.LoadScene ("MenuScene");
	}
}
