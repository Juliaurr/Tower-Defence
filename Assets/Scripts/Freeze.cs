using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEditor;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public LayerMask enemyMask;
    public float targetRange = 2f;
    private float attackPerSecond = 0.25f;
    private float timeUntilFire;
    public float freezeTime = 1f;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / attackPerSecond)
        {
            FreezeInRange();
            timeUntilFire = 0f;
        }
    }

    private void FreezeInRange()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.UpdateSpeed(0.5f);

                StartCoroutine(ResetEnemySpeed(em));
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeTime);
        em.ResetSpeed();
    }
}