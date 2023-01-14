using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    /* void Update()
     {
         if (Input.GetButtonDown("Fire1"))
         {
             Shoot();
         }
     }

     void Shoot()
     {
        // RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
         Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
     }
    */
}
