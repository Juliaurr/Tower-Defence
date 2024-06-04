using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 2f;
    private Transform target;
    private int pathIndex = 0;
    private float baseSpeed;

    private void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
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

    private void FixedUpdate() 
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void ApplySlowdown(float slowdownFactor, float duration)
    {
        // Reduce the speed of the enemy by the slowdown factor
        moveSpeed *= slowdownFactor;

        // Start coroutine to reset the speed after the specified duration
        StartCoroutine(ResetSpeedAfterDelay(duration));
    }

    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset the speed of the enemy to its normal speed
        ResetSpeed();
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
