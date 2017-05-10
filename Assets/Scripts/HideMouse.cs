using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;	
	}
	
	void Update () {
		Cursor.lockState = CursorLockMode.Confined;
	}
}
