using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverMenu;

	private PlayerController player;

	void Start(){
		gameOverMenu.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}

	void Update(){
		if (player.isDead) {
			Debug.Log ("GameOver");
			gameOverMenu.SetActive (true);
			Time.timeScale = 0;
		}
	}

	public void Retry(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void Quit(){
		Application.Quit ();
	}
}
