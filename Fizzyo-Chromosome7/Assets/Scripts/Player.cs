using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float newY;
	public float speed;
	public float maxY;
	public float minY;
	public float deltaT;
	private float nextT;
	private bool movingDown;

	// Use this for initialization
	void Start () {
		newY = 0;
		speed = 0.1f;
		maxY = 4f;
		minY = -4f;
		deltaT = 0.01f;
		nextT = Time.time;
		movingDown = true;
		transform.position = new Vector3 (-9, transform.position.x, transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextT) {
			if (movingDown)
				newY = transform.position.y - speed;
			else
				newY = transform.position.y + speed;
		
			transform.position = new Vector3 (transform.position.x, newY, transform.position.z);

			if (newY < minY)
				movingDown = false;
			if (newY > maxY)
				movingDown = true;

			nextT = Time.time + deltaT;
		}
	}
}
	