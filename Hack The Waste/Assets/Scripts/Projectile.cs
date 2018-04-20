using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Projectile : MonoBehaviour 
{
	private Vector2 movement;

	private Player player;

	[SerializeField] private float speed = 1.0f; 

	[SerializeField] private Rigidbody2D rigidbody2D;

	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.gravityScale = 0;

	}

	public void create(/*environment*/ Player player, Vector2 movement)
	{
		setMovement(movement);
	}

	private void setMovement(Vector2 movement)
	{
		this.movement = movement.normalized * speed;
		if (movement != null)
		rigidbody2D.velocity = this.movement;
	}

	void OnCollisionEnter2D(Collision2D collision2D)
    {
		Hit();
    }




	private void Hit()
	{
		 
	}



}
