using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Load the next scene
public class LoadOnClick : MonoBehaviour {
	
	//public GameObject loadingImage;
	
	public void LoadScene(int Scene)
	{
		//loadingImage.SetActive(true);
		SceneManager.LoadScene(Scene);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
