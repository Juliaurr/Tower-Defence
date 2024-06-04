using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float freezeDuration = 3f; // Duration of the freeze effect
    public float slowdownFactor = 0.5f; // Factor by which enemies' speed will be reduced
    public float range = 5f; // Range within which enemies will be affected
    public LayerMask enemyLayer; // LayerMask for enemies

    public void FreezeEnemy()
    {
        // Find all colliders within range
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, enemyLayer);

        // List to hold references to all enemy movement scripts
        List<EnemyMovement> enemyMovements = new List<EnemyMovement>();

        // Iterate through all colliders
        foreach (Collider col in colliders)
        {
            // Get reference to the enemy movement script if it exists
            EnemyMovement enemyMovement = col.GetComponent<EnemyMovement>();

            // If enemy movement script exists, add it to the list
            if (enemyMovement != null)
            {
                enemyMovements.Add(enemyMovement);

                // Apply slowdown effect to enemy
                enemyMovement.ApplySlowdown(slowdownFactor, freezeDuration);
            }
        }

        // Start coroutine to reset enemy speeds after freezeDuration
        StartCoroutine(ResetEnemySpeeds(enemyMovements, freezeDuration));
    }

    IEnumerator ResetEnemySpeeds(List<EnemyMovement> enemies, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset all enemy speeds
        foreach (EnemyMovement enemy in enemies)
        {
            enemy.ResetSpeed();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere around the object to visualize its range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}