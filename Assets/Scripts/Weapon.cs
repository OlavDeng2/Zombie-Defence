﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
	public bool canShoot = false;
	public float reloadTime;
	public GameObject bullet;

    public AudioClip cannonFire;
    public AudioSource cannonAudio;

    private void Start()
    {
        cannonAudio.clip = cannonFire;
    }

    // Update is called once per frame
    void FixedUpdate () 
	{
		if (reloadTime > 1.5f)
		{
			canShoot = true;
		}

		reloadTime += Time.deltaTime;
	}

    void Update()
    {
        if (Input.GetKeyDown("space") && canShoot == true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            cannonAudio.Play();
            canShoot = false;
            reloadTime = 0.0f;
        }
    }
	
}
