using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Update(){
		
	}

	public void Play(){
		Debug.Log ("Play");
		UnityEngine.SceneManagement.SceneManager.LoadScene ("cavernosa");
	}

	public void Quit(){

		Application.Quit ();

	}
}
