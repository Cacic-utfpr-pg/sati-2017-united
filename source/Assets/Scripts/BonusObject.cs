using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : MonoBehaviour {

	public int bonus;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			collider.gameObject.SendMessageUpwards ("OnHealthUpdate", bonus);
			Destroy (gameObject);
		}
	}
}
