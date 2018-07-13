using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private string mainSceneName = "Main";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartNewGame(){
		//Load game Scene
		SceneManager.LoadScene (mainSceneName);
	}
}
