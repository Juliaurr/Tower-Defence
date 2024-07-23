using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum TurretElement
{
    Fire, Water, Ice, Earth, Boss
};

public class Turret : MonoBehaviour
{
    public float targetRange = 5f;
    private Transform target;
    public LayerMask enemyMask;
    public GameObject bulletPrefab;
    public Transform firingPoint;
    private float bulletsPerSecond = 1f;
    private float timeUntilFire;
    public TurretElement element;

    private void OnDrawGizmosSelected() 
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        if (!CheckTargetRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bulletsPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.element = element;
        bulletScript.SetTarget(target);
    }

    private bool CheckTargetRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}