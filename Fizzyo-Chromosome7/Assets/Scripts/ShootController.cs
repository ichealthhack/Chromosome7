using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
    public GameObject missilePrefab;
    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start () {
        fireRate = 0.2f;
        nextFire = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
        if (FizzyoDevice.Instance().ButtonDown() || Input.GetKeyDown(KeyCode.Space))
        {
           GameObject missile = (GameObject)Instantiate(missilePrefab, transform.position, transform.rotation);
        }
        else if ((FizzyoDevice.Instance().ButtonDown() || Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject missile = (GameObject)Instantiate(missilePrefab, transform.position, transform.rotation);
            //Instantiate(missilePrefab, transform.position, transform.rotation);
        }

    }
}
