using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health stats")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    public event Action<float> HealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))//-хп от тыки
        {
            ChangeHealth(-25);
        }
    }
    private void ChangeHealth(int value)
    {
        currentHealth += value;
        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float currentHealthAsPercantage = (float)currentHealth / maxHealth;
            HealthChanged?.Invoke(currentHealthAsPercantage);
        }
    }
    private void Death()
    { 
        HealthChanged?.Invoke(0);
        Debug.Log("LOOOOx Pidr");
    }
}
