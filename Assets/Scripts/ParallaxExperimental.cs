using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxExperimental : MonoBehaviour {

	//[Tooltip("From the nearest to the farthest")]
	public Transform playerTransform;
	public float startSpeed;

	private List<GameObject[]> listOfArrays = new List<GameObject[]>();
	private GameObject[] objectsFromLayer;
	private float _positionX;
	private float speed;

	void Start () {
		LayerMask start = LayerMask.NameToLayer ("StartParallax");
		LayerMask end = LayerMask.NameToLayer ("EndParallax");

		for (int i = start + 1; i < end; i++){
			objectsFromLayer = FindGameObjectsWithLayer (i);
			if (objectsFromLayer != null) {
				listOfArrays.Add (objectsFromLayer);
			}
		}
	}
	
	void Update () {
		if(playerTransform.position.x != _positionX){
			speed = startSpeed * 0.5f;
			foreach (GameObject[] arr in listOfArrays){
				speed *= 0.5f;
				foreach (GameObject go in arr){
					if (playerTransform.position.x > _positionX) {
						go.transform.Translate (new Vector2 (-0.1f * speed, 0));
					} else {
						go.transform.Translate (new Vector2 (0.1f * speed, 0));
					}
				}
			}
			speed = startSpeed;
		}
		_positionX = playerTransform.position.x;
	}

	GameObject[] FindGameObjectsWithLayer (int layer) {
		GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[]; 
		List<GameObject> goList = new List<GameObject> ();

		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].layer == layer) { 
				goList.Add(goArray[i]); 
			} 
		} 

		if (goList.Count == 0) { 
			return null; 
		} 

		return goList.ToArray(); 
	}
}
