using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager1 : TowerBase
{
    public void Update()
    {
        enemy.shotTimer1 += Time.deltaTime;
        if (enemy.shotTimer1 > .5f)
        {
            if (enemy.CanBeSeen1())
            {
                {
                    tower1.Shoot1();
                    enemy.shotTimer1 = 0;
                }
            }
        }
        enemy.shotTimer2 += Time.deltaTime;
        if (enemy.shotTimer2 > .5f)
        {
            if (enemy.CanBeSeen2())
            {
                {
                    tower1.Shoot2();
                    enemy.shotTimer2 = 0;
                }
            }
        }
    }
}