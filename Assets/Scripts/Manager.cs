using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public Transform prefab_source;
	public Transform prefab_space;

	public int amnt = 3;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < amnt; i++)
			Instantiate(prefab_source, new Vector3(1, 0, 0), Quaternion.identity);
	}
}
