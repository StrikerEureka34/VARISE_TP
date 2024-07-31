using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    int maxHealth = 100;
    public int currentHealth;
    public int points = 0; 

    [SerializeField] PlayerType playerType;

    public enum PlayerType
    {
        Base,
        Enemy
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (playerType == PlayerType.Base)
        {
            // Game over
        } 
        else if (playerType == PlayerType.Enemy) 
        {
            points += 10;
            Destroy(gameObject);
        }
    }
}
