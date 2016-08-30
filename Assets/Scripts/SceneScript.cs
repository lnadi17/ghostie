using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SceneScript : MonoBehaviour {

	public List<GameObject> platformPrefabs;
	public Rigidbody2D rbPlayer;
	public int timesX = 5;
	public float distanceBetween;

	private List<float> floatList;

	private float prevPositionX;
	private float prevPositionY;
	private float prevX;
	private bool firstTime;

	void Start () {
		floatList = new List<float> (new float[platformPrefabs.Count]);
		firstTime = true;

		LayoutPlatforms ();
	}

	void LayoutPlatforms(){
		Instantiate (platformPrefabs [0], platformPrefabs [0].transform.position, Quaternion.identity);

		prevPositionX = platformPrefabs [0].transform.position.x;
		prevX = xViaIndex (0);

		for (int t = 1; t < timesX; t++){
			int randomIndex = Random.Range (0, platformPrefabs.Count);

			GameObject instance = Instantiate (
				platformPrefabs [randomIndex], 
				new Vector2(
					prevPositionX + xViaIndex(randomIndex) + prevX + distanceBetween,
					prevPositionY + DistanceFromY()
				),
				Quaternion.identity) as GameObject;

			prevPositionX = instance.transform.position.x;
			prevPositionY = instance.transform.position.y;
			prevX = xViaIndex (randomIndex);
		}
	}

	float xViaIndex(int index){
		if (floatList [index] != 0) {
			return floatList [index];
		}
			
		float newListMember = platformPrefabs [index].GetComponent<SpriteRenderer> ().bounds.extents.x;
		floatList.Insert (index, newListMember);

		return floatList[index];
	}

	float DistanceFromY(){
		if (firstTime){
			firstTime = false;
			return 0;
		}

		float distance = Random.Range (-4f, 4f);
		return distance;
	}


}