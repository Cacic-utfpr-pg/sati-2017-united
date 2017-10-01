using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;
	public bool isDead;
	public int currentVitality;
    private bool isImmune;

	private Cooldown immuneTimer;
	private Cooldown immuneCD;

	private Vector3 lastCheckPoint; 

	public int vitality = 3;                           
    public float thrust = 100;

	//controle de animação
	private Animator animatorPlayer;	//controla estado

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();

		// Tempo que fica immune
		immuneTimer = new Cooldown(this.gameObject, "OnImmuneTimer", 2f);

		// CD da funcao de vunerabilidade 
		immuneCD = new Cooldown(this.gameObject, "OnImmuneCooldown", 2f);

		isDead = false;
		currentVitality = vitality;
        isImmune = false;

		lastCheckPoint = rb.transform.position;
    }

    void Update()
    {

        if (isDead)
        {
            Debug.Log("is Dead !");
        }

		immuneTimer.Update ();
		immuneCD.Update ();

        Debug.Log(isImmune);
		
    }

    public void OnDamage(int damage)
    {

        OnCollision();

        if (!isImmune)
        { 
			
			OnHealthUpdate (-damage);

			if (isImmune == false && immuneCD.isCooldown() == false)
            {
                isImmune = true;
                immuneTimer.StartCooldown();
            }

            Debug.Log("Vitality=" + currentVitality);
        }
        
        if(currentVitality <= 0)
        {
			OnDead ();
		}
    }

    void OnCollision()
    {
		rb.AddForce(this.transform.up * thrust);
    }

    void OnDead()
    {
		Debug.Log ("morto...");
		//animação

        isDead = true;
        //Destroy(gameObject);

        //animatorPlayer.SetBool("morto", true);

        //animação
        //animatorPlayer.SetBool ( "morto", false);
    }
    
	// chamada por immunerTimer quando o CD é resetado
	void OnImmuneTimer(int[] args)
    {
		int timer = args [1];

		if (timer <= 0) {
			this.isImmune = false;
			this.immuneCD.StartCooldown (); // começa a contagem regressiva de intervalo para pŕoxima
			// ivunerabilidade
		}

		if (timer >= 1) 
		{
			this.isImmune = true;
		}
			
		//Debug.Log("PlayerController::OnImmuneTimer = " + isImmune + immuneTimer.getTimer());
    }

	// chamda por immuneCD quando o CD é resetado
	void OnImmuneCooldown(int[] args)
	{
		//Debug.Log ("immuneCD = " + immuneCD.isCooldown() + immuneCD.getTimer());
	}

	void OnBonus(int bonus){
		OnHealthUpdate (+bonus);
	}

	void OnHealthUpdate(int value){
		if(currentVitality <= vitality && currentVitality > 0)
			currentVitality += value;
		//Debug.Log ("+1 de vida ! ->" + currentVitality);
	}

	/*public IEnumerator Knockback(float knockDur, float knockPower, Vector3 knockDir){
	
		float timer = 0;

		while (knockDur > timer) {

			timer += Time.deltaTime;

			rb.AddForce (new Vector3 (knockDir.x * -100, knockDir.y * thrust, transform.position.z));
		}

		yield return 0;

	}*/
}
