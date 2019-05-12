using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System;
using System.Text;

public class Manager : MonoBehaviour {

	public Transform prefab_source;
	public Transform container;

	public int unknownDistance = 3;

	volatile String data = "";

	// Use this for initialization
	void Start () {
		//for (int i = 0; i < amnt; i++)
		//	Instantiate(prefab_source, new Vector3(1, 0, 0), Quaternion.identity);


		new Thread(() => 
		{
        	TcpListener server = new TcpListener(IPAddress.Parse("0.0.0.0"), 1337);
        	server.Start();
			Debug.Log("Listening on port 1337.");

        	TcpClient client = server.AcceptTcpClient();
			Debug.Log("A client connected.");

			NetworkStream stream = client.GetStream();

			//enter to an infinite cycle to be able to handle every change in stream
			while (true) {
				while (!stream.DataAvailable);
				Byte[] bytes = new Byte[client.Available];
				stream.Read(bytes, 0, bytes.Length);

				data = Encoding.ASCII.GetString(bytes);
			}
		}).Start();
	}

	void Update()
	{
		if (data != "")
		{
			Debug.Log("Async. interrupt: " + data);

			// Delete all object in the sceen
			foreach (Transform child in container)
				DestroyImmediate(child.gameObject);
			
			// Create all elements
			foreach (String tracked in data.Split('|'))
			{
				String type = tracked.Split(';')[0];
				float angle = float.Parse(tracked.Split(';')[1]);
				float distance = float.Parse(tracked.Split(';')[2]);

				distance = (distance == -1 ? unknownDistance : distance);

				Instantiate(prefab_source, new Vector3(distance * (float)Math.Cos(angle), 0, distance * (float)Math.Sin(angle)), Quaternion.identity, container);
			}

			data = "";
		}
	}
}
