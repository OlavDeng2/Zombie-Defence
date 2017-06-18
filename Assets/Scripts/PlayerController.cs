using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	//the speed of the player
	public float movementSpeed;
	public float maxSpeed;
	
	public GameObject bullet;
	
	//Variable for the rigidbody of the player
	private Rigidbody2D playerRigidbody;
	// Use this for initialization
	void Start () 
	{
		playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called every fixed frame
	void FixedUpdate () 
	{		
		//float for moving horizontally
		float moveHorizontal = Input.GetAxis("Horizontal");
		
		Vector2 playerMovement = new Vector2 (moveHorizontal, 0.0f);
		
		playerRigidbody.AddForce(playerMovement * movementSpeed);
		
				//Limit the max movement speed
		if(playerRigidbody.velocity.magnitude > maxSpeed)
		{
			playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
		}
		
		
	}

}
