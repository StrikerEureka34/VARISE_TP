using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 60;

    public void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.TryGetComponent(out Health health))
        {
            //Debug.Log("damage");
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
