using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMove : MonoBehaviour {

	private float pingPong;
	private float y;
	private float x; 
	public float maxY;
	private bool side;

	void Start()
	{
		x = transform.position.x;
		y = transform.position.y;
	}

	void Update() {
		float sense = transform.position.x;

		if(transform.position.y <= maxY){
			pingPong = Mathf.PingPong(Time.time, maxY);
		}
		else if(transform.position.y >= maxY){
			pingPong = -Mathf.PingPong(Time.time, maxY);
		}

		transform.position = new Vector3(x + Mathf.PingPong(Time.time, 2), y + pingPong, transform.position.z);

		//muda sprite
		sense = sense - transform.position.x;
		MakePosition (sense);
	}

	private void MakePosition(float sense)
	{
		if (
			(sense > 0 && !side) || (sense < 0 && side)) {

			side = !side;
			transform.localScale = new Vector3 (-transform.localScale.x, -transform.localScale.y, -transform.localScale.z);
		}
	}
}
