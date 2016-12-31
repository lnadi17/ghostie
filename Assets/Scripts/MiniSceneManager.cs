using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniSceneManager : MonoBehaviour {
	
	private AsyncOperation op;


	void Start (){
		StartCoroutine(LoadRoutine());
	}
	

	void Update () {
		if (Input.GetKey(KeyCode.Escape)){ 
			Application.Quit();
		}
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
