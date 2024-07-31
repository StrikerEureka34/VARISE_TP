using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower1 : TowerBase
{
    public GameObject bulletSpawn;
    public GameObject currentEnemyTarget;
    //private float bulletVelocity = 15f;
    //public float fireRate = .01f;

    public void Update()
    {
        if (currentEnemyTarget != null)
        {
            Vector3 targetPos = currentEnemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
            transform.Rotate(0f, 0f, angle/20);
        }
    }
    public void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, enemy.bulletSpawn.transform.position, enemy.barrel.transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(enemy.targetDirection * -1 * bulletVelocity);
        Vector3 shootDirection = (enemy.transform.position - enemy.barrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 20;
        enemy.shotTimer = 0;
    }
}
