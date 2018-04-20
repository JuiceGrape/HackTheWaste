using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour 
{

	[SerializeField] private float toxicity = 0.0f;
	// Update is called once per frame

	public void addToxicity(float toxic)
	{
		toxicity += toxic;
	}
}
