using UnityEngine;
using System.Collections;

public class BackgroundLoop : MonoBehaviour {

	public float distanceBetween;

	void OnBecameInvisible(){
		if (transform.position.x < Camera.main.transform.position.x) {
			transform.Translate (new Vector2 (distanceBetween * 2, 0));
		}
	}
}