using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @brief Esta classe movimenta um objeto com uma sentinela em um intervalo 
 * 'leftBoundary' e 'rightBoundary'. 
 * 
 * Pode ser usada para movimentar o jogador, blocos de chão, e objetos de fundo dentre outros.
 * 
 **/
public class MoveHorizontal : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool side;

    public float movementSpeed = 1;
    public float leftBoundary;
    public float rightBoundary;

	//controle de animação
	private Animator animatorPlayer;	//controla estado
	private bool direita;	//referencia de espelho

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        side = true;
		direita = side;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= leftBoundary)
            side = false;

        if (transform.position.x >= rightBoundary)
            side = true;

        if (side)
            rb.MovePosition(transform.position - transform.right * movementSpeed * Time.deltaTime);
        else
            rb.MovePosition(transform.position + transform.right * movementSpeed * Time.deltaTime);

		//muda direção
		mudaDirecao ();
    }

	//espelha personagem na horizontal
	private void mudaDirecao(){
		if ( (side != !direita)) {

			direita = !direita;
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}

	}

}
