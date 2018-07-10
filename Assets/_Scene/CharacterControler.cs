using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {
	private GameObject mainCamera;
	private Camera cameraComponent;

	private float currentScreenHeight;
	private float currentScreenWidth;
	// Use this for initialization
	void Start () {
		/*
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraComponent = mainCamera.GetComponent<Camera> ();
		Debug.Log (Screen.height);
		*/

		//H: 633, W: 1203, Prefab pos: (x,y,z) 6,0,0
		// X/W = 6/1203, Xn/Wn = ?/current screen width
		currentScreenHeight = Screen.height;
		currentScreenWidth = Screen.width;
		Debug.Log ("Height: " + currentScreenHeight + ", Width: " + currentScreenWidth);
	}
	
	// Update is called once per frame
	void Update () {

		//Use camera position?


		//Update screen width and height
		currentScreenHeight = Screen.height;
		currentScreenWidth = Screen.width;

		float mainCameraX = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position.x;
		float mainCameraY = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position.y;
		//Debug.Log (Screen.height);

		this.transform.position = new Vector2 (mainCameraX + 5, mainCameraY);
		Debug.Log ("Height: " + currentScreenHeight + ", Width: " + currentScreenWidth + 100);

		//Use 
	}
}
