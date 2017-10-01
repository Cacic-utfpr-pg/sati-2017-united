﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @brief Esta classe movimenta um objeto com uma sentinela em um intervalo 
 * 'leftBoundary' e 'rightBoundary'. 
 * 
 * Pode ser usada para movimentar o jogador, blocos de chão, e objetos de fundo dentre outros.
 * 
 **/
public class MoveVertical : MonoBehaviour
{

	private Rigidbody2D rb;
	public bool side;

	public float movementSpeed = 1;
	public float topBoundary;
	public float bottomBoundary;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		side = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y <= bottomBoundary)
			side = false;

		if (transform.position.y >= topBoundary)
			side = true;

		if (side)
			rb.MovePosition(transform.position - transform.up * movementSpeed * Time.deltaTime);
		else
			rb.MovePosition(transform.position + transform.up * movementSpeed * Time.deltaTime);

	}

}
