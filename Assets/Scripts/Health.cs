using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : TowerBase
{
    int maxHealth = 100;
    public float currentHealth;
    public Transform pointObj;
    private PointsManager pointManager;

    [SerializeField] PlayerType playerType;

    public Image frontHealthBar;
    public Image backHealthBar;
    private int chipSpeed;
    private float lerpTimer;


    //public GameObject currentEnemyTarget;
    public enum PlayerType
    {
        Base,
        Enemy
    }

    private void Start()
    {
        currentHealth = maxHealth;
        pointManager = pointObj.GetComponent<PointsManager>();
    }

    protected override void Update()
    {
        base.Update();  
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        //UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = currentHealth/maxHealth;
        if (fillB > hFraction)
        {
            //Debug.Log("fillB");
            frontHealthBar.fillAmount = hFraction;
            //Debug.Log(frontHealthBar.fillAmount);
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer/chipSpeed;
            //percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, lerpTimer, percentComplete);
        }
        if (fillF < hFraction)
        {
           // Debug.Log("fillF");
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        //Debug.Log(currentHealth);
        //UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
            //currentEnemyTarget
        }
    }

    void Die()
    {
        if (playerType == PlayerType.Base)
        {
            SceneManager.LoadScene(0);
        } 
        else if (playerType == PlayerType.Enemy) 
        {
            /*points = points+10;
            Debug.Log("points=" + points);*/
            Destroy(gameObject);

        }
    }

    private void OnDestroy()
    {
        pointManager.Points();
    }
}
