using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	public float moveSpeed = 5;
	private Vector2 moveVelocity;
	private Vector2 moveInput;
	// Use this for initialization
	void Start ()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.gravityScale = 0;
	}

	void Update()
	{
		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput * moveSpeed;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		rigidbody2D.velocity = moveVelocity;
	}
}
