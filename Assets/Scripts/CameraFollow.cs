using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform playerTransform;

	private Transform cameraTransform;
	private Transform castleTransform;
	private float allowedOffset;

	void Start () {
		cameraTransform = Camera.main.transform;
		castleTransform = cameraTransform.FindChild ("Background").FindChild ("Castle").transform;
	}

	void Update(){
		if (Mathf.Abs(playerTransform.position.y - cameraTransform.position.y) > float.Epsilon) {
			Vector3 futurePosition = Vector3.Lerp (cameraTransform.position, playerTransform.position, 0.01f);
			cameraTransform.position = new Vector3 (playerTransform.position.x, futurePosition.y, -10);
		}
	}
}