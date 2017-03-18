using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour {
    public float size;
    private float speed { get { return 1 + 1 / size; } }

    private const float maxExtraDistance = 2;
    private float extraDistance;

    private SpriteRenderer sr;
    
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        transform.localScale = size * Vector2.one;

        Generate();
        transform.position = WorldSpace.RandomPosition();
	}

    void Generate() {
        transform.position = WorldSpace.RandomRHS();
        
        Color newColour = 0.8f * Random.ColorHSV();
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
