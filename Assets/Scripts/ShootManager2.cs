/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootManager2 : TowerBase
{
    public float shotTimer;
    protected override void Update()
    {
        base.Update();

        if (enemy == null) return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitInfo, enemy.distance))
        {
            Debug.DrawRay(ray.origin, ray.direction * enemy.distance, Color.cyan);
            if (hitInfo.transform.gameObject.tag == "Base")
            {
                Debug.DrawRay(ray.origin, ray.direction * enemy.distance, Color.yellow);
                shotTimer += Time.deltaTime;
                if (shotTimer > .5f)
                { 
                    tower2.ShootBase();
                    shotTimer = 0f;
                }
            }
        }
    }
}*/