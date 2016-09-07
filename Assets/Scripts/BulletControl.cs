using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	public float speed;

	void Start () {
		Destroy (gameObject, 1f);
	}
	
	void Update () {
		transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}
}
