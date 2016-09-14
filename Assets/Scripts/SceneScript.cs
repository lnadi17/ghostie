using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SceneScript : MonoBehaviour {

	public static SceneScript instance = null;

	public int playerLives = 3;
	public int score = 0;
	public int killedEnemies = 0;
	public bool playingStarted = false;
	//public bool gameOver = false;

	public List<GameObject> platformPrefabs;
	public Rigidbody2D rbPlayer;
	public int timesX = 5;
	public float distanceBetween;
	[Range(0, 100)]
	public int enemySpawnChance;
	public Text scoreText;

	public Animator killAnim;
	public Text killText;
	public Text killCountText;

	[HideInInspector]
	public float prevPositionX;
	[HideInInspector]
	public float prevPositionY;
	[HideInInspector]
	public float prevX;

	private List<float> floatList;

	private float overallLength; //Gets assigned in LayoutPlatforms method.
	private bool firstTime;

	void Awake(){
		if (instance == null){
			instance = this;
		}else if (instance != this){
			Destroy (gameObject);
		}
	}
		

	void Start () {
		floatList = new List<float> (new float[platformPrefabs.Count]);
		firstTime = true;

		LayoutPlatforms ();
		StartCoroutine (IncreaseScore ());
	}

	//Score up:
	IEnumerator IncreaseScore(){
		while (true) {
			if (playingStarted) {score = (int)rbPlayer.transform.position.x;}
			scoreText.text = "Distance: " + score.ToString () + "m";
			yield return new WaitForSeconds (.1f);
		}
	}

	void LayoutPlatforms(){
		//First one is always on default position.
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

	//Returns sprite's half-width.
	float xViaIndex(int index){
		if (floatList [index] != 0) {
			return floatList [index];
		}
			
		float newListMember = platformPrefabs [index].GetComponent<SpriteRenderer> ().bounds.extents.x;
		floatList.Insert (index, newListMember);

		return floatList[index];
	}

	//Returns random range for next platform's Y pos.
	public float DistanceFromY(){
		if (firstTime){
			firstTime = false;
			return 0;
		}

		float distance = Random.Range (-3.5f, 3.3f);
		return distance;
	}

	//Multiple kill controls:
	public void DoubleKill(){
		killText.text = "DOUBLE KILL!";
		killAnim.SetTrigger ("Double");
	}

	public void TripleKill(){
		killText.text = "TRIPLE KILL!";
		killAnim.SetTrigger ("Triple");
	}

	//Kill count text controls:
	public void IncreaseKill(){
		killCountText.text = "Kills: x" + killedEnemies;
	}
}