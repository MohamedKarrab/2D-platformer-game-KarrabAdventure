using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float TimeBeforeDestruction = 0.5f;
    void Start()
    {
        DestroyIt();
    }

    void DestroyIt()
    {
        Destroy(gameObject,TimeBeforeDestruction);
    }  
}
