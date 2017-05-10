using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Camera cam;
	public GameObject enemy;
	
	public Text scoreText;
	public static int score = 0;
	
	private float maxHeight;
	
	//use this for initialization
	void Start ()
	{
	
		
	
		if (cam == null)
			cam = Camera.main;
			
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetHeight = cam.ScreenToWorldPoint(upperCorner);
		float enemyHeight = enemy.GetComponent<Renderer>().bounds.extents.y;
		maxHeight = targetHeight.y - enemyHeight;
		
		StartCoroutine (Spawn());
		
	}
	
	void UpdateText()
	{
		scoreText.text = "Peasants Converted: " + score;
	}
	
	void Update()
	{
		UpdateText();
	}

	
	IEnumerator Spawn ()
	{
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (transform.position.x, Random.Range(312.0f, maxHeight), 0.0f);
		
			Quaternion spawnRotation = Quaternion.identity;
		
			Instantiate (enemy, spawnPosition, spawnRotation);
			
			yield return new WaitForSeconds (Random.Range (0.6f, 1.5f));
		}
	}
	

}