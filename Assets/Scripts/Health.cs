using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    private int hitPoints = 2;
    private bool isDestroyed = false;
    private int currencyWorth = 50;
    public TurretElement element;
    public GameObject popUpTextPrefab;

    public void TakeDamage(int damage, TurretElement turretelement)
    {
        if (element == turretelement)
        {
            Instantiate(popUpTextPrefab, transform);
            return;
        }

        switch (turretelement)
        {
            case TurretElement.Fire:
            if (element == TurretElement.Water || element == TurretElement.Ice)
            {
                hitPoints -= damage + 2;
            }
            else
            {
                hitPoints -= damage;
            }
            break;
            case TurretElement.Water:
            if (element == TurretElement.Fire)
            {
                hitPoints -= damage + 2;
            }
            else
            {
                hitPoints -= damage;
            }
            break;
            case TurretElement.Ice:
            GetComponent<EnemyMovement>().ApplySlowdown(0.5f, 2);
            hitPoints -= damage;
            break;
            case TurretElement.Earth:
            hitPoints -= damage;
            break;
        }

        if (hitPoints <= 0 && !isDestroyed)
        {
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
