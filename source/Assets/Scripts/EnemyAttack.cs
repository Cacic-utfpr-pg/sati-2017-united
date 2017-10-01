using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	private bool attack;
	public bool onAttack = false;

	public float attackTimer = 0;
	public float cooldown = 0.3f;

	public Animator anim;

	public Collider2D attackTrigger;

	//controle de animação
	private Animator animatorPlayer;	//controla estado

	private void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		attackTrigger.enabled = false;
	}

	private void Update()
	{
		if(onAttack && !attack)
		{
			attack = true;
			anim.SetBool ("ata", true);
			onAttack = false;
			attackTimer = cooldown;

			attackTrigger.enabled = true;
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
				anim.SetBool ("ata", true);
				attackTrigger.enabled = false;
			}
		}
	}

}
