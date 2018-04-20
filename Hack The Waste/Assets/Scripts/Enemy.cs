using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]int Damage;

    public delegate void DealDamage(int amount);
    public static event DealDamage dealDamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GoToPlayer()
    {

    }

    private void dealDamageToPlayer()
    {
        dealDamage(this.Damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.transform.tag == "Player")
        {
            Debug.Log("oh");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision");
        if (collision.transform.tag == "Player")
        {
            Debug.Log("oh");
        }
    }
}
