using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;

    private float maxBreath = 60f;

    private float maxY;
	private float minY;

	private bool movingDown;

    private ShootController shootController;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.HasKey("Max Fizzyo Pressure")) {
            maxBreath = PlayerPrefs.GetFloat("Max Fizzyo Pressure");
        }

        maxY = WorldSpace.topBound - 1;
		minY = WorldSpace.bottomBound + 1;
		movingDown = true;
		transform.position = new Vector2 (WorldSpace.leftBound + 1, WorldSpace.RandomY());

        shootController = GetComponentInChildren<ShootController>();
	}

	// Update is called once per frame
	void Update () {
        MovePlayer();
        HandleShooting();
        HandleCharging();
	}

    private void HandleCharging() {
        //TODO replace with a better algorithm
        float breathingEfficiency = FizzyoDevice.Instance().Pressure();

        shootController.SetChargeEfficiency(breathingEfficiency);
    }

    private void HandleShooting() {
        if(Input.GetButton("Fire1")) {
            shootController.Shoot();
        }
    }

    private void MovePlayer() {
        float newY;
        float dy = Time.deltaTime * speed;

        if (movingDown)
            newY = transform.position.y - dy;
        else
            newY = transform.position.y + dy;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (newY < minY)
            movingDown = false;
        else if (newY > maxY)
            movingDown = true;
    }
}
	