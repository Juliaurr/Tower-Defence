using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesThrough : MonoBehaviour
{
    public static EnemiesThrough Instance;
    public TextMeshProUGUI enemyCountText;
    public GameObject gameOverScreen;
    private int enemiesThrough = 0;
    private int maxEnemies = 5;
    public int boss = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateEnemyCountText();
        gameOverScreen.SetActive(false);
    }

    public void EnemyGotThrough()
    {
        if (boss == 1)
        {
            GameOver();
            return;
        }

        enemiesThrough++;
        UpdateEnemyCountText();

        if (enemiesThrough >= maxEnemies)
        {
            GameOver();
        }
    }

    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemies got through: " + enemiesThrough + "/" + maxEnemies;
    }

    bool soundPlayed = false;

    private void GameOver()
    {
        if (!soundPlayed)
        {
            gameOverScreen.SetActive(true);
            AudioManager.instance.PauseMusic();
            AudioManager.instance.PlaySound("GameOver");
            soundPlayed = true;
        }
    }
}