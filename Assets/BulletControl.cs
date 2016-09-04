using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	public float speed;

	void Start () {
		Destroy (gameObject, 3f);
	}
	
	void Update () {
		transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}

	void OnTriggerEnter2D(Collider2D other){
		print (other.tag);
	}
}
