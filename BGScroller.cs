using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller: MonoBehaviour
{
    public const int V = 50;
    public float scrollSpeed;
    public float tileSizeZ;
    public GameController gameController;
    public int score;
    public int speed;

    public Vector3 startPosition;
    public bool beenset;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!beenset && score >= 200)
        {
            beenset = true;
            speed = V;
        }
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
