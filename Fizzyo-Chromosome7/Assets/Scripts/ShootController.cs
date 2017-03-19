using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
    public GameObject shotPrefab;
    public float fireRate;
    private float nextFire;

    public float maxChargeRate;
    private float chargeRate;
    public ParticleSystem chargePS;
	
    public void Shoot() {
        if(Time.time > nextFire) {
            Instantiate(shotPrefab, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    public void SetChargeEfficiency(float efficiency) {
        chargeRate = efficiency * maxChargeRate;
        var chargeEM = chargePS.emission;
        chargeEM.rateOverTime = chargeRate;
    }
}
