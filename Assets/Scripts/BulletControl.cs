using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	public float speed;

	private int enemyCount = 0;


	void Start () {
		Destroy (gameObject, 1f);
	}
	

	void Update () {
		transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}


	//Enemy collider is not a trigger but it works.
	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "Enemy"){
			SceneScript.instance.killedEnemies++;
			enemyCount++;
			SceneScript.instance.IncreaseKill ();
		}
		if(enemyCount == 2){
			SceneScript.instance.DoubleKill ();
		}
		else if (enemyCount == 3){
			SceneScript.instance.TripleKill ();
		}
	}
}