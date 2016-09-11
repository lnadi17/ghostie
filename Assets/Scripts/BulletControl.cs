using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	public float speed;
	public Animator anim;
	public UnityEngine.UI.Text txt;

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
		}
		if(enemyCount == 2){
			anim.SetTrigger ("Double");
		}
		else if (enemyCount == 3){
			anim.SetTrigger ("Triple");
		}
	}

	public void SetText (string textParam){
		txt.text = textParam;
	}
}