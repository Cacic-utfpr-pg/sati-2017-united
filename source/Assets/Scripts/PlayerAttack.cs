using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attack;

    public float attackTimer = 0;
    public float cooldown = 0.3f;

    public Animator anim;

    public Collider2D attackTrigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown("f") && !attack)
        {
			attack = true;
			attackTimer = cooldown;
            attackTrigger.enabled = true;
			//anim.SetBool ("atacando", true);
        }

        if (attack)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
			else
			{
				attack = false;
                attackTrigger.enabled = false;
				//anim.SetBool ("atacando", false);
            }
        }

        anim.SetBool("atacando", attack);

    }
}
