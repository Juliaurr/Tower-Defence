using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public float hitPoints;
    public float maxHitPoints = 2;
    private bool isDestroyed = false;
    private int currencyWorth = 50;
    public TurretElement element;
    public GameObject popUpTextPrefab;
    private float lastImmuneSoundTime = 0f; 
    private float immuneSoundCooldown = 3f; 


    void Start()
    {
        hitPoints = maxHitPoints;
    }

    public void TakeDamage(float damage, TurretElement turretelement)
    {
        if (element == turretelement)
        {
            // Check if the cooldown period has passed before playing the sound
            if (Time.time >= lastImmuneSoundTime + immuneSoundCooldown)
            {
                AudioManager.instance.PlaySound("Immune");
                lastImmuneSoundTime = Time.time; // Update the last played time
            }
            Instantiate(popUpTextPrefab, transform);
            return;
        }

        switch (turretelement)
        {
            case TurretElement.Fire:
            if (element == TurretElement.Water || element == TurretElement.Ice)
            {
                hitPoints -= damage + 1;
            }
            else
            {
                hitPoints -= damage;
            }
            break;
            case TurretElement.Water:
            if (element == TurretElement.Fire)
            {
                hitPoints -= damage + 1;
            }
            else
            {
                hitPoints -= damage;
            }
            break;
            case TurretElement.Ice:
            hitPoints -= damage;
            break;
            case TurretElement.Earth:
            hitPoints -= damage;
            break;
            default:
            if (element == TurretElement.Boss)
            {
                hitPoints -= damage;
            }
            break;
        }
        
        UpdateHealthBar(hitPoints, maxHitPoints);

        if (hitPoints <= 0 && !isDestroyed)
        {
            if (tag == "Boss" && LevelManager.main.bossHasSpawned)
            {
                LevelManager.main.isBossAlive = false;
            }

            EnemySpawn.enemyKilled.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
