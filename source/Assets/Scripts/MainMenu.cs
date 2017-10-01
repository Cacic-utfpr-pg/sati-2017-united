using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject startUI;

	public GameObject mainMenuUI;

	private bool intro;

	public string[] text;

	private int currentText;

	public Text textUI;

	void Start(){
		intro = false;
		currentText = 0;
		textUI.text = "";
	}

	void Update(){

		if (intro) { 

			if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("Skip . . . ");
                Next ();
			}
		
		}

	}

	void Next(){
		if (currentText < text.Length) {
			textUI.text = text [currentText++];
		} else {
			textUI.text = "Carregando . . .";
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Cave");
		}
	}

	public void Play(){
		startUI.SetActive (true);
		mainMenuUI.SetActive (false);
		intro = true;
	}

	public void Quit(){
		Application.Quit ();
	}
}
