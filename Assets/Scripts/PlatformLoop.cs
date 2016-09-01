using UnityEngine;
using System.Collections;

public class PlatformLoop : MonoBehaviour {
	
	private Transform playerTransform;
	private float boundsExtentsX;

	void Start(){
		playerTransform = GameObject.Find ("Player").transform;
		SpriteRenderer rdr = GetComponent<SpriteRenderer> ();
		boundsExtentsX = rdr.bounds.extents.x;
	}

	void OnBecameInvisible(){
		if(transform.position.x < playerTransform.position.x){
			transform.position = new Vector2 (
				//That's X:
				+SceneScript.instance.prevPositionX
				+ SceneScript.instance.prevX
				+ boundsExtentsX
				+ SceneScript.instance.distanceBetween,
				//That's Y:
				+ SceneScript.instance.prevPositionY
				+ SceneScript.instance.DistanceFromY()
			);

			SceneScript.instance.prevPositionX = transform.position.x;
			SceneScript.instance.prevX = boundsExtentsX;
			SceneScript.instance.prevPositionY = transform.position.y;
		}
	}
}
