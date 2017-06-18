using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public Text scoreText;


    void UpdateText()
	{
		scoreText.text = "You killed " + GameController.score + " Zombies \n" + GameController.zombiesComePast + " zombies have come past";
	}
	
	void Update()
	{
		UpdateText();
	}
}
