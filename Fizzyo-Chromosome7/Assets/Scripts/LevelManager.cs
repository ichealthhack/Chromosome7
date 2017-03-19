using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject bgoPrefab;
    public int numBgos;
    public float maxBgoSize;
    public float minBgoSize;

    void Start() {
        transform.position = Camera.main.transform.position;
        SetupBackground(numBgos);
    }

    private void SetupBackground(int numBackgroundObjects) {
        for(int i = 0; i < numBackgroundObjects; i++) {
            GameObject spawnedObject = Instantiate(bgoPrefab);
            spawnedObject.GetComponent<ParallaxObject>().UpdateSize(Random.Range(minBgoSize, maxBgoSize));
        }
    }
}
