using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;
	private BoxCollider2D boxCol;
	private bool visible;
	private float maxLeft;
	private float maxRight;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		boxCol = GetComponent<BoxCollider2D> ();
		maxLeft = transform.position.x - SceneScript.instance.prevX;
		maxRight = transform.position.x + SceneScript.instance.prevX;
	}
	
	void Update () {
		if (visible){
			
		}
	}

	void OnBecameVisible(){
		visible = true;
	}

	void OnBecameInvisible(){
		visible = false;
		//Destroy (gameObject);
	}
}