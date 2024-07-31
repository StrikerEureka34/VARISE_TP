using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 10;
    public void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
        //Destroy(gameObject);
    }
}
