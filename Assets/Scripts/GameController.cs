using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	public Camera cam;
	public GameObject enemy;
    public static int score;
    public static int zombiesComePast;
    public static int maxZombiesPassed = 3;
    public int scene;



    private float maxWidth;
	
	//use this for initialization
	void Start ()
	{

        zombiesComePast = 0;
		score = 0;


        if (cam == null)
			cam = Camera.main;
			
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float enemyWidth = enemy.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - enemyWidth;
		
		StartCoroutine (Spawn());
		
	}

    private void Update()
    {
        if(zombiesComePast >= maxZombiesPassed)
        {
            SceneManager.LoadScene(scene);
        }
    }


    IEnumerator Spawn ()
	{
		while (true)
		{
			Vector2 spawnPosition = new Vector2 (Random.Range(-maxWidth, maxWidth), transform.position.y + 10);
		
			Quaternion spawnRotation = Quaternion.identity;
		
			Instantiate (enemy, spawnPosition, spawnRotation);
			
			yield return new WaitForSeconds (Random.Range (0.6f, 1.5f));
		}
	}
	

}