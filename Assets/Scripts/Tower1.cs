using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower1 : TowerBase
{
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject barrel1;
    public GameObject barrel2;
    public float sightDistance = 200f;
    public float fieldOfView = 100f;
    private RaycastHit hitInfo;
    private RaycastHit hitInfo1;
    private RaycastHit hitInfo2;
    protected override void Update()
    {
        base.Update();
        health = currentEnemyTarget.GetComponent<Health>();
        /*Vector3 shootDirection1 = -(bulletSpawn1.transform.position - currentEnemyTarget.transform.position).normalized;
        Ray ray1 = new Ray(bulletSpawn1.transform.position, shootDirection1);
        hitInfo1 = new RaycastHit();
        Debug.DrawRay(ray1.origin, ray1.direction * 50, Color.yellow);
        Vector3 shootDirection2 = -(bulletSpawn2.transform.position - currentEnemyTarget.transform.position);
        Ray ray2 = new Ray(bulletSpawn2.transform.position, shootDirection2);
        hitInfo2 = new RaycastHit();
        Debug.DrawRay(ray2.origin, ray2.direction * 50, Color.yellow);*/
        if (currentEnemyTarget != null)
        {
            Vector3 targetPos = currentEnemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
            transform.Rotate(0f, 0f, (angle * -1) / 90);
        }
    }
    public void Shoot1()
    {
        Vector3 shootDirection1 = (bulletSpawn1.transform.position - currentEnemyTarget.transform.position).normalized;
        enemy.shotTimer1 += Time.deltaTime;
        GameObject bullet1 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
        bullet1.GetComponent<Rigidbody>().velocity = shootDirection1 * 500;
    }
    public void Shoot2()
    {
        Vector3 shootDirection2 = (bulletSpawn2.transform.position - currentEnemyTarget.transform.position).normalized;
        enemy.shotTimer2 += Time.deltaTime;
        GameObject bullet2 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        bullet2.GetComponent<Rigidbody>().velocity = shootDirection2 * 500;
    }
}
