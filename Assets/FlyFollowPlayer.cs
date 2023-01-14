using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFollowPlayer : MonoBehaviour
{

    public float InvocationTime = 2f;
    public string targetName;
    public float speed = 5f;
    GameObject target;
    Transform targetTransform;
    Transform thisTransform;
    Rigidbody2D thisRigidbody2D;
    Vector2 newPosition;

    BoxCollider2D normalBoxCollider2D;
    BoxCollider2D childBoxCollider;
    CapsuleCollider2D normalCapsuleCollider2D;
    CapsuleCollider2D childCapsuleCollider;

    GameObject child;
    void Start()
    {
        target = GameObject.Find("" + targetName);
        targetTransform = target.GetComponent<Transform>();
        thisTransform = transform;

        thisRigidbody2D = GetComponent<Rigidbody2D>();

        normalBoxCollider2D = GetComponent<BoxCollider2D>();
        normalCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        child = gameObject.transform.GetChild(0).gameObject;
        childBoxCollider = child.GetComponent<BoxCollider2D>();
        childCapsuleCollider = child.GetComponent<CapsuleCollider2D>();

        InvokeRepeating("FlyToTarget", InvocationTime, Time.fixedDeltaTime);
        Invoke("ChangeColliderSettings", InvocationTime);
    }



    void FlyToTarget()
    {
        if (target)
        {
            newPosition = Vector2.MoveTowards(thisTransform.position, targetTransform.position, speed * Time.fixedDeltaTime);
            thisRigidbody2D.MovePosition(newPosition);
        }
    }

    void ChangeColliderSettings()
    {
        if (normalBoxCollider2D)
        {
            normalBoxCollider2D.enabled = true;
            childBoxCollider.enabled = false;
        }
        else if (normalCapsuleCollider2D)
        {
            normalCapsuleCollider2D.enabled = true;
            childCapsuleCollider.enabled = false;
        }
    }
}
