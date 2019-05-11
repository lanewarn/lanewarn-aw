using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour {

	[LabelOverride("State (Default)")]
	[SerializeField]
	bool state = false;

	[LabelOverride("Keycode")]
	[SerializeField]
	KeyCode keycode;

	void Start()
	{
		this.GetComponent<Camera>().enabled = state;
	}

	void Update () 
	{
		if (Input.GetKeyDown(keycode))
			this.GetComponent<Camera>().enabled = (state = !state);
	}
}
