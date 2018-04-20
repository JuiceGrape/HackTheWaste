using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public GameObject sprite;

    [SerializeField]private bool IsRecyclable;
    [SerializeField]private int Damage;
    [SerializeField]private int Speed;
    
    private bool AllowedToMove = false;

    [HideInInspector]public Player player;



    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (AllowedToMove)
        {
            GoToPlayer();
        }
        RotateSprite();
	}

    private void RotateSprite()
    {
        sprite.transform.Rotate(0, 0, -20, 0);
    }

    private void GoToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
    }

    private void dealDamageToPlayer()
    {
        player.GetHit(this.Damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            dealDamageToPlayer();
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "Bullet")
        {
            //TODO. 
            Debug.Log("TODO once I know what bullets do");
        }
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
        AllowedToMove = true;
    }

    public virtual void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void RecycleEnemy()
    {
        if (this.IsRecyclable)
        {
            Destroy(this.gameObject);
        }
    }

}
