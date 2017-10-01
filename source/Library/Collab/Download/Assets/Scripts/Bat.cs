using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	private float pingPong;
	public float minY; // posição 
	public float xValue; // posição inicial em x
	public float maxY;
	private bool direita;
	private float p;

	void Update() {
		p = transform.position.x;

		if(transform.position.y <= maxY){
			pingPong = Mathf.PingPong(Time.time, maxY);
		}
		else if(transform.position.y >= maxY){
			pingPong = -Mathf.PingPong(Time.time, maxY);
		}
		//transform.position = new Vector3(pingPong, Mathf.PingPong(Time.time, 2), transform.position.z);
		transform.position = new Vector3(xValue + Mathf.PingPong(Time.time, 2), minY + pingPong, transform.position.z);

		//muda sprite
		p = p - transform.position.x;
		mudaDirecao ();
	}

	private void mudaDirecao(){
	
		if (
			(p > 0 && !direita) || (p < 0 && direita)) {
		
			direita = !direita;
			transform.localScale = new Vector3 (-transform.localScale.x, -transform.localScale.y, -transform.localScale.z);
		}
	
	}
}
