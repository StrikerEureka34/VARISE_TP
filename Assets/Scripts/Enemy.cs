using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Enemy : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject barrel;
    public float fireRate = 0.1f;
    public float shotTimer;

    [Header("Sight values")]
    public float sightDistance = 200f;
    public float distance = 50f;
    public float fieldOfView = 100f;
    public Vector3 targetDirection;
    public void Update()
    {
        /*Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            if (hitInfo.transform.gameObject.tag == "Base")
            {
                Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
            }
        }*/
    }
    public bool CanBeSeen()
    {
 
        if (Vector3.Distance(barrel.transform.position, transform.position) < sightDistance)
        {
            targetDirection = barrel.transform.position - transform.position;
            float angleToEnemy = Vector3.Angle(targetDirection, transform.forward);
            if (angleToEnemy >= -fieldOfView && angleToEnemy <= fieldOfView)
            {
                Ray ray = new Ray(barrel.transform.position, -targetDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo, sightDistance))
                {
                    if (hitInfo.transform.gameObject.tag == "enemy")
                    {
                        //Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.red);
                        return true;
                    }
                }
            }
        }
        return false;
    }    
}
