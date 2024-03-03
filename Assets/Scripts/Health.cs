
using System;
using UnityEngine;

public class Health: MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public event Action Died;
    public event Action<float> Changed;

    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    
    public void Heal(float value)
    {
        if (value > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, MaxHealth);
            Changed?.Invoke(CurrentHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
            Changed?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}
