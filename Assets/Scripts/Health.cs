using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int maxHealth = 100;
    public int currentHealth;
    public int points = 0; 

    [SerializeField] PlayerType playerType;

    public Image frontHealthBar;
    public Image backHealthBar;
    private int chipSpeed;
    private float lerpTimer;

    public enum PlayerType
    {
        Base,
        Enemy
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = currentHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, lerpTimer, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        UpdateHealthUI();

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
