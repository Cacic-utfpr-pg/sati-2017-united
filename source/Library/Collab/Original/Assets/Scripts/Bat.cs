using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	private float pingPong;
	private float y;
	private float x; 
	public float maxY;
	private bool direita;
	private float p;

	void Start()
	{
		x = transform.position.x;
		y = transform.position.y;
	}

	void Update() {
		p = transform.position.x;

		if(transform.position.y <= maxY){
			pingPong = Mathf.PingPong(Time.time, maxY);
		}
		else if(transform.position.y >= maxY){
			pingPong = -Mathf.PingPong(Time.time, maxY);
		}
		//transform.position = new Vector3(pingPong, Mathf.PingPong(Time.time, 2), transform.position.z);
		transform.position = new Vector3(x + Mathf.PingPong(Time.time, 2), y + pingPong, transform.position.z);

		//muda sprite
		p = p - transform.position.x;
		mudaDirecao (p);
	}

	private void mudaDirecao(float horizontal){
	
		if (
			(p > 0 && !direita) || (p < 0 && direita)) {
		
			direita = !direita;
			transform.localScale = new Vector3 (-transform.localScale.x, -transform.localScale.y, -transform.localScale.z);
		}
	
	}
}
