using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  A classe 'CameraController' é responsável por cotrolar a camera que acompanha um objeto.
 *  Esse objeto geralmente é um jogador, mas permite que seja outro objeto.
 **/
public class MoveCamera : MonoBehaviour {

	// Esse objeto geralmente será uma referencia para o jogador
	public Transform target;

	public float x = 0.5f;
	public float y = 1f;
	public float z = -1f;

	public float smoothTime = 0.03f;

	private Vector3 velocity = Vector3.zero;

	void Start()
	{
		//StartCoroutine (GoToTarget());
	}

	void Update () {

        if (target == null)
        {
            return;
        }

		Vector3 targetPosition = target.TransformPoint (new Vector3 (x, y, z));
		this.transform.position = Vector3.SmoothDamp(this.transform.position, 
			targetPosition,
			ref velocity,
			smoothTime
		);

	}

	IEnumerator GoToTarget(){
		
		yield return new WaitForSeconds (5);
		Debug.Log ("Go");

		Vector3 targetPosition = target.TransformPoint (new Vector3 (x, y, z));
		this.transform.position = Vector3.SmoothDamp(this.transform.position, 
			targetPosition,
			ref velocity,
			smoothTime
		);

	}
		
}
