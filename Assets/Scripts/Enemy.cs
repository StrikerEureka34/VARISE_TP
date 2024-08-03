using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Enemy : MonoBehaviour
{
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject barrel1;
    public GameObject barrel2;
    //public float fireRate = 0.1f;
    public float shotTimer1;
    public float shotTimer2;

    [Header("Sight values")]
    public float sightDistance = 200f;
    public float distance = 100f;
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
    public bool CanBeSeen1()
    {
 
        if (Vector3.Distance(barrel1.transform.position, transform.position) < sightDistance)
        {
            targetDirection = barrel1.transform.position - transform.position;
            float angleToEnemy = Vector3.Angle(targetDirection, transform.forward);
            if (angleToEnemy >= -fieldOfView && angleToEnemy <= fieldOfView)
            {
                Ray ray = new Ray(barrel1.transform.position, -targetDirection);
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
    public bool CanBeSeen2()
    {

        if (Vector3.Distance(barrel2.transform.position, transform.position) < sightDistance)
        {
            targetDirection = barrel2.transform.position - transform.position;
            float angleToEnemy = Vector3.Angle(targetDirection, transform.forward);
            if (angleToEnemy >= -fieldOfView && angleToEnemy <= fieldOfView)
            {
                Ray ray = new Ray(barrel2.transform.position, -targetDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo, sightDistance))
                {
                    if (hitInfo.transform.gameObject.tag == "enemy")
                    {
                        //Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.blue);
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
