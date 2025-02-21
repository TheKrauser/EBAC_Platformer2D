using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private int startHealth = 10;

    [SerializeField] private bool destroyOnKill = false;
    [SerializeField] private float delayToKill = 0f;

    private int currentHealth;
    
    private bool isDead = false;
    public bool IsDead
    {
        get { return isDead; }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        isDead = false;
        currentHealth = startHealth;
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
