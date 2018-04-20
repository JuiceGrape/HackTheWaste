using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
	public Transform projectileParent;
	public Transform projectileSpawn;
	public GameObject[] projectilePrefabs;
	private int selectedWeapon = 0;
	private Camera mainCamera;
	public Transform turretChildTransform;
	public bool usingController;

	public float shootDelayMax = .2f;
	private float shootDelayTimer = 0f;
	// Use this for initialization
	void Start ()
	{
		mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		if((Input.GetButtonDown("LeftBumper") && usingController) || (Input.GetAxis("Mouse ScrollWheel") < 0 && !usingController))
		{
			selectedWeapon --;
			if(selectedWeapon < 0) selectedWeapon = projectilePrefabs.Length -1;
		}

		if((Input.GetButtonDown("RightBumper") && usingController) || (Input.GetAxis("Mouse ScrollWheel") > 0 && !usingController))
		{
			selectedWeapon ++;
			if(selectedWeapon > projectilePrefabs.Length -1) selectedWeapon = 0;
		}

		if((Input.GetAxis("RightTrigger") > 0 && usingController) || (Input.GetMouseButton(0) && !usingController))
		{
			if(shootDelayTimer > shootDelayMax)
			{
				shootDelayTimer = 0f;

				var obj = Instantiate(projectilePrefabs[selectedWeapon]);
				obj.transform.rotation = turretChildTransform.rotation;
				obj.transform.position = projectileSpawn.position;
				if(projectileParent != null) obj.transform.parent = projectileParent;
			}
		}

		if(shootDelayTimer < shootDelayMax)
		{
			shootDelayTimer += Time.deltaTime;
		}

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
		}
	}
}
