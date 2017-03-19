using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
    public GameObject missilePrefab;
    public float fireRate;
    private float nextFire;

    public float maxChargeRate;
    private float chargeRate;
    public ParticleSystem chargePS;

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

    public void SetChargeEfficiency(float efficiency) {
        chargeRate = efficiency * maxChargeRate;
        var chargeEM = chargePS.emission;
        chargeEM.rateOverTime = chargeRate;
    }
}
