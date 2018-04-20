using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

	public Resource resource;
	public Slider slider;
	public Text text;

	// Use this for initialization
	void Awake ()
	{
		slider.minValue = resource.minResource;
		slider.maxValue = resource.maxResource;
		if (resource != null)
		{
			resource.OnValueChanged.AddListener(UpdateUI);
		}
		else
		{
			Debug.LogError("No resource defined in Game Object: " + this.transform.name);
		}
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		UpdateUI();
	}
	
	// Update is called once per frame
	public void UpdateUI()
	{
		if (slider != null) 
		{
			slider.maxValue = resource.maxResource;
			slider.value = resource.GetQuantity();
		}
		if(text != null) text.text = resource.GetQuantity()+"/"+resource.maxResource;
	}
}
