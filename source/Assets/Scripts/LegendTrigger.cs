using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendTrigger : MonoBehaviour {

	public string[] text;

	private int currentText;

	public Text textUI;

	public GameObject subtitleUI;

	private bool triggered;

	public float time = 8;

	private float timer;

	public Collider2D collider2D;

	void Start(){
		triggered = false;
		currentText = 0;
		textUI.text = "";
		subtitleUI.SetActive (false);
		//collider2D = GetComponentInChildren<Collider2D> ();
	}

	void Update(){

        if (triggered)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Next();
            }
        }

	}

	void Next(){
		if (currentText < text.Length) {
			textUI.text = text [currentText++];
			timer = time;
		} else {
			triggered = false;
			textUI.text = "";
            collider2D.enabled = false;
        }
	}
		
	public void OnTriggerEnter2D(Collider2D col){

        if (col.CompareTag("Player"))
        {
            triggered = true;
            currentText = 0;
            subtitleUI.SetActive(true);
        }
		
	}

}
