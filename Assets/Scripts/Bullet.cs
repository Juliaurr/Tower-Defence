using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 5f;
    public Rigidbody2D rb;
    public int bulletDamage = 1;
 
    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
