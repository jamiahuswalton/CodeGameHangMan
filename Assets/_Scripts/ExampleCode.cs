using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCode : MonoBehaviour {
	// Global Variable
	string stringCode = "Forest Avenue";

	// Use this for initialization
	void Start () {
		//Access a global variable
		Debug.Log("Global Variable: " + stringCode);

		// Local Variable
		string startStringLocalVariable = "This is a local variable";
	}
	
	void MyOwnMethod(){
		//Access a global variable
		Debug.Log("Global Variable: " + stringCode);

		// Local Variable
		string myOwnMethodStringLocalVariable = "This is a local variable";

		/* The variables that can be accessed in thei method is the global variable (i.e., stringCode) and the local variable myOwnMethodStringLocalVariable. 
		 * This method cannot access the local variable in the Start() method.
		*/
	}
}
