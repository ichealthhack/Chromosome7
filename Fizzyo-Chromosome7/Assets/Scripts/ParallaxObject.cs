using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour {
    public Color baseColour;
    public float baseColourRatio;
    private float speed;

    private const float maxExtraDistance = 2;
    private float extraDistance;

    private SpriteRenderer sr;
    
	void Start () {
        sr = GetComponent<SpriteRenderer>();

        Generate();
        transform.position = WorldSpace.RandomPosition();
	}

    public void UpdateSize(float size) {
        transform.localScale = size * Vector2.one;
        speed = 1 + (17 * size);
    }

    private void Generate() {
        transform.position = WorldSpace.RandomRHS();
        
        Color newColour = (1f - baseColourRatio) * Random.ColorHSV()
                          + baseColourRatio * baseColour;
        newColour.a = 1.0f;
        sr.color = newColour;

        extraDistance = Random.Range(0, maxExtraDistance);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= Time.deltaTime * new Vector3(Mathf.Abs(speed), 0, 0);
        if(transform.position.x < (WorldSpace.leftBound - extraDistance)) {
            Generate();
        }
	}
}
