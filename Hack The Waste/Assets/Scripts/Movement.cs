using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	public float moveSpeed;
	private Vector2 moveVelocity;
	private Vector2 moveInput;
	// Use this for initialization
	void Start ()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput * moveSpeed;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		rigidbody2D.velocity = moveVelocity;

		//Controller input
		// if(Input.GetAxis("LeftStickHorizontal") < -0.19f || Input.GetAxis("LeftStickHorizontal") > 0.19f || Input.GetAxis("LeftStickVertical") < -0.19f || Input.GetAxis("LeftStickVertical") > 0.19f)
		// {
		// 	Vector2 currentInput = new Vector2(Input.GetAxis("LeftStickHorizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("LeftStickVertical") * moveSpeed * Time.deltaTime);
		// 	rigidbody2D.velocity = currentInput;
		// }
		//Keyboard input



		// Input.GetAxis("LeftTrigger");
		// Input.GetAxis("RightTrigger");

 
		// Move senteces
		
	}
}
