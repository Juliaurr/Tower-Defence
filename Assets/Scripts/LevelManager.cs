using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform[] startPoint;
    public Transform[] path;
    public GameObject victoryScreen;
    public int currency;
    public bool bossHasSpawned = false;
    public bool isBossAlive = false;

    private void Awake() 
    {
        main = this;
    }

    private void Start() 
    {
        victoryScreen.SetActive(false);
        currency = 200;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough money.");
            return false;
        }
    }

    bool soundPlayed = false;

    void Update()
    {
        if (bossHasSpawned && !isBossAlive && !soundPlayed)
        {
            victoryScreen.SetActive(true);
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlaySound("Victory");
            soundPlayed = true;
        }
    }
}
