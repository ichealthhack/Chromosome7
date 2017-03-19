using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary {
	public float xMin = -10f, xMax = 10f, yMin = -4f, yMax = 5f;
}

public class Spaceship : MonoBehaviour {

	public Boundary boundary;
	private float speed;
	private bool movingDown;
	private float y_position;

	// Use this for initialization
	void Start () {
		movingDown = true;
		speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		y_position = transform.position.y;

		if (y_position < -5f)
			movingDown = false;
		if (y_position > 4f)
			movingDown = true;

		if (movingDown) {
			y_position -= speed;
		} else {
			y_position += speed;
		}

		transform.position = new Vector3(transform.position.x,y_position,transform.position.z);
	}

}
