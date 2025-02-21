using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int damage = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.TryGetComponent<HealthBase>(out var health))
            {
                health.Damage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health -= 5;
            Destroy(other.gameObject);

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
