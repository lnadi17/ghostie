using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SceneScript : MonoBehaviour {

	public List<GameObject> platformPrefabs;
	public int timesX = 5;

	private float prevBounds;
	private float distanceBetween;
	private float maxDistanceFromY;

	void Start () {
		prevBounds = 0;
		distanceBetween = 1;

		LayoutPlatforms ();
	}

	void LayoutPlatforms(){
		for (int t = 0; t < timesX; t++){
			int randomIndex = Random.Range (0, platformPrefabs.Count);

			GameObject instance = Instantiate (
				platformPrefabs [randomIndex], 
				new Vector2(
					platformPrefabs[randomIndex].transform.position.x + prevBounds * 2 + distanceBetween,
					platformPrefabs[randomIndex].transform.position.y + DistanceFromY()
				),
				Quaternion.identity) as GameObject;
			
			prevBounds = instance.GetComponent<SpriteRenderer> ().bounds.max.x;
		}
	}

	float DistanceFromY(){
		float distance = Random.Range (-5, 5);
		return distance;
	}
}