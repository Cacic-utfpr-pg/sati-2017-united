using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public LayerMask whatIsGround;
    public float movementSpeed = 3;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool grounded = true;
	private bool isJump;
    public float jumpIncrement = 0.024f;
	private int jumps = 0;

	//controle de animação
	private Animator animatorPlayer;	//controla estado
	private bool direita;	//referencia de espelho
	private float p;	//posição atual do x
	private float pp;	//posição atual do y

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
		animatorPlayer = GetComponent<Animator> ();
	}
	
	void Update ()
	{
		//animação
		if(Input.GetKeyDown("space")){
			animatorPlayer.SetBool ("pulando", true);
		}

		//posição atual
		p = transform.position.x;
		pp = transform.position.y;

		if (grounded && isJump) {
			isJump = false;
			jumps = 0;
		}

		transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, 0) * movementSpeed * Time.deltaTime;
		grounded = Physics2D.OverlapCircle (transform.position, 0.15f, whatIsGround);

		//pulo duplo
		if (Input.GetButtonDown ("Jump") && !grounded && ++jumps < 2) {
			//transform.position = new Vector3(transform.position.x, transform.position.y + jumpIncrement, 1);
			rb.AddForce (transform.up * (jumpForce + 20));
		}

		//pulo
		if (Input.GetButtonDown ("Jump") && grounded && !isJump) {
			rb.AddForce (transform.up * jumpForce);
			isJump = true;

		}

		//muda direção
		p = p - transform.position.x;
		mudaDirecao ();

		//muda animação andar
		if (Input.GetKey("d") || Input.GetKey ("a") || Input.GetKey("left") || Input.GetKey ("right")) {
			animatorPlayer.SetBool ( "movendo", true);
		} else {
			animatorPlayer.SetBool ("movendo", false);
		}

		//animação do pulo
		if (grounded) {
			animatorPlayer.SetBool ("pulando", false);
		}

    }

	//espelha personagem na horizontal
	private void mudaDirecao(){
		if ( (p > 0 && !direita) || (p < 0 && direita)) {

			direita = !direita;
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}

	}
}
