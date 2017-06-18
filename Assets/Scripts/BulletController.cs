using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
{


	//the speed of the zombie
	public float Acceleration;
	public float maxSpeed;
	
	//Variable for the rigidbody
	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () 
	{
		
		//get the zombie rigid body
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called every fixed frame
	void FixedUpdate () 
	{		
		moveBullet();
	}
	
	
	void moveBullet()
	{
		//vector for the movement of the zombie
		Vector2 Movement = new Vector2 (0.0f, Acceleration);
		
		//ads the force which provides the movement
		rigidbody.velocity = Movement;
		
		
		//Limit the max movement speed
		if(rigidbody.velocity.magnitude > maxSpeed)
		{
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}
	}

    
}
