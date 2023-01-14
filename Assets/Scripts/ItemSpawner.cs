using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int numberOfCoins = 1;
    public int numberOfMeat = 1;
    public GameObject coinPrefab;
    public GameObject MeatPrefab;
    public float XpushForce = 5f;
    public float YpushForce = 5f; 
    public float lowerRandomizerLimit = 0f;
    public float upperRandomizerLimit = 1f;
    GameObject coin;
    GameObject meat;
    Rigidbody2D coinRigidbody;
    Rigidbody2D meatRigidbody;
    float randomizer;
    float leftOrRight;

    private void Start()
    {
        randomizer = Random.value * (upperRandomizerLimit - lowerRandomizerLimit) + lowerRandomizerLimit;
    }
   public void SpawnStuff()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            leftOrRight = Random.value;
            leftOrRight = (leftOrRight > 0.5f) ? 1f : -1f; 
            randomizer = Random.value * (upperRandomizerLimit - lowerRandomizerLimit) + lowerRandomizerLimit;
            coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            coinRigidbody = coin.GetComponent<Rigidbody2D>();
            coinRigidbody.AddForce(new Vector2(leftOrRight * XpushForce * randomizer, YpushForce * randomizer), ForceMode2D.Impulse);
        }

        for (int i = 0; i < numberOfMeat; i++)
        {
            leftOrRight = Random.value;
            leftOrRight = (leftOrRight > 0.5f) ? 1f : -1f;
            randomizer = Random.value * (upperRandomizerLimit - lowerRandomizerLimit) + lowerRandomizerLimit;
            meat = Instantiate(MeatPrefab, transform.position, Quaternion.identity);
            meatRigidbody = meat.GetComponent<Rigidbody2D>();
            meatRigidbody.AddForce(new Vector2(leftOrRight * XpushForce * randomizer, YpushForce * randomizer), ForceMode2D.Impulse);
        }
    }
}
