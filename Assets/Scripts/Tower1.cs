using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower1 : TowerBase
{
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject currentEnemyTarget;
    //private float bulletVelocity = 15f;
    //public float fireRate = .01f;

    public void Update()
    {
        if (currentEnemyTarget != null)
        {
            Vector3 targetPos = currentEnemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
            transform.Rotate(0f, 0f, (angle * -1) / 70);
        }
    }
    public void Shoot1()
    {
        enemy.shotTimer1 += Time.deltaTime;
        GameObject bullet1 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, enemy.bulletSpawn1.transform.position, enemy.barrel1.transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(enemy.targetDirection * -1 * bulletVelocity);
        Vector3 shootDirection1 = (enemy.bulletSpawn1.transform.position - enemy.transform.position).normalized;
        bullet1.GetComponent<Rigidbody>().velocity = shootDirection1 * -5;
    }
    public void Shoot2()
    {
        enemy.shotTimer2 += Time.deltaTime;
        GameObject bullet2 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, enemy.bulletSpawn2.transform.position, enemy.barrel2.transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(enemy.targetDirection * -1 * bulletVelocity);
        Vector3 shootDirection2 = (enemy.bulletSpawn2.transform.position - enemy.transform.position).normalized;
        bullet2.GetComponent<Rigidbody>().velocity = shootDirection2 * -5;
    }
}
