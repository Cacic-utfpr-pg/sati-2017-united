using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    //private Rigidbody2D rb;
    private int currentVitality;

    public int vitality = 1;
    public int damage = 1;

	public CollisionTrigger collisionTrigger;

    private void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        currentVitality = vitality;
    }

    public void OnDamage(int damage)
    {
        Debug.Log("EnemyController::OnDamage");
        currentVitality -= damage;

        if(currentVitality <= 0)
        {
            OnDead();
        }
    }

	public void OnAttack()
	{
		// scripts para atacar ...
		Debug.Log("Enemy is attacking .... ");	
	}

    private void OnDead()
    {
        Destroy(gameObject);
    }

	public void OnCooldown(float timer){

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
			OnAttack ();
		}
	}

}
