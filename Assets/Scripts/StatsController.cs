using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour {

	//Score is controlled from SceneScript.

	public Image[] liveSprites;
	public Animator playerAnim;

	private int imgLastIndex;
	private GameOver gOver;


	void Start(){
		gOver = GameObject.Find ("Player").GetComponent<GameOver> ();
		imgLastIndex = SceneScript.instance.playerLives - 1;
	}


	void ChangeLives(){
		SceneScript.instance.playerLives--;
		if(SceneScript.instance.playerLives < 0){
			playerAnim.SetTrigger ("Lost");
			gOver.WhenOver ();
			return;
		}
		liveSprites [imgLastIndex].color = new Color (1f, 1f, 1f, 0.4f);
		imgLastIndex--;
		playerAnim.SetTrigger ("Lost");
	}


	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "Enemy"){
			ChangeLives ();
		}
	}
}
