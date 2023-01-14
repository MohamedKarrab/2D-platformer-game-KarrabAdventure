using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector2 positionOffset = new Vector2();
    Vector2 nextPosition = new Vector2();
    
    
    void Start()
    {
        positionOffset = transform.position;
    }

    void Update()
    {
        transform.Rotate(new Vector2(0f, Time.deltaTime * degreesPerSecond), Space.World);

        nextPosition = positionOffset;
        nextPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = nextPosition;
    }
}
