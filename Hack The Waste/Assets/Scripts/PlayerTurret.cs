using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
	private Camera mainCamera;
	public Transform turretChildTransform;
	public bool usingController;
	// Use this for initialization
	void Start ()
	{
		mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(usingController)
		{
			if(Vector3.Magnitude(new Vector3(Input.GetAxis("RightStickHorizontal"),Input.GetAxis("RightStickVertical"), 0)) > 0.6f)
            	turretChildTransform.transform.localEulerAngles = -Mathf.Sign(Input.GetAxis("RightStickVertical")) * Vector3.back * Vector3.Angle(Vector3.right, Vector3.Normalize(new Vector3(Input.GetAxis("RightStickHorizontal"), Input.GetAxis("RightStickVertical"), 0)));
		}
		else
		{
			Vector3 v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(v);
 			Quaternion rot = Quaternion.LookRotation (mousePosition - transform.position, transform.TransformDirection(Vector3.forward));
 			turretChildTransform.transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
			turretChildTransform.transform.Rotate(new Vector3(0,0,-90));
		}
	}
}
