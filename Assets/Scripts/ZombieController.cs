using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ZombieController : MonoBehaviour 
{


	//the speed of the zombie
	public float movementSpeed;
	public float maxSpeed;

    public AudioClip zombieDeathRattle;
    private AudioSource zombieAudioSource;


    public int scene;

    bool wasKilled = false;

	//Variable for the rigidbody of the zombie
	private Rigidbody2D zombieRigidbody;
	// Use this for initialization
	void Start () 
	{
		
		//get the zombie rigid body
		zombieRigidbody = GetComponent<Rigidbody2D>();
        zombieAudioSource = GetComponent<AudioSource>();
        zombieAudioSource.clip = zombieDeathRattle;

	}
	
	// Update is called every fixed frame
	void FixedUpdate () 
	{		
		MoveZombie();
    }


	void MoveZombie()
	{
		//vector for the movement of the zombie
		Vector2 zombieMovement = new Vector2 (0.0f, movementSpeed);
		
		zombieRigidbody.AddForce(-zombieMovement);
		
		
		//Limit the max movement speed
		if(zombieRigidbody.velocity.magnitude > maxSpeed)
		{
			zombieRigidbody.velocity = zombieRigidbody.velocity.normalized * maxSpeed;
		}	
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            wasKilled = true;

            zombieAudioSource.Play();
            Destroy(collision.gameObject);
            Destroy(this.gameObject, 2);

            GameController.score += 1;

        }



        if (collision.gameObject.tag == "WorldBorder" && !wasKilled)
        {
            Destroy(this.gameObject);
            GameController.zombiesComePast += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //end the game if zombie hits the player.
        if (collision.gameObject.tag == "Player" && !wasKilled)
        {
            GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    }
}
