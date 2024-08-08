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
    public GameObject dir;

    public float sightDistance = 500f;
    public float fieldOfView = 100f;
    private RaycastHit hitInfo;
    private RaycastHit hitInfo1;
    private RaycastHit hitInfo2;
    public Ray ray1;
    public Ray ray2;
    protected override void Update()
    {
        base.Update();
        if (currentEnemyTarget != null)
        {
            health = currentEnemyTarget.GetComponent<Health>();
            Vector3 shootDirection1 = -(bulletSpawn1.transform.position - currentEnemyTarget.transform.position).normalized;
            Vector3 shootDirection2 = -(bulletSpawn2.transform.position - currentEnemyTarget.transform.position).normalized;
            ray1 = new Ray(bulletSpawn1.transform.position, shootDirection1);
            ray2 = new Ray(bulletSpawn2.transform.position, shootDirection2);
            Debug.DrawRay(ray1.origin, ray1.direction * 10, Color.gray);
            Debug.DrawRay(ray2.origin, ray2.direction * 10, Color.gray);
            if (currentEnemyTarget != null)
            {
                Vector3 targetPos = currentEnemyTarget.transform.position - transform.position;
                float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
                transform.Rotate(0f, angle / 60, 0f);
            }
        }
    }
    public void Shoot1()
    {
        if (Physics.Raycast(ray1, out hitInfo))
        {
            if (hitInfo.collider.gameObject.CompareTag("enemy") || (hitInfo.collider.gameObject.CompareTag("goob")))
            {
                Debug.Log("Shoot1");
                Vector3 shootDirection1 = -(bulletSpawn1.transform.position - currentEnemyTarget.transform.position).normalized;
                ray1 = new Ray(bulletSpawn1.transform.position, shootDirection1);
                enemy.shotTimer1 += Time.deltaTime;
                GameObject bullet1 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, bulletSpawn1.transform.position, dir.transform.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(shootDirection1 * 50);
            }
        }
    }
           
    public void Shoot2()
    {
        if (Physics.Raycast(ray2, out hitInfo))
        {
            if (hitInfo.collider.gameObject.CompareTag("enemy") || (hitInfo.collider.gameObject.CompareTag("goob")))
            {
                Vector3 shootDirection2 = -(bulletSpawn2.transform.position - currentEnemyTarget.transform.position).normalized;
                ray2 = new Ray(bulletSpawn2.transform.position, shootDirection2);
                enemy.shotTimer2 += Time.deltaTime;
                GameObject bullet2 = GameObject.Instantiate(Resources.Load("Prefabs/Bullet01") as GameObject, bulletSpawn2.transform.position, dir.transform.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(shootDirection2 * 50);
            }
        }
    }
 }
        
  
