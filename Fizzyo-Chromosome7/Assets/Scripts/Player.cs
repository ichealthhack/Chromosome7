using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;

	private float maxY;
	private float minY;

	private bool movingDown;
	public float deltaT;
	private float nextT;

    private ShootController shootController;

	// Use this for initialization
	void Start () {
		speed = 0.1f;
		maxY = WorldSpace.topBound - 1;
		minY = WorldSpace.bottomBound + 1;
		deltaT = 0.01f;
		nextT = Time.time;
		movingDown = true;
		transform.position = new Vector2 (WorldSpace.leftBound + 1, WorldSpace.RandomY());

        shootController = GetComponentInChildren<ShootController>();
	}

	// Update is called once per frame
	void Update () {
        MovePlayer();
        HandleShooting();
	}

    private void HandleShooting() {
        if(Input.GetButton("Fire1")) {
            shootController.Shoot();
        }
    }

    private void MovePlayer() {
        if (Time.time > nextT) {
            float newY;

            if (movingDown)
                newY = transform.position.y - speed;
            else
                newY = transform.position.y + speed;

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            if (newY < minY)
                movingDown = false;
            if (newY > maxY)
                movingDown = true;

            nextT = Time.time + deltaT;
        }
    }
}
	