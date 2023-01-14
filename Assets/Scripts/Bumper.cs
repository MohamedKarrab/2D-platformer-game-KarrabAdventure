using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    Rigidbody2D thisRigidbody;
    public float bumpForce = 5f;
    float randomizer;
    public bool randomizerOn = true;
    private void Start()
    {
        randomizer = 1f;
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (randomizerOn)
        {
            randomizer = Random.value * 0.75f + 0.25f;
        }
        thisRigidbody.AddForce(new Vector2(0, bumpForce * randomizer), ForceMode2D.Impulse);
        bumpForce /= 2;
        if(bumpForce <= 0.5)
        {
            bumpForce = 0;
        }
    }
}
