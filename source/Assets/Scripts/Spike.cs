using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{

	public int spikeDamage;

	private PlayerController player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerController> ();
	}
	
	/*void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag("Player")) {
			player.OnDamage (spikeDamage);
			StartCoroutine (player.Knockback (0.5f, 100f, player.transform.position));
		}
	}*/
}

