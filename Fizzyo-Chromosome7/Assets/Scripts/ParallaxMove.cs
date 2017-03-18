using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour {
    public float maxVx;

    private static float cameraZ = 10;

    private float leftX = -Screen.width;
    private float bottomY = 0;
    private float rightX = 0;
    private float topY = Screen.height;

    private SpriteRenderer sr;
    private float sx;
    
	// Use this for initialization
	void Start () {
        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraZ));
        Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cameraZ));

        sr = GetComponent<SpriteRenderer>();
        Generate();
	}

    void Generate() {
        float startY = Random.Range(bottomY, topY);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(rightX, startY, cameraZ));

        sx = Random.Range(0, maxVx);
        sr.color = Random.ColorHSV();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= Time.deltaTime * new Vector3(sx, 0, 0);
        if(transform.position.x < leftX) {
            Generate();
        }
	}
}
