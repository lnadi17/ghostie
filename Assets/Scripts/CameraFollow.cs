using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform playerTransform;

	[Range(0f,0.1f)]
	public float cameraFollowSpeed;
	[Range(-1f,1f)]
	public float cameraOffsetX;

	private Transform cameraTransform;
	private float cameraHalfWidth;


	void Start () {
		cameraTransform = Camera.main.transform;
		cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
	}


	void Update(){
		if (Mathf.Abs(playerTransform.position.y - cameraTransform.position.y) > float.Epsilon) {
			Vector3 futurePosition = Vector3.Lerp (cameraTransform.position, playerTransform.position, cameraFollowSpeed);
			cameraTransform.position = new Vector3 (playerTransform.position.x - cameraHalfWidth * cameraOffsetX, futurePosition.y, -10);
		}
	}
}