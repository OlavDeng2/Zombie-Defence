using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyOnContact : MonoBehaviour {
	
	public int peasantsPassed = 0;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		Destroy (other.gameObject);
		peasantsPassed +=1;
	}
	
	void Update()
	{
		if (peasantsPassed >= 3)
		//loadingImage.SetActive(true);
		SceneManager.LoadScene(2);
	}
}
