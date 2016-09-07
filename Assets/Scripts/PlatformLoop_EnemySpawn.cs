using UnityEngine;
using System.Collections;

public class PlatformLoop_EnemySpawn : MonoBehaviour {

	public GameObject enemyPrefab;

	private Transform playerTransform;
	private float boundsExtentsX;
	private int chance;

	void Start(){
		playerTransform = GameObject.Find ("Player").transform;
		SpriteRenderer rdr = GetComponent<SpriteRenderer> ();
		boundsExtentsX = rdr.bounds.extents.x;
		chance = SceneScript.instance.enemySpawnChance;
	}

	void OnBecameInvisible(){
		if (gameObject.activeSelf) { 
			if (transform.position.x < playerTransform.position.x) {
				transform.position = new Vector2 (
				//That's X:
					+SceneScript.instance.prevPositionX
					+ SceneScript.instance.prevX
					+ boundsExtentsX
					+ SceneScript.instance.distanceBetween,
				//That's Y:
					+SceneScript.instance.prevPositionY
					+ SceneScript.instance.DistanceFromY ()
				);

				SceneScript.instance.prevPositionX = transform.position.x;
				SceneScript.instance.prevX = boundsExtentsX;
				SceneScript.instance.prevPositionY = transform.position.y;

				if (ChancePercent (chance)) {
					SpawnEnemy ();
				}
			}
		}
	}

	void SpawnEnemy(){
		Instantiate (
			enemyPrefab, 
			new Vector2 (transform.position.x, transform.position.y),
			Quaternion.identity
		);
	}

	bool ChancePercent(int percentage){
		int[] caseList = new int[100];
		for(int i = 0; i < 100; i++){
			caseList.SetValue (i + 1, i);
		}
		int randomInt = UnityEngine.Random.Range (0, caseList.Length);
		if (randomInt <= percentage){
			return true;
		}
		return false;
	}
}