using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootManager2 : TowerBase
{
    public void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitInfo, enemy.distance))
        {
            if (hitInfo.transform.gameObject.tag == "Base")
            {
                Debug.DrawRay(ray.origin, ray.direction * enemy.distance, Color.yellow);
                enemy.shotTimer += Time.deltaTime;
                if (enemy.shotTimer > .5f)
                { 
                        tower2.ShootBase();
                }
            }
        }
    }
}