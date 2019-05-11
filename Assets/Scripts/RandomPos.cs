using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour {

	public int radius = 5;
	public int delay = 2;
	public int slerptime = 2;
    private float timer = 0.0f;
	private Vector3 sourcepos = new Vector3(0,0,0);
	private Vector3 newpos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        timer += Time.deltaTime;	
		if (timer > delay)
		{
			timer = 0;

			sourcepos = newpos;
			newpos = new Vector3(Random.Range(0, radius), 0,
					 			 Random.Range(-radius, radius));
		}
		this.transform.position = Vector3.Slerp(sourcepos, newpos, timer / slerptime);
	}
}
