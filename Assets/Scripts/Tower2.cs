using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class Tower2 : TowerBase
{
    public GameObject bulletSpawn2;
    public GameObject Base;
    public AudioSource laser;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private float laserDistance = 100f;

    [SerializeField]
    private UnityEvent onHitTarget;

    private Ray ray;
    private RaycastHit hitInfo;
    private Vector3 laserDirection;

    void Start()
    {
        lineRenderer.positionCount = 2;
        
    }

    protected override void Update()
    {
        base.Update();
        health = currentEnemyTarget.GetComponent<Health>();
        if (currentEnemyTarget != null)
        {
            Vector3 targetPos = currentEnemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
            transform.Rotate(0f, 0f, (angle * -1) / 90);



            laserDirection = currentEnemyTarget.transform.position - bulletSpawn2.transform.position;
            ray = new Ray(bulletSpawn2.transform.position, laserDirection);
            hitInfo = new RaycastHit();
            //Debug.DrawRay(ray.origin, ray.direction * laserDistance, Color.blue);
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
                //Debug.Log("damage");
                health.TakeDamage(.7f);
                laser.Play();
            }
        }
    }
    public void ShootBase()
    {
        //Debug.Log("In shootBase");
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet02") as GameObject, currentEnemyTarget.transform.position, Quaternion.identity);
        Vector3 shootDirection = Base.transform.position - currentEnemyTarget.transform.position;
        /*Ray ray = new Ray(enemy.transform.position, shootDirection);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.gray);*/
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 3;
        enemy.shotTimer1 = 0;
    }
}
