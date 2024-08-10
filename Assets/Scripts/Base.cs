using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    Health health;
    public int baseHealth = 10;
    public TextMeshProUGUI basePoints; // Use TextMeshProUGUI

        
        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "goob")
        {
            //Debug.Log("base collision");
            basePoints.text = baseHealth.ToString();
            baseHealth--;
            health = GetComponent<Health>();
            //health.currentHealth = health.currentHealth - 10;
            health.TakeDamage(10);
        }
    }
}
