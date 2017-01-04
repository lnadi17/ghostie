using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public GameObject bullet;
	public GameObject bestIndicator;

	[HideInInspector]
	public static bool grounded;

	//Holds all UI Elements that don't let the touches/clicks pass through to the scene.
	public RectTransform[] uiElements;

	public float speed;
	public float jumpForce;

	private bool facingRight;
	private SpriteRenderer playerSpriteRenderer;
	private Rigidbody2D playerRigidbody;
	private ParticleSystem pSystem;
	private Transform groundCheck;
	private float sinceShoot = 0f; 
	private int widthPixel;
	//private bool bestScoreExists;
	//private GameObject bestIndicatorInstance;


	void Start () {
		facingRight = true;
		playerSpriteRenderer = GetComponent<SpriteRenderer> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find("GroundCheck");
		pSystem = groundCheck.GetComponent<ParticleSystem> ();
		widthPixel = Camera.main.pixelWidth;
		//bestScoreExists = false;
		if (PlayerPrefs.HasKey ("PlayerScore")) {
			//bestScoreExists = true;
			Instantiate (
				bestIndicator,
				new Vector2 (PlayerPrefs.GetInt ("PlayerScore"), 0),
				Quaternion.identity
			);
		}
	}
	

	void Update () {
		if (facingRight) {
			playerSpriteRenderer.flipX = false;
			groundCheck.transform.position = new Vector2 (transform.position.x - 0.5f, groundCheck.position.y);
		} else {
			playerSpriteRenderer.flipX = true;
			groundCheck.transform.position = new Vector2 (transform.position.x + 0.5f, groundCheck.position.y);
		}

		//When playing starts:
		if (SceneScript.instance.playingStarted) {
			pSystem.Play();
			transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
		}

		CheckIfGrounded ();

		//	if (grounded && Input.GetKeyDown(KeyCode.Space)){
		if (grounded && LeftSideTouch()){
			if (!SceneScript.instance.playingStarted) {
				SceneScript.instance.playingStarted = true;
				return;
			}
			Vector2 jumpVector = (Vector2.up * jumpForce);
			playerRigidbody.velocity = Vector2.zero;
			playerRigidbody.AddForce (jumpVector);
		}

		sinceShoot += Time.deltaTime;

		if(RightSideTouch() && sinceShoot > 1){
		//if(Input.GetKeyDown(KeyCode.LeftShift) && sinceShoot > 1){
			Shoot ();
		}
	}


	void Shoot(){
		Instantiate (bullet, transform.position, Quaternion.identity);
		sinceShoot = 0;
	}


	void CheckIfGrounded(){
		grounded = Physics2D.Linecast (
			transform.position, 
			groundCheck.transform.position, 
			1 << LayerMask.NameToLayer("Ground")
		);
	}


	//Touch controls:
	bool LeftSideTouch(){
		foreach(Touch touch in Input.touches){
			if(!IsTouchOverUI() && touch.position.x < widthPixel * 0.5f && touch.phase == TouchPhase.Began){
				return true;
			}
		}
		return false;
	}


	bool RightSideTouch(){
		foreach(Touch touch in Input.touches){
			if(!IsTouchOverUI() && touch.position.x > widthPixel * 0.5f && touch.phase == TouchPhase.Began){
				return true;
			}
		}
		return false;
	}


	//Tests if the touch position is over UI:
	bool IsTouchOverUI(){
		foreach (Touch touch in Input.touches){
			foreach (RectTransform elem in uiElements){
				if (!elem.gameObject.activeSelf){
					continue;
				}
				Vector3[] worldCorners = new Vector3[4];
				elem.GetWorldCorners(worldCorners);

				if (touch.position.x >= worldCorners[0].x && touch.position.x < worldCorners[2].x
					&& touch.position.y >= worldCorners[0].y && touch.position.y < worldCorners[2].y)
				{
					return true;
				}
			}
		}
		return false;
	}
}