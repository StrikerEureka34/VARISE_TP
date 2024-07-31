using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager1 : TowerBase
{
    public void Update()
    {
        enemy.shotTimer += Time.deltaTime;
        if (enemy.shotTimer > .5f)
        {
            if (enemy.CanBeSeen())
            {
                tower1.Shoot();
            }
        }
    }
}