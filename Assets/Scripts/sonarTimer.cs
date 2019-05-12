using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarTimer : MonoBehaviour {

	public int frequency = 5;
	public float initTimer = 0;
	public float timer = 0;

	public int localOffset = 0;
	public static int offset = 0; 
	// Use this for initialization
	void Start () 
	{
		localOffset = (offset++);
	}
	
	// Update is called once per frame
	void Update () {
		if (initTimer < localOffset)
		{
			initTimer += Time.deltaTime;
			return;
		}
		timer += Time.deltaTime;	
		if (timer > frequency)
		{
			timer -= frequency;
			this.GetComponent<AudioSource>().Play();
		}
	}
}
