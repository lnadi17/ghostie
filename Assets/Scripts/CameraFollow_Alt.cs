using UnityEngine;
using System.Collections;

public class CameraFollow_Alt: MonoBehaviour {

	public Transform playerTransform;
	[Range(-1f,1f)]
	public float cameraOffsetX;

	private float cameraHalfWidth;


	void Start () {
		cameraHalfWidth =  Camera.main.orthographicSize * Camera.main.aspect;
	}
	

	void Update () {
		if (ChangeOrNot ()) {
			Vector2 futurePos = Vector2.Lerp (transform.position, playerTransform.position, 0.1f);
			transform.position = new Vector3 (playerTransform.position.x - cameraHalfWidth * cameraOffsetX, futurePos.y, -10);
		} else {
			transform.position = new Vector3 (playerTransform.position.x - cameraHalfWidth * cameraOffsetX, transform.position.y, -10);
		}
	}


	bool ChangeOrNot(){
		if(PlayerMovement.grounded){
			return true;
		}
		return false;
	}
}
