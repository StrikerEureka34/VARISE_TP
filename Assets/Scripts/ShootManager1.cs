using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager1 : TowerBase
{
    public AudioSource shoot;
    [SerializeField] private LayerMask enemyLayerMask;
    protected override void Update()
    {
        base.Update();  
        enemy.shotTimer1 += Time.deltaTime;
        if (enemy.shotTimer1 > .6f)
        {
            if (CanBeSeen1())
            {
                Debug.Log("seen");
                tower1.Shoot1();
                shoot.Play();
                enemy.shotTimer1 = 0;
            }
        }
        enemy.shotTimer2 += Time.deltaTime;
        if (enemy.shotTimer2 > .6f)
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
        if (currentEnemyTarget != null)
        {
            if (Vector3.Distance(tower1.barrel1.transform.position, currentEnemyTarget.transform.position) < tower1.sightDistance)
            {
                Vector3 targetDirection = -tower1.barrel1.transform.position + currentEnemyTarget.transform.position;
                Ray ray = new Ray(tower1.barrel1.transform.position, targetDirection);
                RaycastHit hitInfo = new RaycastHit();
                Debug.DrawRay(ray.origin, ray.direction * 50, Color.white);
                
                float angleToEnemy = Vector3.Angle(targetDirection, tower1.transform.forward);
                if (angleToEnemy >= (tower1.fieldOfView * -1) && angleToEnemy <= tower1.fieldOfView)
                {
                    /*Ray ray = new Ray(tower1.barrel1.transform.position, -targetDirection);
                    RaycastHit hitInfo = new RaycastHit();*/
                    Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
                    if (Physics.Raycast(ray, out hitInfo, tower1.sightDistance, enemyLayerMask))
                    {
                        if (hitInfo.transform.gameObject.tag == "enemy")
                        {
                            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
                            return true;
                        }
                        else
                            Debug.Log(hitInfo.transform.name);
                    }
                }
            }
        }
       
        return false;
    }
    public bool CanBeSeen2()
    {
        if (currentEnemyTarget != null)
        {
            if (Vector3.Distance(tower1.barrel2.transform.position, currentEnemyTarget.transform.position) < tower1.sightDistance)
            {
                Vector3 targetDirection = tower1.barrel2.transform.position - currentEnemyTarget.transform.position;
                float angleToEnemy = Vector3.Angle(targetDirection, tower1.transform.forward);
                if (angleToEnemy >= (tower1.fieldOfView * -1) && angleToEnemy <= tower1.fieldOfView)
                {
                    Ray ray = new Ray(tower1.barrel2.transform.position, -targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    //Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
                    if (Physics.Raycast(ray, out hitInfo, tower1.sightDistance))
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
}