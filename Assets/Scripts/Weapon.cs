using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
	public bool canShoot = false;
	public float reloadTime;
	public GameObject bullet;
	
	// Update is called once per frame
	void Update () 
	{
		
		if (reloadTime > 1.5f)
		{
			canShoot = true;
			reloadTime = 0.0f;
			
		}
		
		if (Input.GetKeyDown("space")&&canShoot== true)
		{
			Instantiate (bullet, transform.position, Quaternion.identity);
			canShoot = false;
		}
			
		reloadTime += Time.deltaTime;
		

	}
	
}
