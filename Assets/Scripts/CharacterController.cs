using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

	//public variables
	public float maxSpeed = 10f;
	public float moveForce = 350f;
	
	//private variables
	private Rigidbody2D rb2d;
	
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
		
		if (v * rb2d.velocity.y < maxSpeed)
			rb2d.AddForce(Vector2.up * v * moveForce);
		if (Mathf.Abs (rb2d.velocity.y) > maxSpeed)
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.y * maxSpeed), rb2d.velocity.x);
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
	if(other.GetComponent<Collider2D>().tag == "Enemy")
     {
         SceneManager.LoadScene(2);
     }

	}
}
