using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Camera cam;
	public GameObject enemy;
	
	public Text scoreText;
	public static int score = 0;
	
	private float maxWidth;
	
	//use this for initialization
	void Start ()
	{
	
		
	
		if (cam == null)
			cam = Camera.main;
			
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float enemyWidth = enemy.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - enemyWidth;
		
		StartCoroutine (Spawn());
		
	}
	
	void UpdateText()
	{
		scoreText.text = "Zombies Killed: " + score;
	}
	
	void Update()
	{
		UpdateText();
	}

	
	IEnumerator Spawn ()
	{
		while (true)
		{
			Vector2 spawnPosition = new Vector2 (Random.Range(-maxWidth, maxWidth), Screen.height );
		
			Quaternion spawnRotation = Quaternion.identity;
		
			Instantiate (enemy, spawnPosition, spawnRotation);
			
			yield return new WaitForSeconds (Random.Range (0.6f, 1.5f));
		}
	}
	

}