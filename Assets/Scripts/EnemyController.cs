using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public float moveForce = 350f;
	
	private Rigidbody2D rb2d;
	

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb2d.AddForce(Vector2.left * moveForce);
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x * maxSpeed), rb2d.velocity.y);
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		GetComponent<Collider2D>().enabled = false;
		gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Enemy_Converted", typeof(Sprite)) as Sprite;
		
		if(other.GetComponent<Collider2D>().tag == "Player")
		{
			SceneManager.LoadScene(2);
		}
	}
}
