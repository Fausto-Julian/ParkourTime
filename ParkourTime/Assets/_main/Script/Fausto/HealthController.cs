using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private PlayerSFX sfx;

    public Action OnDeath;

    private void Awake()
    {
        sfx = GetComponent<PlayerSFX>();
        currentHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        if (health > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = health;
        }
    }

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void GetHeal(float heal)
    {
        currentHealth += heal;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public float GetCurrentHealth()
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        return currentHealth;
    }

    public float GetDefaultHealth()
    {
        return maxHealth;
    }


    public void SetDefaultHealth()
    {
        currentHealth = maxHealth;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }


    public void TakeDamage(float damage)
    {
        if (sfx.audioSource.clip != sfx.deathSFX)
            sfx.DeathSFX();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
