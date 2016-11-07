using UnityEngine;
using System.Collections;

public class BackgroundLoop : MonoBehaviour {

	public float distanceBetween;

	private SpriteRenderer rdr;
	private Transform cameraTransform;


	void Start(){
		rdr = GetComponent<SpriteRenderer> ();
		cameraTransform = Camera.main.transform;
		StartCoroutine (CheckForReposition ());
	}


	IEnumerator CheckForReposition(){
		while (true) {
			yield return new WaitForSeconds (1f);
			if (!rdr.isVisible && transform.position.x < cameraTransform.position.x) {
				transform.Translate (new Vector2 (distanceBetween * 2, 0));
			}
		}
	}
}