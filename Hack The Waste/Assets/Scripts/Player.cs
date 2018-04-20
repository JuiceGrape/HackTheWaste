using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	[SerializeField] private Resource HP;

	public void GetHit(int damage)
	{
		HP.RemoveAmount(damage);

		if (HP.GetQuantity() <= HP.minResource)
		{
			Die();
		}
	}

	public void Die() 
	{

	}
}
