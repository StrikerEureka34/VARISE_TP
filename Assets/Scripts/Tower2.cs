using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Tower2 : TowerBase
{
    public GameObject bulletSpawn2;
    public GameObject currentEnemyTarget;

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
            transform.Rotate(0f, 0f, angle / 20);
        }
        
        laserDirection = currentEnemyTarget.transform.position - bulletSpawn2.transform.position;
        ray = new Ray(bulletSpawn2.transform.position, laserDirection);
        hitInfo = new RaycastHit();
        if(Physics.Raycast(ray, out hitInfo, laserDistance)) 
        {
            lineRenderer.SetPosition(1, bulletSpawn2.transform.position);
            lineRenderer.SetPosition(0, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(1, bulletSpawn2.transform.position);
            lineRenderer.SetPosition(0, bulletSpawn2.transform.position + bulletSpawn2.transform.position * laserDistance);
        }
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(ray.origin, ray.direction * laserDistance);

        Gizmos.color= Color.blue;
        Gizmos.DrawWireSphere(hitInfo.point, 2f);
    }*/
    public void ShootBase()
    {
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet02") as GameObject, enemy.transform.position, enemy.transform.rotation);
        Vector3 shootDirection = enemy.transform.forward;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 20;
        enemy.shotTimer = 0;
    }
}
