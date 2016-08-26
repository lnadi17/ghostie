using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxExperimental : MonoBehaviour {

	[Tooltip("From the nearest to the farthest")]
	public List<LayerMask> layerList;
	public GameObject[] allGameObjectsInThatLayer;

	void Start () {
		LayerMask start = LayerMask.NameToLayer ("StartParallax");
		LayerMask end = LayerMask.NameToLayer ("EndParallax");
		allGameObjectsInThatLayer = FindGameObjectsWithLayer ();
	}
	
	void Update () {
		
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
