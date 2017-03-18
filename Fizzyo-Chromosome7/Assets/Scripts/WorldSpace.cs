using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpace : MonoBehaviour {

    public static float leftBound;
    public static float rightBound;
    public static float bottomBound;
    public static float topBound;

    // Use this for initialization
    void Awake () {
        // Set up world space bounds visible from the camera
        Vector3 topRightWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        Vector3 bottomLeftWorld = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

        rightBound = topRightWorld.x;
        topBound = topRightWorld.y;
        leftBound = bottomLeftWorld.x;
        bottomBound = bottomLeftWorld.y;
    }

    public static Vector2 RandomPosition() {
        return new Vector2(RandomX(), RandomY());
    }

    public static float RandomX() {
        return Random.Range(leftBound, rightBound);
    }

    public static float RandomY() {
        return Random.Range(bottomBound, topBound);
    }

    public static Vector3 RandomRHS() {
        return new Vector2(rightBound, RandomY());
    }
}
