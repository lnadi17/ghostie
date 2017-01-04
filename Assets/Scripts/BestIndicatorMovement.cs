using System.Collections;
using UnityEngine;

public class BestIndicatorMovement : MonoBehaviour {
	private Transform camTransform;
	private Transform previousBestText;
	private float camHalfWidth;

	void Start () {
		previousBestText = transform.FindChild("PreviousBestText");
		camTransform = Camera.main.transform;
		SetUpBestScoreText();
		camHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
	}


	void Update(){
		if(camTransform.position.x < transform.position.x + camHalfWidth * 2){
			float y = Mathf.Lerp(
				previousBestText.position.y, 
				camTransform.position.y, 
				3f * Time.deltaTime);
			previousBestText.position = new Vector2(previousBestText.position.x, y);
		}
	}


	void SetUpBestScoreText(){
		TextMesh previousBestScore  = previousBestText.FindChild("PreviousBestScore").GetComponent<TextMesh>();
		if(PlayerPrefs.HasKey("PlayerScore")){
			previousBestScore.text = PlayerPrefs.GetInt("PlayerScore").ToString() + "m";
			StartCoroutine(TweakLocation());
		}
	}


	IEnumerator TweakLocation(){
		while(camTransform.position.x < transform.position.x - camHalfWidth * 2){
			transform.position = new Vector2(transform.position.x, camTransform.position.y);
			previousBestText.position = new Vector2(previousBestText.position.x, camTransform.position.y);
			yield return new WaitForSeconds(1f);
		}
	}
}
