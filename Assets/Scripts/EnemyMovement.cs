using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public float speed;

    Vector2 positionOffset = new Vector2();
   public Vector2 positionA = new Vector2();
   public Vector2 positionB = new Vector2();

    bool increasing = true;
    bool decreasing = false;
    float prevTime = 0f;
    public bool isFacingRight;
    private void Start()
    {
        positionOffset = transform.position;
        if (!isFacingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        
        float time = Mathf.PingPong(Time.time * speed, 1);
        if (prevTime < time && decreasing)
        {
            Flip();
        }
        else if(prevTime > time && increasing)
        {
            Flip();
        }
       
        positionOffset.x = Vector2.Lerp(positionA, positionB, time).x;
        transform.position = positionOffset;

        if(prevTime < time)
        {
            increasing = true;
            decreasing = false;
        }
        else if(prevTime > time)
        {
            increasing = false;
            decreasing = true;
        }

        prevTime = time;
    }

    void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
    }
}
