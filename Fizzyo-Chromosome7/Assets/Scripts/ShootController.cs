﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
    public GameObject shotPrefab;
    public AudioClip shotSound;
    public float fireRate;
    private float nextFire;

    public float maxParticleRate;
    public float maxChargeRate;
    private float chargeRate;
    public ParticleSystem chargePS;

    public float maxCharge = 1f;
    private float charge = 0f;
    private float shotCost = 1f;

    void Start() {
        SetChargeEfficiency(0f);
    }
	
    public void Shoot() {
        if(Time.time > nextFire && charge >= shotCost) {
            charge -= shotCost;
            nextFire = Time.time + fireRate;

            Instantiate(shotPrefab, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(shotSound, gameObject.transform.position);
        }
    }

    void Update() {
        charge += Time.deltaTime * chargeRate;
        charge = Mathf.Min(maxCharge, charge);
    }

    public void SetChargeEfficiency(float efficiency) {
        chargeRate = efficiency * maxChargeRate;
        var chargeEM = chargePS.emission;
        chargeEM.rateOverTime = efficiency * maxParticleRate;
    }
}
