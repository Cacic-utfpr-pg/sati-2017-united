using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] heartSprites;

	public Image heartUI;

	private PlayerController player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

	}
	
	void Update () {
		if(player.currentVitality >= 0)
			heartUI.sprite = heartSprites [player.currentVitality];
	}
}
