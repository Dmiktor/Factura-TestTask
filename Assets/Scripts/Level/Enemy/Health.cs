using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action OnDeath;
    public Action<int,int> OnDamageTaken;

    [SerializeField] private int maxHealth;

    private int currentHealth;

    public void Init()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        OnDamageTaken?.Invoke(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
