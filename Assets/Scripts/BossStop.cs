using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStop : MonoBehaviour
{
    public GameObject swordman;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!swordman)
        {
            gameObject.SetActive(false);
        }
    }
}
