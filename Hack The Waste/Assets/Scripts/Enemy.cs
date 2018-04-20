using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]private int Damage;
    private GameObject player;
    [SerializeField]private int Speed;
    
    private GameObject Player;
    private bool AllowedToMove = false;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (AllowedToMove)
        {
            GoToPlayer();
        }
	}

    private void GoToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
    }

    private void dealDamageToPlayer()
    {
        //TODO
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

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        AllowedToMove = true;
    }

}
