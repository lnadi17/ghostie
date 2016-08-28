using UnityEngine;
using System.Collections;

public class CameraFollow_1 : MonoBehaviour {

	public Transform playerTransform;

	private float cameraHalfHeight;
	private float cameraHalfWidth;

	void Start () {
		cameraHalfHeight = Camera.main.orthographicSize;
		cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
	}
	
	void Update () {
		if (ChangeOrNot ()) {
			Vector2 futurePos = Vector2.Lerp (transform.position, playerTransform.position, 0.1f);
			transform.position = new Vector3 (playerTransform.position.x, futurePos.y, -10);
		} else {
			transform.position = new Vector3 (playerTransform.position.x, transform.position.y, -10);
		}
	}

	bool ChangeOrNot(){
		if(PlayerMovement.grounded){
			return true;
		}
		return false;
	}
}
