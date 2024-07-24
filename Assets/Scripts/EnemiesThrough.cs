using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesThrough : MonoBehaviour
{
    public static EnemiesThrough Instance;
    public Text enemyCountText;
    public GameObject gameOverScreen;

    private int enemiesThrough = 0;
    private int maxEnemies = 5;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
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
        gameOverScreen.SetActive(false); // Ensure game over screen is hidden at the start
    }

    public void EnemyGotThrough()
    {
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

    private void GameOver()
    {
        // Show game over screen
        gameOverScreen.SetActive(true);
    }
}