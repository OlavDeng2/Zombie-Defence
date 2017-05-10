using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public Text scoreText;

	void UpdateText()
	{
		scoreText.text = "You Converted " + GameController.score + " peasants";
	}
	
	void Update()
	{
		UpdateText();
	}
}
