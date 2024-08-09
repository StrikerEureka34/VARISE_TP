using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    Health health;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "goob")
        {
            Debug.Log("base collision");
            health = GetComponent<Health>();
            //health.currentHealth = health.currentHealth - 10;
            health.TakeDamage(10);
        }
    }
}
