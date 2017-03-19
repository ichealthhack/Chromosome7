using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject bgoPrefab;
    public int numBgos;
    public float maxBgoSize;
    public float minBgoSize;
	private float nextTime;
	public float deltaT;

	public GameObject hazard;

    void Start() {
        transform.position = Camera.main.transform.position;
        SetupBackground(numBgos);
    }

	void Update() {
		if (Time.time > nextTime) {
			SpawnWaves ();
			nextTime = Time.time + deltaT;
		}
	}

    private void SetupBackground(int numBackgroundObjects) {
        for(int i = 0; i < numBackgroundObjects; i++) {
            GameObject spawnedObject = Instantiate(bgoPrefab);
            spawnedObject.GetComponent<ParallaxObject>().UpdateSize(Random.Range(minBgoSize, maxBgoSize));
            spawnedObject.transform.parent = transform;
        }
    }

	private void SpawnWaves() {
		Vector2 spawnPosition = new Vector2 (9, Random.Range(-4f, 4f));
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}
}
