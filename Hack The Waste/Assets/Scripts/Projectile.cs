using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (SpriteRenderer))]
public class Projectile : MonoBehaviour 
{
	private Vector2 movement;

	protected Player player;
	protected Environment environment;

	[SerializeField] private float speed = 1.0f; 

	private Rigidbody2D rigidbody2D;
	private SpriteRenderer renderer;

	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.gravityScale = 0;

		renderer = GetComponent<SpriteRenderer>();
	}

	public Sprite GetSprite()
	{
		return renderer.sprite;
	}

	public void create(Environment environment, Player player, Vector2 movement)
	{
		this.player = player;
		setMovement(movement);
		this.environment = environment;
	}

	private void setMovement(Vector2 movement)
	{
		this.movement = movement.normalized * speed;
		rigidbody2D.velocity = this.movement;
	}

	void OnTriggerEnter2D(Collider2D collider2D)
    {
		Enemy enemy = collider2D.gameObject.GetComponent<Enemy>();
		if (enemy != null)
		{
			Hit(enemy);
		}
    }




	protected virtual void Hit(Enemy enemy)
	{
		 //enemy.DestroyEnemy();
		 Destroy(this.gameObject);
	}



}
