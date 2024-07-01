using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawn : MonoBehaviour
{
    public static UnityEvent enemyKilled = new UnityEvent();
    public GameObject[] enemyPrefabs;
    public int baseEnemies = 8;
    public float enemiesPerSecond = 0.5f;
    public float timeBetweenWaves = 5f;
    public float difficultyScalingFactor = 0.75f;
    public TextMeshProUGUI waveText; // Text element to display the wave progress
    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    public int waveToShowDialogue = 5;

    private void Awake()
    {
        enemyKilled.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
        UpdateWaveText();
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint[0].position, Quaternion.identity);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;

        // Update wave text
        UpdateWaveText();

        // Check if it's time to show the dialogue
        if (currentWave == waveToShowDialogue)
        {
            Dialogue.instance.StartDialogue();
        }

        StartCoroutine(StartWave());
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = "Wave " + currentWave + "/" + waveToShowDialogue;
        }
    }
}