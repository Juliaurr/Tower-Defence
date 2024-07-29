using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform endPoint;
    public Rigidbody2D rb;
    public float moveSpeed = 2f;
    private Transform target;
    private int pathIndex = 0;
    private float baseSpeed;

    private void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIndex];
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            EnemyReachedEnd();
        }

        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex == LevelManager.main.path.Length)
            {
                EnemySpawn.enemyKilled.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void EnemyReachedEnd()
    {
        // Notify the GameManager that an enemy has gotten through
        if (tag == "Boss")
        {
            EnemiesThrough.Instance.boss++;
        }
        EnemiesThrough.Instance.EnemyGotThrough();

        // Destroy the enemy or deactivate it
        Destroy(gameObject);
    }

    private void FixedUpdate() 
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
