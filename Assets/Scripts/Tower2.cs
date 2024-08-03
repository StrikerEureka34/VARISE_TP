using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Tower2 : TowerBase
{
    public GameObject bulletSpawn2;
    public GameObject currentEnemyTarget;
    public GameObject Base;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private float laserDistance = 100f;

    [SerializeField]
    private UnityEvent onHitTarget;

    private Ray ray;
    private RaycastHit hitInfo;
    private Vector3 laserDirection;

    //private LayerMask ignoreMask;
    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (currentEnemyTarget != null)
        {
            Vector3 targetPos = currentEnemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
            transform.Rotate(0f, 0f, (angle * -1) / 70);
        }
        
        laserDirection = currentEnemyTarget.transform.position - bulletSpawn2.transform.position;
        ray = new Ray(bulletSpawn2.transform.position, laserDirection);
        hitInfo = new RaycastHit();
        //Debug.DrawRay(ray.origin, ray.direction * laserDistance, Color.red);
        if (Physics.Raycast(ray, out hitInfo, laserDistance)) 
        {
            lineRenderer.SetPosition(0, bulletSpawn2.transform.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, bulletSpawn2.transform.position);
            lineRenderer.SetPosition(1, bulletSpawn2.transform.position + bulletSpawn2.transform.position * laserDistance);
        }
        if (Physics.Raycast(ray, out hitInfo, laserDistance))
        {
            health.TakeDamage(.5f);
        }    
    }
    public void ShootBase()
    {
        //Debug.Log("In shootBase");
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet02") as GameObject, enemy.transform.position, Quaternion.identity);
        Vector3 shootDirection = Base.transform.position - enemy.transform.position;
        Ray ray = new Ray(enemy.transform.position, shootDirection);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.gray);
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 3;
        enemy.shotTimer1 = 0;
    }
}
