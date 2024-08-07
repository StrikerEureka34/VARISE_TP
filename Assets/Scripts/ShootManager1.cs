using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager1 : TowerBase
{
    public AudioSource shoot;
    protected override void Update()
    {
        base.Update();  
        enemy.shotTimer1 += Time.deltaTime;
        if (enemy.shotTimer1 > 1.6f)
        {
            if (CanBeSeen1())
            {

                Debug.Log("Hi from cbs1");
                    tower1.Shoot1();
                    shoot.Play();
                    enemy.shotTimer1 = 0;
                
            }
        }
        enemy.shotTimer2 += Time.deltaTime;
        if (enemy.shotTimer2 > 1.6f)
        {
            if (CanBeSeen2())
            {
                
                    tower1.Shoot2();
                    shoot.Play();
                    enemy.shotTimer2 = 0;
                
            }
        }
    }
    public bool CanBeSeen1()
    {
        if (gameObject != null)
        {
            if (Vector3.Distance(enemy.barrel1.transform.position, transform.position) < enemy.sightDistance)
            {
                enemy.targetDirection = enemy.barrel1.transform.position - transform.position;
                float angleToEnemy = Vector3.Angle(enemy.targetDirection, transform.forward);
                if (angleToEnemy >= (enemy.fieldOfView*-1) && angleToEnemy <= enemy.fieldOfView)
                {
                    Ray ray = new Ray(enemy.barrel1.transform.position, -enemy.targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    //Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
                    if (Physics.Raycast(ray, out hitInfo, enemy.sightDistance))
                    {
                        if (hitInfo.transform.gameObject.tag == "enemy")
                        {
                            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public bool CanBeSeen2()
    {
        if (gameObject != null)
        {
            if (Vector3.Distance(enemy.barrel2.transform.position, transform.position) < enemy.sightDistance)
            {
                enemy.targetDirection = enemy.barrel2.transform.position - transform.position;
                float angleToEnemy = Vector3.Angle(enemy.targetDirection, transform.forward);
                if (angleToEnemy >= -enemy.fieldOfView && angleToEnemy <= enemy.fieldOfView)
                {
                    Ray ray = new Ray(enemy.barrel2.transform.position, -enemy.targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, enemy.sightDistance))
                    {
                        if (hitInfo.transform.gameObject.tag == "enemy")
                        {
                            //Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.blue);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}